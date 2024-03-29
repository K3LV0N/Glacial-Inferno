using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles.Weapons.Ranged
{
    public class PlasmaRailgunProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10; // Width of the Projectile hitbox
            Projectile.height = 6; // Height of the Projectile hitbox
            Projectile.aiStyle = 1; // Use the default AI style (straight trajectory)
            Projectile.friendly = true; // Friendly Projectile (doesn't harm players)
    
            Projectile.timeLeft = 600; // Time the Projectile exists (in frames)
            
            Projectile.ignoreWater = true; // Ignores water collision
            Projectile.penetrate = 5;
            AIType = ProjectileID.Bullet; // Use the Bullet AI type
        }
    
    }

}
