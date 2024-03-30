using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Ammo;

namespace glacial_inferno.Items.Ammo
{
    public class IcySnowball : ModSnowball
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Use the same defaults set by the parent class
            base.SetDefaults();
            // Change the spawned projectile to the icy snowball
            Item.shoot = ModContent.ProjectileType<IcySnowballProjectile>();
        }

        public override void AddRecipes()
        {
            // 10 Crafted with 4 snow blocks and 4 ice blocks
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.IceBlock, 4);
            recipe.AddIngredient(ItemID.SnowBlock, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}