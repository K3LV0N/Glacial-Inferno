using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Ammo;

namespace glacial_inferno.Items.Ammo
{
    // An abstract class to parent all modded snowballs, manages universal traits
    public abstract class ModSnowball : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Snowball);
            /* SNOWBALL DEFAULTS:
             * Damage = 8, Knock back = 5.75, Use time = 19
             * Velocity = 7, Rarity = white
             */
            // Set the summoned projectile to the Mod Snowball projectile
            // NOTE: This always has to be overwritten
            Item.shoot = ModContent.ProjectileType<ModSnowballProjectile>();
        }
    }
}