using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace glacial_inferno.Items.Weapons.Melee
{
    public class crimsonCold: ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.knockBack = 5;
            Item.noMelee = false;
            Item.notAmmo = true;
            Item.shoot = ProjectileID.RubyBolt;
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
            r1.AddIngredient(ItemID.CrimtaneBar, 10);
            r1.AddIngredient(ItemID.IceBlock, 20);
            r1.Register();
        }
    }
}
