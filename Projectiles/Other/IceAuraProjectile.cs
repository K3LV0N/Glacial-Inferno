using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles.Other
{
    internal class IceAuraProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 60; // The width of projectile hitbox
            Projectile.height = 2; // The height of projectile hitbox
            Projectile.aiStyle = 0; // The ai style of the projectile (1 signifies a simple moving projectile)
            Projectile.friendly = false; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.timeLeft = 60; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1;
            Projectile.light = .4f;
            base.SetDefaults();
        }


    }
}
