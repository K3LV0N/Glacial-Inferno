using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Ammo.Other;

namespace glacial_inferno.Items.Ammo.Other
{
    public class GlassSnowball : ModSnowball
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Use the same defaults set by the parent class
            base.SetDefaults();
            // Reduce the base damage to be half that of the base snowball
            Item.damage = 4;
            // Reduce the knock back
            Item.knockBack = 3f;
            // Change the spawned projectile to the glass snowball
            Item.shoot = ModContent.ProjectileType<GlassSnowballProjectile>();
        }

        public override void AddRecipes()
        {
            // 10 Crafted with 4 snow blocks and 4 glass blocks
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.IceBlock, 4);
            recipe.AddIngredient(ItemID.Glass, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}