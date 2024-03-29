using glacial_inferno.Projectiles.Weapons.Ranged;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class PlasmaRailgun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 80;

            Item.width = 70;
            Item.height = 40;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 8;
            Item.value = Item.sellPrice(0, 10, 0, 0); // Adjust the sell price as needed
            Item.mana = 20;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PlasmaRailgunProj>(); // Change this to the projectile type you want
            Item.shootSpeed = 50f;
           
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.TitaniumBar, 10);
            r1.AddIngredient(ItemID.HellstoneBar, 10);
            r1.AddTile(TileID.MythrilAnvil);
            r1.Register();
        }
    }
}
