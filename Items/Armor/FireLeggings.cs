using glacial_inferno.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FireLeggings : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 95, 0);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 45;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }

        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<FireIngot>(), 7);
            r.AddIngredient(ItemID.GoldBar, 7);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
