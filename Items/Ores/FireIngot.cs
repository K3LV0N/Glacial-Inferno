using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Ores
{
    public class FireIngot : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.value = Item.sellPrice(0, 0, 12, 0); ;
        }

        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient<FireOre>(4);
            r.AddTile(TileID.Furnaces);
            r.Register();
        }
    }
}
