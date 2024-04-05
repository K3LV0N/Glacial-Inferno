using System;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Ammo.Other
{
    public class BlizzardBlowerProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            // Set the Projectile's width and height
            Projectile.width = 10;
            Projectile.height = 100;

            // Make the Projectile invisible
            Projectile.alpha = 255;
            //Projectile.scale = 10f;
            // Set the Projectile to fly straight
            Projectile.aiStyle = 0;

            // Other Projectile settings
            Projectile.friendly = true; // Can damage enemies
            Projectile.hostile = false; // Won't damage the player
            // Projectile.range = true; // This is a ranged Projectile
            Projectile.penetrate = -1; // Infinite penetration (doesn't disappear after hitting an enemy)
            Projectile.timeLeft = 45; // Lasts for 10 seconds (60 frames per second * 10)
            Projectile.ignoreWater = true; // Will not be slowed by water
            Projectile.tileCollide = false; // Will collide with tiles (walls, ground, etc.)

        }

        //overide AI to spawn snow particles
        public override void AI()
        {

            // Vector2 pos = Projectile.position; // Get the Projectile's position
            // //move position down
            // pos.Y += 30;
            // //move position in front of player (pos or negative depending on direction player is facing)
            // pos.X += 40 * Projectile.direction;


            Vector2 pos = Projectile.position; // Get the Projectile's position

            // Calculate the offset based on the player's aiming angle
            float offset = 40f; // Set the initial offset distance
            float angle = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X); // Calculate the aiming angle
            pos += new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * offset; // Apply the offset based on the aiming angle
            pos.Y += 30;
            
            int dustIndex = Dust.NewDust(pos, Projectile.width, 56, DustID.Snow, Projectile.velocity.X, Projectile.velocity.Y, 100, Color.White, 1.5f);
            Dust dust = Main.dust[dustIndex];

            //dust.velocity *= 0.3f; // Reduce the velocity of the dust particle
            dust.noGravity = true; // Make the dust particle not be affected by gravity

        }


        // If you need the Projectile to do something when it hits something, use this method
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            //heal the target for damageDone
            target.life += damageDone;

            //on Hit apply the FrostBurn debuff to the enemy and "blow them back"
            target.AddBuff(BuffID.Frostburn, 60 * 5); // Apply the FrostBurn debuff for 5 seconds\
            // Blow the enemy back by gradually decreasing speed in the same direction the Projectile is moving
            //get actual velocity from x and y
            float actual_vel = (float)System.Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y);


            float maxSpeedX = 10f; // Set the maximum speed ceiling
            float maxSpeedY = 10f; // Set the maximum speed ceiling

            target.velocity.X = MathHelper.Clamp(target.velocity.X + (5 * (Projectile.velocity.X / actual_vel)), -maxSpeedX, maxSpeedX);
            target.velocity.Y = MathHelper.Clamp(target.velocity.Y + (8 * (Projectile.velocity.Y / actual_vel)), -maxSpeedY, maxSpeedY);
        }

    }
}
