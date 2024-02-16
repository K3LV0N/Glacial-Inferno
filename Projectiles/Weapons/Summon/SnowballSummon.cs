using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.CodeAnalysis;

namespace glacial_inferno.Projectiles.Weapons.Summon
{
    public class SnowballSummon : ModProjectile
    {
        private bool jumping = false;
        private int jumpTimer = 0;

        public override void SetDefaults()
        {
            Projectile.width = 16; 
            Projectile.height = 16;

            Projectile.friendly = true; 
            Projectile.minion = true;
            Projectile.minionSlots = 3; 
            Projectile.timeLeft = 3600;

            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;

            Projectile.aiStyle = 1;
            AIType = ProjectileID.SnowBallFriendly;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Snow, 0f, 0f, 0, Color.Cyan, 1f);
            return;
            float speed = 4f;
            float inertia = 20f;
            float jumpSpeed = 8f;
            int jumpDuration = 30;

            Player player = Main.player[Projectile.owner] ;
            Vector2 targetPosition = player.Center;

            Vector2 direction = targetPosition - Projectile.Center;
            direction.Normalize();
            Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction * speed) / inertia;

            // Check for nearby enemies
            float detectionRange = 200f;
            bool foundTarget = false;
            int targetIndex = -1;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && Vector2.Distance(Projectile.Center, npc.Center) < detectionRange)
                {
                    foundTarget = true;
                    detectionRange = Vector2.Distance(Projectile.Center, npc.Center);
                    targetIndex = i;
                }
            }

            if (foundTarget)
            {
                if (!jumping)
                {
                    jumping = true;
                    jumpTimer = 0;
                }

                if (jumping)
                {
                    jumpTimer++;

                    if (jumpTimer <= jumpDuration)
                    {
                        float jumpProgress = (float)jumpTimer / jumpDuration;
                        Vector2 targetDirection = Main.npc[targetIndex].Center - Projectile.Center;
                        targetDirection.Normalize();
                        Projectile.velocity = Vector2.Lerp(Projectile.velocity, targetDirection * jumpSpeed, jumpProgress);
                    }
                    else
                    {
                        jumping = false;
                    }
                }
            }
            else
            {
                jumping = false;
            }

            if (++Projectile.frameCounter >= 10)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                    Projectile.frame = 0;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frozen, 2 * 60);
            Projectile.Kill();
        }
    }
}
