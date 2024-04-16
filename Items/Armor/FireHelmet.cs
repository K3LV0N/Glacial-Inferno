using glacial_inferno.Buffs;
using glacial_inferno.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FireHelmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 90, 0);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 30;
            Item.wornArmor = true;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<FireBreastplate>() && legs.type == ModContent.ItemType<FireLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.AddBuff(ModContent.BuffType<FireWeaponBuff>(), 2);
        }

        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<FireIngot>(), 5);
            r.AddIngredient(ItemID.GoldBar, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
