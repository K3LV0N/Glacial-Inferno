using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.CodeAnalysis;
using glacial_inferno.Buffs.Summon;

namespace glacial_inferno.Projectiles.Weapons.Summon
{
    public class SnowballSummon : ModProjectile
    {
        private bool jumping = false;
        private int jumpTimer = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

            Main.projPet[Projectile.type] = true;

            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16; 
            Projectile.height = 16;
            Projectile.ignoreWater = true;

            Projectile.friendly = true; 
            Projectile.minion = true;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
             if (!CheckActive(Main.player[Projectile.owner])) return;

            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Snow, 0f, 0f, 0, Color.Cyan, 1f);

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

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<SnowballSummonBuff>());

                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<SnowballSummonBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }
    }
}
