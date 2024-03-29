using glacial_inferno.Buffs;
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
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<FireBreastplate>() && legs.type == ModContent.ItemType<FireLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.AddBuff(ModContent.BuffType<FireWeaponBuff>(), 2);
        }

        //I want to change this recipe with custom mod items later this is just a placeholder
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ItemID.LivingFireBlock, 5);
            r.AddIngredient(ItemID.IronBar, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
