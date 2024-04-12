using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Buffs.Summon;
using System;

namespace glacial_inferno.Projectiles.Weapons.Summon
{
    public class SnowballSummon3 : SnowballSummon2
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 28;
            Projectile.height = 24;
            Projectile.scale = 1.2f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Skip applying the buff effects for bosses or ice biome mobs
            if (target.boss || target.buffImmune[BuffID.Frostburn])
            {
                return;
            }
            target.AddBuff(ModContent.BuffType<FrozenBuff>(), 8 * 60);
            target.AddBuff(ModContent.BuffType<PermaFreezeBuff>(), 60 * 60);
            Projectile.Kill();
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            if (!CheckActive(owner)) return;

            GeneralBehavior(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition);
            SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);
            Visuals();
        }

        public override void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 vectorToIdlePosition)
        {
            float speed = 8f;
            float inertia = 20f;

            if (foundTarget)
            {
                if (distanceFromTarget > 40f)
                {
                    Vector2 direction = targetCenter - Projectile.Center;
                    direction.Normalize();
                    direction *= speed;

                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                }
            }
            else
            {
                if (distanceToIdlePosition > 600f)
                {
                    speed = 12f;
                    inertia = 60f;
                }
                else
                {
                    speed = 4f;
                    inertia = 80f;
                }

                if (distanceToIdlePosition > 20f)
                {
                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                }
                else if (Projectile.velocity == Vector2.Zero)
                {
                    Projectile.velocity.X = -0.15f;
                    Projectile.velocity.Y = -0.05f;
                }
            }
        }

        private void Visuals()
        {
            if (Projectile.velocity.X >= 0)
            {
                Projectile.spriteDirection = 1;
            }
            else
            {
                Projectile.spriteDirection = -1;
            }

            Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
        }
    }
}
