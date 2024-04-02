using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles.Ammo.Other
{
    public class ColdCutProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }
        public override void SetDefaults() 
        {
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.width = 8; 
            Projectile.height = 8;
            Projectile.damage = 16;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
        }


    }
}
