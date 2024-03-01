using glacial_inferno.Items.Armor.BasicIceArmor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace glacial_inferno.Items.Armor.BasicIceMageArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class IceMageHelmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 2;
            Item.rare = ItemRarityID.White;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<IceMageBreastplate>() && legs.type == ModContent.ItemType<IceMageLeggings>();
        }


        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You're in tune with your Ice Cape! Gain 50 More Mana!";
            player.statManaMax2 += 50; // Increase dealt damage for all weapon classes by 20%
        }
    }
}
