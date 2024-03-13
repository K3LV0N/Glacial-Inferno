using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Buffs;
using Terraria.ID;
using System.Numerics;
using Microsoft.Xna.Framework;
namespace glacial_inferno.Projectiles.Other
{
    public class FlamingBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30; // The width of projectile hitbox
            Projectile.height = 2; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile (1 signifies a simple moving projectile)
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1;
            Projectile.light = .4f;
            
            AIType = ProjectileID.Bullet;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            
            target.AddBuff(BuffID.OnFire, 300);
            base.OnHitNPC(target, hit, damageDone);
        }

        public override void AI()
        {
            //Spawns a fire particle effect on the bullet trail
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
            base.AI();
        }
    }
}
