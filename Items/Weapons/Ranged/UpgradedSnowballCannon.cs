using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class UpgradedSnowballCannon : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useAmmo = AmmoID.Snowball;
            Item.shootSpeed = 16;
			Item.noMelee = true;
			// This value doesn't really matter, but must not be 0
			Item.shoot = ProjectileID.SnowBallFriendly;
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