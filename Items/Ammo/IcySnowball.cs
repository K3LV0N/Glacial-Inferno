using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Ammo;

namespace glacial_inferno.Items.Ammo
{
    public class IcySnowball : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 10;
			Item.ammo = AmmoID.Snowball;
			Item.consumable = true;
            Item.useTime = Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = true;
            Item.knockBack = 5.75f;
            // Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item1;
            Item.shootSpeed = 7;
			Item.shoot = ModContent.ProjectileType<IcySnowballProjectile>();
			Item.maxStack = 9999;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);
			recipe.AddIngredient(ItemID.IceBlock, 4);
            recipe.AddIngredient(ItemID.SnowBlock, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}