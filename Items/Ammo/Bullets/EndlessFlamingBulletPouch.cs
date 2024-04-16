using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles;
using glacial_inferno.Projectiles.Ammo.Bullets;

namespace glacial_inferno.Items.Ammo.Bullets
{
    internal class EndlessFlamingBulletPouch : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.ammo = AmmoID.Bullet;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.damage = 10;
            Item.knockBack = 2;
            Item.shoot = ModContent.ProjectileType<FlamingBulletProj>();
            Item.shootSpeed = 10;
            Item.value = 30;
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ModContent.ProjectileType<FlamingBulletProj>(), 3996);
            r1.AddTile(TileID.WorkBenches);
            r1.Register();
        }

    }
}
