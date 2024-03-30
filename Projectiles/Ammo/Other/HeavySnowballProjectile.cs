// using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace glacial_inferno.Projectiles.Ammo.Other
{
    public class HeavySnowballProjectile : ModSnowballProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Copy the defaults of the parent class
            base.SetDefaults();
            // set the size to match the texture of the heavy snowball
            Projectile.width = 24;
            Projectile.height = 24;
        }
    }
}