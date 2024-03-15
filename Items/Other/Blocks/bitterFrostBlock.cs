using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Other.Blocks
{
    public class bitterFrostBlock: ModItem
    {
        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<bitterFrostOre>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 20;
            Item.width = 9;
            Item.height = 9;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 9999;
            Item.consumable = true;
        }

        //empty recipe for early testing
        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.Register();
        }
    }
}
