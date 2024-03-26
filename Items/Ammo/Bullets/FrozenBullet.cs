using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Buffs;
using glacial_inferno.Projectiles.Ammo.Bullets;

namespace glacial_inferno.Items.Ammo.Bullets
{
    internal class FrozenBullet : ModItem
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
            Item.shoot = ModContent.ProjectileType<FrozenBulletProj>();
            Item.shootSpeed = 10;
            Item.value = 30;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {

            int buffType = ModContent.BuffType<Frozen>();


            base.OnHitNPC(player, target, hit, damageDone);
            target.AddBuff(buffType, 600);
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.MusketBall, 20);
            recipe1.AddIngredient(ItemID.IceBlock);

            recipe1.AddTile(TileID.Anvils);
            recipe1.ReplaceResult(ModContent.ItemType<FrozenBullet>(), 20);

            recipe1.Register();
        }
    }
}
