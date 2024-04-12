using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System.IO;
using Terraria.UI;
using glacial_inferno.Items.Ores;
using glacial_inferno.Projectiles.Enemy;

namespace glacial_inferno.NPCs
{
    public class FireGolem : ModNPC
    {
        float docileSpeed;
        float aggroSpeed;
        float inertia;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5;
        }
        public override void SetDefaults()
        {
            // ai
            NPC.aiStyle = -1;
            docileSpeed = 1.5f;
            aggroSpeed = 3f;
            inertia = 25f;

            // hitbox stuff
            NPC.width = 25;
            NPC.height = 35;

            // stats
            NPC.lifeMax = 40;
            NPC.damage = 10;
            NPC.defense = 4;
            NPC.knockBackResist = 0.8f;

            // sounds
            NPC.HitSound = SoundID.NPCHit29;
            NPC.DeathSound = SoundID.NPCDeath32;

            // misc
            NPC.value = 100f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            float undergroundSpawnModifier = .1f;
            float overworldSpawnModififer = 0.01f;


            return SpawnCondition.Overworld.Chance * overworldSpawnModififer
                + SpawnCondition.Underground.Chance * undergroundSpawnModifier;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FireOre>(), 2));
        }


        //AI
        //Walks around normally when docile
        //When it spots player and player is in certain range run towards the player
        //Climb wall if necessary
        //If player is close enough spit fire projectile every 5 seconds
        //(Code projectile for that web)
        private const int stateDocile = 0;
        private const int stateSurprised = 1;
        private const int stateAttack = 2;

        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        public ref float jumpTimer => ref NPC.ai[2];
        public ref float AIPreviousXPos => ref NPC.ai[3];

        public bool jumping = false;
        //public bool shooting = false;
        public bool leftOrRight = false;
        public float shootTimer = 0f;

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(jumping);
            //writer.Write(shooting);
            writer.Write(leftOrRight);
            writer.Write(shootTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            jumping = reader.ReadBoolean();
            //shooting = reader.ReadBoolean();
            leftOrRight = reader.ReadBoolean();
            shootTimer = reader.ReadSingle();
        }

        private void move(float speed, float inertia, float xDirection)
        {
            Vector2 direction = new Vector2(xDirection, 0);
            direction.Normalize();
            direction *= speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + direction) / inertia;
        }

        public override void AI()
        {
            float distanceToShoot = 50f;
            float distanceToTrigger = 450f;
            float distanceToEscape = 800f;

            //gravity
            NPC.velocity += new Vector2(0, 0.15f);

            //This gets a target but doesnt make the NPC look at it
            NPC.TargetClosest(false);

            //check if the target got away
            if (AI_State == stateSurprised || AI_State == stateAttack)
            {
                if(!NPC.HasValidTarget || Main.player[NPC.target].Distance(NPC.Center) >= distanceToEscape)
                {
                    AI_State = stateDocile;
                    AI_Timer = 0;
                }
            }

            //If it gets hit and is docile or a player gets close enough aggro
            if (AI_State == stateDocile)
            {
                if (NPC.justHit || (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) <= distanceToTrigger))
                {
                    AI_State = stateSurprised;
                    AI_Timer = 0;
                }
            }

            //If its docile just wander around 
            if (AI_State == stateDocile)
            {
                if (AI_Timer == 60)
                {
                    NPC.netUpdate = true;
                    leftOrRight = Main.rand.NextBool();

                    //check what direction they will face
                    NPC.direction = -1;
                    if (leftOrRight)
                    {
                        NPC.direction = 1;
                    }
                }

                move(docileSpeed, inertia, NPC.direction);
            }
            //If it enters a surprised state stand still and play an animation for half a second 
            else if (AI_State == stateSurprised)
            {
                if (AI_Timer == 30)
                {
                    AI_State = stateAttack;
                    AI_Timer = 0;
                    AIPreviousXPos = NPC.position.X;
                }
            }
            else if (AI_State == stateAttack)
            {
                //attacks the player
                NPC.TargetClosest(true);

                if (jumping)
                {
                    //jump
                    if (jumpTimer == 0)
                    {
                        NPC.velocity += new Vector2(0, -12f);
                    }
                    //check if ground is reached
                    Vector2 newPosition = new Vector2(NPC.position.X, NPC.position.Y + 2);
                    if (Collision.SolidCollision(newPosition, NPC.width, NPC.height))
                    {
                        jumping = false;
                        AI_Timer = 0;
                    }
                    jumpTimer++;
                }
                else
                {
                    //Check if stuck and if so jump
                    if (AI_Timer % 15 == 0)
                    {
                        if (NPC.position.X == AIPreviousXPos)
                        {
                            jumping = true;
                            jumpTimer = 0;
                        }
                    }
                    //jump when the player is higher up than the NPC
                    if (Main.player[NPC.target].Center.Y < NPC.position.Y && jumping == false)
                    {
                        jumping = true;
                        jumpTimer = 0;
                    }
                }
                //shoot a fireball at the player if they get close enough, 5 second recharge time
                if (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) <= distanceToShoot)
                {
                    if (shootTimer >= 300)
                    {
                        //shoot a projectile at the player
                        var source = NPC.GetSource_FromAI();
                        Vector2 position = NPC.Center;
                        Vector2 targetPosition = Main.player[NPC.target].Center;
                        Vector2 direction = targetPosition - position;
                        direction.Normalize();
                        float speed = 10f;
                        int type = ModContent.ProjectileType<HostileFireBall>();
                        int damage = NPC.damage;

                        Projectile.NewProjectile(source, position, direction * speed, type, damage, 0f, Main.myPlayer);

                        shootTimer = 0;
                    }
                }

                int xDirection = 1;
                if (NPC.direction < 0)
                {
                    xDirection = -1;
                }
                move(aggroSpeed, inertia, xDirection);
            }
            AI_Timer++;
            shootTimer++;
        }
        

        private const int frame1 = 0;
        private const int frame2 = 1;
        private const int frame3 = 2;
        private const int frame4 = 3;
        private const int surprisedFrame = 4;
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;

            // frame stays the same in the air
            if (AI_State != stateSurprised)
            {
                if (NPC.frameCounter < 11)
                {
                    NPC.frame.Y = frame1 * frameHeight;
                }
                else if (NPC.frameCounter < 21)
                {
                    NPC.frame.Y = frame2 * frameHeight;
                }
                else if (NPC.frameCounter < 31)
                {
                    NPC.frame.Y = frame3 * frameHeight;
                }
                else if (NPC.frameCounter < 41)
                {
                    NPC.frame.Y = frame4 * frameHeight;
                }
                else
                {
                    NPC.frame.Y = frame1 * frameHeight;
                    NPC.frameCounter = 0;
                }

                NPC.frameCounter++;
            }
            else
            {
                NPC.frame.Y = surprisedFrame * frameHeight;
            }
        }
    }
}
