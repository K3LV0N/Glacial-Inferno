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
            int shotTime = 15;
            float velocity = 15f;
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
            int angle = 45;
            int spread = 30; //The angle of random spread.
            float spreadMult = 0.1f; //M
    

            for (int i = 0; i < 5; i++)
            {
                float offset = MathHelper.ToRadians(angle);
                Vector2 relVelo = relPos.RotatedBy(offset);
            //    float vX = velocity.X * ((float)Math.Cos(angle * (Math.PI / 180)));
              //  float vY = velocity.Y * ((float)Math.Sin(angle * (Math.PI / 180)));

                float vX = velocity.X * ((float)Math.Sin(angle * (Math.PI / 180)));
                float vY = velocity.Y * ((float)Math.Sin(angle * (Math.PI / 180)));
                Projectile.NewProjectile(source, position.X, position.Y, relVelo.X, relVelo.Y, type, damage, knockback);

             //   Projectile.NewProjectile(source, position.X, position.Y, vX, vY, type, damage, knockback);
                angle -= 15;
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
