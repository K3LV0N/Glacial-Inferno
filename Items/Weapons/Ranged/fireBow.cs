using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using glacial_inferno.Projectiles;


namespace glacial_inferno.Items.Weapons.Ranged
{
    public class fireBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 1.5f;
            Item.shootSpeed = 10f;
            Item.autoReuse = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 80, 0);
            Item.rare = ItemRarityID.Blue;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item5;

            Item.width = 10;
            Item.height = 30;

            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;

            //Change to custom projectile
            Item.shoot = AmmoID.Arrow;
            Item.useAmmo = AmmoID.Arrow;

        }

        //turns the arrows into fire arrows
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<Projectiles.fireArrow>();
        }

        //Need to think about this needs to be somewhat expensive
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.Register();
        }
    }
}