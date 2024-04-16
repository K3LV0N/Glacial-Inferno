using System;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// Define the namespace for modded ammo and other related items
namespace glacial_inferno.Projectiles.Ammo.Other
{
    // Declare a new class InfernoBlowerProjectile that inherits from ModProjectile to represent a custom projectile
    public class InfernoBlowerProjectile : ModProjectile
    {
        // Set default properties for the projectile
        public override void SetDefaults()
        {
            Projectile.width = 10; // The width of the projectile's hitbox
            Projectile.height = 100; // The height of the projectile's hitbox

            Projectile.alpha = 255; // Make the projectile completely transparent (invisible)
            //Projectile.scale = 10f; // Uncomment to scale the size of the projectile
            Projectile.aiStyle = 0; // Set AI style to 0 for custom behavior

            // Other projectile settings
            Projectile.friendly = true; // Indicates that the projectile can damage enemies
            Projectile.hostile = false; // Indicates that the projectile won't damage the player
            // Projectile.range = true; // Uncomment if this is a ranged projectile
            Projectile.penetrate = -1; // Allows infinite penetration (doesn't disappear after hitting an enemy)
            Projectile.timeLeft = 45; // The projectile will last for 45 frames (less than a second)
            Projectile.ignoreWater = true; // Projectile will not be slowed by water
            Projectile.tileCollide = false; // Projectile will not collide with tiles (walls, ground, etc.)
        }

        // Override the AI method to create custom behavior for the projectile
        public override void AI()
        {
            Vector2 pos = Projectile.position; // Get the current position of the projectile

            // Calculate the offset based on the projectile's velocity angle
            float offset = 30f; // Set the initial offset distance
            float angle = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X); // Calculate the aiming angle
            pos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * offset; // Apply the offset based on the aiming angle
            pos.Y += 10; // Adjust the Y position
            
            // Create dust at the projectile's position
            int dustIndex = Dust.NewDust(pos, Projectile.width, 56, DustID.YellowTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, Color.LightGoldenrodYellow, 1.5f);
            Dust dust = Main.dust[dustIndex];

            //dust.velocity *= 0.3f; // Uncomment to reduce the velocity of the dust particle
            dust.noGravity = true; // Make the dust particle not be affected by gravity
        }

        // If the projectile hits an NPC, apply effects
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Heal the target for the amount of damage done
            target.life += damageDone;

            // Apply the Warmth buff to the enemy and simulate "blowing them back"
            target.AddBuff(BuffID.Warmth, 60 * 5); // Apply the Warmth debuff for 5 seconds

            // Calculate the actual velocity magnitude
            float actual_vel = (float)System.Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);

            // Determine the maximum speed in both X and Y directions
            float maxSpeedX = 10f;
            float maxSpeedY = 10f;

            // Apply knockback to the target based on the projectile's direction
            target.velocity.X = MathHelper.Clamp(target.velocity.X + (5 * (Projectile.velocity.X / actual_vel)), -maxSpeedX, maxSpeedX);
            target.velocity.Y = MathHelper.Clamp(target.velocity.Y + (8 * (Projectile.velocity.Y / actual_vel)), -maxSpeedY, maxSpeedY);
        }
    }
}
