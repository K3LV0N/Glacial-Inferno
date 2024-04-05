// using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;
using System.Collections.Generic;

namespace glacial_inferno.Projectiles.Ammo.Other
{
    public class GlassSnowballProjectile : ModSnowballProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Copy the defaults of the parent class
            base.SetDefaults();
            // set the size to match the texture of the glass snowball
            Projectile.width = 12;
            Projectile.height = 12;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            // BasicShatter<GlassSnowballShatter>(target, 4, 6, -30, 30, 2, Projectile.knockBack, 0);
        }

        public override void OnKill(int timeLeft)
        {
            base.OnKill(timeLeft);
            BasicShatter<GlassSnowballShatter>(4, 6, -30, 30, 2, Projectile.knockBack, 0);
        }

        public void BasicShatter<T>(int projectileAmount, int damage, int minAngle, int maxAngle, float startingVelocity, float knockBack, float yOffset) where T : ModProjectile
        {
            Random rand = new Random();

            HashSet<int> randomAngles = new HashSet<int>();

            int baseAngle = (int)MathHelper.ToDegrees((float)(Math.Atan(Projectile.velocity.Y / Projectile.velocity.X) + Math.PI));
            for (int i = 0; i < projectileAmount; i++)
            {
                int randNumber = rand.Next(minAngle, maxAngle) + baseAngle;
                while (!randomAngles.Add(randNumber))
                {
                    randNumber = rand.Next(minAngle, maxAngle) + baseAngle;
                }
            }

            float y = Projectile.position.Y - yOffset;
            float x = Projectile.position.X;
            Vector2 pos = new Vector2(x, y);
            // Vector2 vel = new Vector2(-Projectile.velocity.X, -Projectile.velocity.Y);
            // vel.Normalize();
            foreach (int randomAngle in randomAngles)
            {
                Vector2 proj = new Vector2(-startingVelocity, 0);
                float angle = MathHelper.ToRadians(randomAngle);
                Matrix matrix = Matrix.CreateRotationZ(angle);
                proj = Vector2.Transform(proj, matrix);
                Projectile.NewProjectile(Projectile.InheritSource(Projectile), pos, proj, ModContent.ProjectileType<GlassSnowballShatter>(), damage, knockBack);
            }
        }
    }
}