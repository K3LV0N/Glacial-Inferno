using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using glacial_inferno.Items.Other;
using glacial_inferno.Projectiles.Weapons.Melee;

namespace glacial_inferno.Items.Weapons.Melee
{
    public class CrimsonCold: ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.knockBack = 5;
            Item.noMelee = false;
            Item.notAmmo = true;
            Item.shoot = ModContent.ProjectileType<CrimsonIce>();
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
            r1.AddIngredient(ItemID.CrimtaneBar, 5);
            r1.AddIngredient(ModContent.ItemType<BitterfrostBar>(), 10);
            r1.AddTile(TileID.DemonAltar);
            r1.Register();
        }
    }
}
