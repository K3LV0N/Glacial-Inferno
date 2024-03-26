using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles.Ammo.Other
{
    public class HeavySnowballProjectile : ModProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SnowBallFriendly);
            // Projectile.width = 12;
            // Projectile.height = 12;
            AIType = ProjectileID.SnowBallFriendly;
        }
    }
}