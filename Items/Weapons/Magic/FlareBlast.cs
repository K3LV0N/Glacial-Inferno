using glacial_inferno.Projectiles.Weapons.Magic;
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
            Item.useTime = 350;
            Item.useAnimation = 350;
            int shotTime = 40;
            float velocity = 4f;
            bool autoReuse = true;
            Item.DefaultToMagicWeapon(ModContent.ProjectileType<FlareBlastProj>(), shotTime, velocity, autoReuse);
            Item.mana = 7;
            Item.UseSound = SoundID.Item1;
            Item.damage = 10;
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mousePos = Main.MouseWorld;
            Vector2 relPos = mousePos - player.Center;
            int angle = 20;
        

            for (int i = 0; i < 5; i++)
            {
                float offset = MathHelper.ToRadians(angle);
                Vector2 relVelo = relPos.RotatedBy(offset);
          
                if (i == 2)
                {
                    Projectile.NewProjectile(source, position.X, position.Y, relVelo.X, relVelo.Y, ModContent.ProjectileType<BigFlareBlastProj>(), damage, knockback);
                  //  Projectile.NewProjectile(source, position.X, position.Y, relVelo.X, relVelo.Y, ModContent.ProjectileType<FlareBlastProj>(), damage, knockback);

                }
                else
                {
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
            r1.AddIngredient(ItemID.HellstoneBar, 12);
            r1.AddTile(TileID.Bookcases);
            r1.AddCondition(Condition.InUnderworld);
            r1.Register();
        }
    }
}
