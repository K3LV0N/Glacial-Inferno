using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Ammo.Other;

namespace glacial_inferno.Items.Ammo.Other
{
    public class HeavySnowball : ModSnowball
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Clone the default properties of the parent
            base.SetDefaults();
            // Increase the damage of the heavy snowball
            Item.damage = 16;
            // Increase the knock back of the heavy snowball
            Item.knockBack = 9f;
            // Decrease the heavy snowball's velocity
            Item.shootSpeed = 4.25f;
            // Increase the time needed to throw the heavy snowball
            Item.useTime = Item.useAnimation = 27;
            // Have the item shoot the heavy snowball
            Item.shoot = ModContent.ProjectileType<HeavySnowballProjectile>();
        }

        public override void AddRecipes()
        {
            // 10 crafted with 8 snow blocks and 4 iron/lead bars
            Recipe recipe = CreateRecipe(10);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 4);
            recipe.AddIngredient(ItemID.SnowBlock, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}