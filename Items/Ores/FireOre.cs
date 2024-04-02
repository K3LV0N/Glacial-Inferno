using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Ores
{
    public class FireOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FireOre>());
            Item.width = 12;
            Item.height = 12;
            Item.value = Item.sellPrice(0, 0, 3, 0); ;
        }
    }
}
