using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Melee
{
    public class EarlyIceSword : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.knockBack = 6;
            Item.DamageType = DamageClass.Melee;


            Item.width = 27;
            Item.height = 32;

            Item.useTime = 20;
            Item.useAnimation = Item.useTime;
            Item.UseSound = SoundID.Item1;

            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 15, 10);


            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}