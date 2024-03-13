using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Buffs;
using System.Net.Cache;

namespace glacial_inferno.Items.Ammo
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
            Item.shoot = ModContent.ProjectileType<Projectiles.Other.FlamingBullet>();
            Item.shootSpeed = 10;
            Item.value = 30;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {

            base.OnHitNPC(player, target, hit, damageDone);
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
