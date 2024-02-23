using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

//https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Content/Items/Armor/ExampleHelmet.cs use as reference



namespace glacial_inferno.Items.Armor.BasicIceArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class IceArmorHelmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.headSlot = 1;
            Item.width = 18;
            Item.height = 18;
            Item.defense = 1;
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
            return body.type == ModContent.ItemType<IceArmorBreastplate>() && legs.type == ModContent.ItemType<IceArmorLeggings>();
        }


        // UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player) {
			player.GetDamage(DamageClass.Generic) += 10 / 100f; // Increase dealt damage for all weapon classes by 20%
		}
    }
}
