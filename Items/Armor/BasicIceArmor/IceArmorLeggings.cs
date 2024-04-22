using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

//https://github.com/tModLoader/tModLoader/blob/1.4.4/ExampleMod/Content/Items/Armor/ExampleLeggings.cs use as reference


namespace glacial_inferno.Items.Armor.BasicIceArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class IceArmorLeggings : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 3;
            Item.rare = ItemRarityID.White;
            base.SetDefaults();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
