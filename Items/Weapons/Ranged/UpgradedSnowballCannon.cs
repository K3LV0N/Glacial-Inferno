using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class UpgradedSnowballCannon : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Clone the default values of the base game snowball cannon
            Item.CloneDefaults(ItemID.SnowballCannon);
            /* UNMODIFIED SNOWBALL CANNON DEFAULTS:
             * Damage class = ranged, Use style = shoot, Knock back = 1
             * Use sound = Item1, Auto reuse = true, Use ammo = Snowball
             * No melee = true
             * 
             * MODIFIED DEFAULTS (see code):
             * Damage = 10, Use time = 19, Shoot speed = 11,
             * Sell price = 2 gold, Rarity = Blue
             */
            // Increase this cannons damage
            Item.damage = 22;
            // Adjust the size to match its sprite
            Item.width = 26;
            Item.height = 13;
            // Decrease the cannon's use time
            Item.useTime = Item.useAnimation = 14;
            // Increase the cannon's value
            Item.value = Item.sellPrice(0, 4, 75, 0);
            // Increase the cannon's rarity
            Item.rare = ItemRarityID.Orange;
            // Increase the cannon's shoot speed
            Item.shootSpeed = 16;
        }

        public override Vector2? HoldoutOffset()
        {
            // adjust offset so player holds the weapon by the handle
            return new Vector2(5, 5);
        }

        public override void AddRecipes()
        {
            // This Item is crafted using an existing Snowball Cannon and 10 Hellstone Bars
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.SnowballCannon, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}