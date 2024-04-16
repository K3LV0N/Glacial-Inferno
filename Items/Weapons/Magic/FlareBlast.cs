using glacial_inferno.Projectiles.Weapons.Magic;
using glacial_inferno.Items.Other;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Net.Cache;

namespace glacial_inferno.Items.Weapons.Magic
{
    public class FlareBlast : ModItem
    {
        public override void SetDefaults()
        {
            
            int shotTime = 35;
            float velocity = 4f;          
            int mana = 9;
            Item.DefaultToStaff(ModContent.ProjectileType<FlareBlastProj>(), velocity, shotTime, mana);

            Item.crit = 25;
            Item.damage = 50;
            Item.staff[Type] = true;
            Item.rare = ItemRarityID.LightRed;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -5);
           
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mousePos = Main.MouseWorld;
            Vector2 relPos = mousePos - player.Center;
            int angle = 20;
        
            //Spawns 5 projectiles in an arc
            for (int i = 0; i < 5; i++)
            {
                float offset = MathHelper.ToRadians(angle);
                Vector2 relVelo = relPos.RotatedBy(offset);
          
                if (i == 2)
                {
                    //Spawns a big projectile in the middle
                    Projectile.NewProjectile(source, position.X, position.Y, relVelo.X, relVelo.Y, ModContent.ProjectileType<BigFlareBlastProj>(), damage, knockback);
                } else {
                    Projectile.NewProjectile(source, position.X, position.Y, relVelo.X, relVelo.Y, type, damage, knockback);
                }

                angle -= 10;
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ModContent.ItemType<LavaFragment>(),15);
            r1.AddIngredient(ItemID.HellstoneBar, 20);
            r1.AddIngredient(ItemID.Obsidian, 10);
            r1.AddTile(TileID.Anvils);

            r1.Register();
        }
    }
}
