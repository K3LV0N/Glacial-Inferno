using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace glacial_inferno.Items.Other;

public class BitterfrostBar : ModItem
{
    public override void SetDefaults()
    {
        Item.rare = ItemRarityID.Blue;
        Item.value = 2500;
        Item.notAmmo = true;
        Item.width = 30;
        Item.height = 24;
        Item.maxStack = 9999;
    }

    public override void AddRecipes()
    {
        Recipe r1 = CreateRecipe();
        r1.AddIngredient(ModContent.ItemType<BitterfrostBlock>(), 3);
        r1.AddTile(TileID.Furnaces);
        r1.Register();
    }

    public override bool CanUseItem(Player player)
    {
        return false;
    }
}
