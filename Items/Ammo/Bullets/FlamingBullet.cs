using glacial_inferno.Projectiles.Ammo.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Ammo.Bullets
{
    internal class FlamingBullet : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 30;
            Item.height = 30;
            Item.ammo = AmmoID.Bullet;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.damage = 10;
            Item.knockBack = 2;
            Item.shoot = ModContent.ProjectileType<FlamingBulletProj>();
            Item.shootSpeed = 10;
            Item.value = 30;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 3600);
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.MusketBall, 70);
            recipe1.AddIngredient(ItemID.Hellstone);

            recipe1.AddTile(TileID.Anvils);
            recipe1.ReplaceResult(ModContent.ItemType<FlamingBullet>(), 70);

            recipe1.Register();
        }
    }
}
