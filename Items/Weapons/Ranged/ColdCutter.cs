using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

//gun that shoots frozen cold cuts; could be called the Deliblaster
//if i finish everything fast, add a mechanic that heats the cold cuts and does some fire damage

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class ColdCutter : ModItem
    {
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 44; // Hitbox width of the item.
            Item.height = 18; // Hitbox height of the item.
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

            //make sure weapon only works with cold cuts !!
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
