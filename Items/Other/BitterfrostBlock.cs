using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Other;

public class BitterfrostBlock: ModItem
{
    public override void SetDefaults()
    {
        Item.createTile = ModContent.TileType<BitterfrostOre>();
        Item.placeStyle = 1;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useAnimation = 20;
        Item.width = 9;
        Item.height = 9;
        Item.rare = ItemRarityID.Blue;
        Item.maxStack = 9999;
        Item.consumable = true;
        Item.autoReuse = true;
        Item.noMelee = true;
    }
}
