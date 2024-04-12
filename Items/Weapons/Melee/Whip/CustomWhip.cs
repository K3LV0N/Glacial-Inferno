using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using rail;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using glacial_inferno.Items.Weapons.Projectile;

namespace glacial_inferno.glacial_inferno.Items.Weapons.Melee.Whip
{
    public class CustomWhip : ModItem
    {

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.SummonMeleeSpeed;
            Item.damage = 10;
            Item.knockBack = 1;
            Item.rare = ItemRarityID.Green;

            Item.shoot = ModContent.ProjectileType<CustomWhipProjectile>();
            Item.shootSpeed = 4;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.UseSound = SoundID.Item152;
            Item.noMelee = true; //potentially set to false 
            Item.noUseGraphic = true;
        }


        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddTile(TileID.Anvils);
            r1.AddIngredient(ItemID.IceBlock, 40);
            r1.AddIngredient(ItemID.Cobweb, 30);
            r1.Register();
        }


        // Makes the whip receive melee prefixes
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}


