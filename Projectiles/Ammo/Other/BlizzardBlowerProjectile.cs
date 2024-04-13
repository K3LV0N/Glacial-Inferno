using System;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// Define a namespace for the modded items, specifically other ammo types
namespace glacial_inferno.Projectiles.Ammo.Other
{
    // Declare a new class BlizzardBlowerProjectile that inherits from ModProjectile to represent a custom projectile
    public class BlizzardBlowerProjectile : ModProjectile
    {
        // Set the default properties for the projectile
        public override void SetDefaults()
        {
            Projectile.width = 10; // The width of the projectile's hitbox
            Projectile.height = 100; // The height of the projectile's hitbox

            Projectile.alpha = 255; // Makes the projectile completely transparent (invisible)
            //Projectile.scale = 10f; // Uncomment to set the scale of the projectile
            Projectile.aiStyle = 0; // Sets the AI style to 0, which means no predefined behavior

            // Other projectile settings
            Projectile.friendly = true; // Indicates the projectile can damage enemies
            Projectile.hostile = false; // Indicates the projectile won't damage the player
            // Projectile.range = true; // Uncomment if this is a ranged projectile
            Projectile.penetrate = -1; // Allows the projectile to hit an infinite number of targets without disappearing
            Projectile.timeLeft = 45; // The projectile will last for 45 frames (less than a second at 60fps)
            Projectile.ignoreWater = true; // The projectile will not be slowed down by water
            Projectile.tileCollide = false; // The projectile will not collide with tiles like walls or ground
        }

        // Override the AI method to create custom behavior for the projectile
        public override void AI()
        {
            Vector2 pos = Projectile.position; // Get the current position of the projectile

            // Calculate the offset based on the direction the projectile is moving
            float offset = 40f; // The distance ahead of the projectile where particles spawn
            float angle = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X); // Get the angle of the projectile's velocity
            pos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * offset; // Apply the calculated offset
            pos.Y += 30; // Move the position down by 30 units
            
            // Create a dust particle at the calculated position
            int dustIndex = Dust.NewDust(pos, Projectile.width, 56, DustID.Snow, Projectile.velocity.X, Projectile.velocity.Y, 100, Color.White, 1.5f);
            Dust dust = Main.dust[dustIndex];
            dust.noGravity = true; // Make the dust particle ignore gravity
        }

        // If the projectile hits an NPC, this method defines what happens
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.life += damageDone; // Heals the target for the amount of damage done (may want to remove this line for a damaging projectile)

            // Apply the FrostBurn debuff to the enemy and simulate a "blow back" effect
            target.AddBuff(BuffID.Frostburn, 60 * 5); // Apply the FrostBurn debuff for 5 seconds (300 frames)

            // Calculate the actual velocity magnitude of the projectile
            float actual_vel = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);

            // Set a maximum speed limit for the knockback effect
            float maxSpeedX = 10f; // Maximum horizontal speed
            float maxSpeedY = 10f; // Maximum vertical speed

            // Apply knockback to the target based on the projectile's velocity and the calculated actual velocity
            target.velocity.X = MathHelper.Clamp(target.velocity.X + (5 * (Projectile.velocity.X / actual_vel)), -maxSpeedX, maxSpeedX);
            target.velocity.Y = MathHelper.Clamp(target.velocity.Y + (8 * (Projectile.velocity.Y / actual_vel)), -maxSpeedY, maxSpeedY);
        }
    }
}
