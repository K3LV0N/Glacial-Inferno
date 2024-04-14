using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class Bubonico : ModItem
    {
        private bool StatusMode = false; 
        public override void SetDefaults()
        {
            Item.width = 44; 
            Item.height = 18; 
            Item.rare = ItemRarityID.Green; 

            
            Item.useTime = 4; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 12; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.reuseDelay = 15; 
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.autoReuse = true; 
            Item.UseSound = SoundID.Item36; 

            Item.DamageType = DamageClass.Ranged; 
            Item.damage = 40; 
            Item.knockBack = 6f; 
            Item.noMelee = true; 
            Item.consumeAmmoOnLastShotOnly = true;

            Item.shoot = ProjectileID.PurificationPowder; 
            Item.shootSpeed = 16f; 
            Item.useAmmo = AmmoID.Bullet;
        }

        public override bool AltFunctionUse(Player player)
        { 
            return true;
        }
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                StatusMode = !StatusMode;
                return false;
            }

            if (StatusMode == false)
            {
                int NumProjectiles2 = 1;
                //Item.useAmmo = AmmoID.Rocket;
                for (int i = 0; i < NumProjectiles2; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    Terraria.Projectile.NewProjectileDirect(source, position, newVelocity, ProjectileID.ClusterRocketI, damage, knockback, player.whoAmI);
                   
                }

                return false;
            }

            else 
            {
                int NumProjectiles = 8;
                //Item.useAmmo = AmmoID.Bullet;
                for (int i = 0; i < NumProjectiles; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    Terraria.Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }
                return false; 
            }

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2f, -2f);
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.IllegalGunParts, 3);
            r1.AddIngredient(ItemID.Minishark, 1);
            r1.AddIngredient(ItemID.Hellstone, 40);
            r1.AddIngredient(ItemID.SnowballCannon, 1);
            r1.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
            r1.AddTile(TileID.TinkerersWorkbench);
            r1.Register();
        }
    }
}
