using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Items.Ores;

namespace glacial_inferno.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FireBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 60;
            Item.wornArmor = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.OnFire3] = true;
            //Might do this later
            //player.buffImmunep[BuffID.Frozen] = true;
        }

        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<FireIngot>(), 8);
            r.AddIngredient(ItemID.GoldBar, 8);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

    }
}
