using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles
{
    public abstract class SpecialProjectile : ModProjectile
    {
        // this class contains some helpful functions for 
        // projectiles that we may want to use a multitude of times

        /// <summary>
        /// <para><c>BasicShatter</c> is a function that creates a shatter of projectiles at the site of impact</para> 
        /// <typeparamref name="T"/> is the class of the projectiles that are being created.<br />
        /// <paramref name="target"/> is the enemy hit.<br />
        /// <paramref name="projectileAmount"/> is the total amount of projectiles created.<br />
        /// <paramref name="damage"/> is how much damage each projectile does.<br />
        /// <paramref name="minAngle"/> is the minimum angle from the horizontal that projectiles may be created.<br />
        /// <paramref name="maxAngle"/> is the maximum angle from the horizontal that projectiles may be created.<br />
        /// <paramref name="startingSpeed"/> is the speed of each created projectile.<br />
        /// <paramref name="knockBack"/> is the knockback of each projectile.<br />
        /// <paramref name="yOffset"/> is the difference in y from the target's position.<br />
        /// </summary>
        public virtual void BasicShatter<T>(NPC target, int projectileAmount, int damage, int minAngle, int maxAngle, float startingSpeed, float knockBack, float yOffset) where T : ModProjectile
        {
            Random rand = new Random();

            HashSet<int> randomAngles = new HashSet<int>();


            for (int i = 0; i < projectileAmount; i++)
            {
                int randNumber = rand.Next(minAngle, maxAngle);
                while (!randomAngles.Add(randNumber))
                {
                    randNumber = rand.Next(minAngle, maxAngle);
                }

            }


            float y = target.position.Y - yOffset;
            float x = target.position.X;
            Vector2 pos = new Vector2(x, y);

            foreach (int randomAngle in randomAngles)
            {
                Vector2 proj = new Vector2(-startingSpeed, 0);
                float angle = MathHelper.ToRadians(randomAngle);
                Matrix matrix = Matrix.CreateRotationZ(angle);

                proj = Vector2.Transform(proj, matrix);
                Projectile.NewProjectile(Projectile.GetSource_OnHit(target), pos, proj, ModContent.ProjectileType<T>(), damage, knockBack);
            }
        }
    }
}
