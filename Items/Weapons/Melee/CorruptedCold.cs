using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace glacial_inferno.Items.Weapons.Melee
{
    public class CorruptedCold : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.knockBack = 4;
            Item.noMelee = false;
            Item.notAmmo = true;
            Item.shoot = ProjectileID.SapphireBolt;
            Item.shootSpeed = 10;
            Item.DamageType = DamageClass.Melee;
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 20000;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.width = 40;
            Item.height = 36;
        }
        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.DemoniteBar, 15);
            r1.AddIngredient(ItemID.IceBlock, 20);
            r1.AddTile(TileID.DemonAltar);
            r1.Register();
        }
    }
}
