using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Ammo.Other
{
    public class ColdCuts : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.consumable = true;
            Item.DamageType = DamageClass.Ranged;
            Item.ammo = Item.type;
           
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
