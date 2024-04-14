using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.glacial_inferno.Projectiles;

namespace glacial_inferno.glacial_inferno.Items.Ammo.Bullets
{
    internal class EndlessSnowBallPouch : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;
            Item.ammo = AmmoID.Snowball;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.damage = 10;
            Item.knockBack = 1.5f;
            Item.shoot = ProjectileID.SnowBallFriendly;
            Item.shootSpeed = 10;
            Item.value = 30;
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.Snowball, 3996);
            r1.AddTile(TileID.WorkBenches);
            r1.Register();
        }

    }
}
