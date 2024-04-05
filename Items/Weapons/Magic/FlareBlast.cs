using glacial_inferno.Projectiles.Weapons.Magic;
using glacial_inferno.Items.Other;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Magic
{
    public class FlareBlast : ModItem
    {
        public override void SetDefaults()
        {
        
            int shotTime = 25;
            float velocity = 5f;
            bool autoReuse = true;
            Item.DefaultToMagicWeapon(ModContent.ProjectileType<FlareBlastProj>(), shotTime, velocity, autoReuse);
            Item.mana = 7;
            Item.UseSound = SoundID.Item1;
            Item.damage = 50;
            
            
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
            r1.AddIngredient(ItemID.Book);
            r1.AddIngredient(ModContent.ItemType<LavaFragment>(),20);
            r1.AddIngredient(ItemID.HellstoneBar, 20);
            r1.AddTile(TileID.Bookcases);
            r1.AddCondition(Condition.InUnderworld);
            r1.Register();
        }
    }
}
