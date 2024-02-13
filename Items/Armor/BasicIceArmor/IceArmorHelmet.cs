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
    public class IceArmorHelmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.headSlot = 1;
            Item.width = 40;
            Item.height = 40;
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
    }
}
