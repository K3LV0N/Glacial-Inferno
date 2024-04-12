using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Ranged.Guns
{
    public class ChilledRepeater : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.knockBack = 1;
            Item.noMelee = true;
            Item.notAmmo = true;
            Item.shoot = ProjectileID.Bullet;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Bullet;
            Item.rare = ItemRarityID.Blue;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 20000;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.width = 43;
            Item.height = 23;
        }


        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.IceBlock, 20);
            r1.AddIngredient(ItemID.SilverBar, 10);
            r1.AddTile(TileID.Anvils);
            r1.Register();

            Recipe r2 = CreateRecipe();
            r2.AddIngredient(ItemID.IceBlock, 20);
            r2.AddIngredient(ItemID.TungstenBar, 10);
            r2.AddTile(TileID.Anvils);
            r2.Register();
        }
    }
}
