using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Items.Ammo.Other;
using glacial_inferno.Projectiles.Ammo.Other;

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

            Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)

            //make sure weapon only works with cold cuts !!

            Item.useAmmo = ModContent.ItemType<ColdCuts>();
            Item.shoot = ModContent.ProjectileType<ColdCutProjectile>();
            Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
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
