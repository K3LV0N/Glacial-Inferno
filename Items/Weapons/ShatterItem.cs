using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons
{
    public abstract class ShatterItem : ModItem
    {
        public virtual void BasicShatter<T>(NPC target, int projectileAmount, int damage, int minAngle, int maxAngle, float startingVelocity, float knockBack, float yOffset) where T : ModProjectile
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
                Vector2 proj = new Vector2(-startingVelocity, 0);
                float angle = MathHelper.ToRadians(randomAngle);
                Matrix matrix = Matrix.CreateRotationZ(angle);

                proj = Vector2.Transform(proj, matrix);
                Projectile.NewProjectile(Item.GetSource_OnHit(target), pos, proj, ModContent.ProjectileType<T>(), damage, knockBack);
            }
        }
    }
}
