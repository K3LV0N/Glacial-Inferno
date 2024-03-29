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
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }

        //I want to change this recipe with custom mod items later this is just a placeholder
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ItemID.LivingFireBlock, 7);
            r.AddIngredient(ItemID.IronBar, 7);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
