using System.IO;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace glacial_inferno.NPCs.Enemies.PreHardmode
{
    public class Wheely : BasicNPC
    {
        float docileSpeed;
        float attackSpeed;
        float inertia;


        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            // ai
            NPC.aiStyle = -1;
            docileSpeed = 1.5f;
            attackSpeed = 3f;
            inertia = 25f;

            // hitbox stuff
            NPC.width = 24;
            NPC.height = 30;

            // stats
            NPC.lifeMax = 40;
            NPC.damage = 10;
            NPC.defense = 4;
            NPC.knockBackResist = 0.8f;

            // sounds
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath9;

            // misc
            NPC.value = 10f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // drops 5-7 ice 50% of the time
            npcLoot.Add(ItemDropRule.Common(ItemID.IceBlock, 2, 5, 7));

            // drops appropirate money
            npcLoot.Add(ItemDropRule.CoinsBasedOnNPCValue(NPC.type));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // constant, change as needed
            float spawnModifier = .4f;


            // spawns on surface ice biome
            if (spawnInfo.Player.ZoneSnow)
            {
                return SpawnCondition.Overworld.Chance * spawnModifier;
            }

            return 0f;
        }

        private const int State_Docile = 0;
        private const int State_Surprise = 1;
        private const int State_Attack = 2;

        // fill as many NPC.ai slots as possible
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];
        public ref float jumpTimer => ref NPC.ai[2];
        public ref float AIPreviousXPosition => ref NPC.ai[3];

        public bool jumping = false;
        public bool leftOrRight;

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(jumping);
            writer.Write(leftOrRight);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            jumping = reader.ReadBoolean();
            leftOrRight = reader.ReadBoolean();
        }

        public override void AI()
        {
            float distanceToTrigger = 400f;
            float distanceToEscape = 700f;


            // gravity
            NPC.velocity += new Vector2(0, .15f);


            // get a target but don't face it yet
            NPC.TargetClosest(false);

            // check if the target escaped
            if (AI_State == State_Surprise || AI_State == State_Attack)
            {
                if (!NPC.HasValidTarget || Main.player[NPC.target].Distance(NPC.Center) >= distanceToEscape)
                {
                    AI_State = State_Docile;
                    AI_Timer = 0;
                }
            }

            // if hit and docile or close enough, start attacking
            if (AI_State == State_Docile)
            {
                if (NPC.justHit || (NPC.HasValidTarget && Main.player[NPC.target].Distance(NPC.Center) <= distanceToTrigger))
                {
                    AI_State = State_Surprise;
                    AI_Timer = 0;
                }
            }




            if (AI_State == State_Docile)
            {
                // walk around aimlessly

                if (AI_Timer == 60)
                {
                    NPC.netUpdate = true;
                    leftOrRight = Main.rand.NextBool();

                    // check to see what direction they are going to face
                    NPC.direction = -1;
                    if (leftOrRight)
                    {
                        NPC.direction = 1;
                    }

                }

                InertiaMove(docileSpeed, inertia, NPC.direction);

            }
            else if (AI_State == State_Surprise)
            {
                // jump up and be surprised

                if (AI_Timer == 0)
                {
                    // apply some jump velocity
                    NPC.velocity += new Vector2(0, -8f);
                }

                // check to see if we have reached the ground yet
                Vector2 newPosition = new Vector2(NPC.position.X, NPC.position.Y + 2);
                if (Collision.SolidCollision(newPosition, NPC.width, NPC.height))
                {
                    AI_State = State_Attack;
                    AI_Timer = 0;
                    AIPreviousXPosition = NPC.position.X;
                }


            }
            else if (AI_State == State_Attack)
            {
                // start attacking the player

                NPC.TargetClosest(true);

                if (jumping)
                {
                    // jump code
                    if (jumpTimer == 0)
                    {
                        // apply some jump velocity
                        NPC.velocity += new Vector2(0, -12f);
                    }

                    // check to see if we have reached the ground yet
                    Vector2 newPosition = new Vector2(NPC.position.X, NPC.position.Y + 2);
                    if (Collision.SolidCollision(newPosition, NPC.width, NPC.height))
                    {
                        jumping = false;
                        AI_Timer = 0;
                    }
                }
                else
                {
                    // check if stuck
                    if (AI_Timer % 15 == 0)
                    {
                        if (NPC.position.X == AIPreviousXPosition)
                        {
                            jumping = true;
                            jumpTimer = 0;
                        }
                        AIPreviousXPosition = NPC.position.X;
                    }
                }

                int xDirection = 1;
                if (NPC.direction < 0)
                {
                    xDirection = -1;
                }

                InertiaMove(attackSpeed, inertia, xDirection);
            }
            AI_Timer++;
        }


        private const int frame1 = 0;
        private const int frame2 = 1;
        private const int frame3 = 2;
        private const int frame4 = 3;
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;

            // frame stays the same in the air
            if (AI_State != State_Surprise)
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



        }
    }
}