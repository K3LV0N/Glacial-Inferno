using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using rail;

namespace glacial_inferno.Items.Weapons.Melee.Sword
{
    public class Monkey : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 26; //26 px wide
            Item.height = 26; //26 px tall
            Item.useTime = 18; //shoots a projectile every 18 frames
            Item.useAnimation = 18; //the item itself is visible for 18 frames (no frame where it's invisible if you use auto-fire) and has a displayed use time of 18
            Item.useStyle = 5; //animates like a gun (staff because of what we did in SetStaticDefaults)
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 0, 5, 0); //if you buy it in a shop, it would cost 5 silver, but it would be 1/5 if you sold it, so it has a sell price of 1 silver
            Item.rare = 0; //white rarity
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<MonkeyArrow>();
            Item.shootSpeed = 12; //projectile has a velocity of 12
            Item.notAmmo = true;
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.DirtBlock, 1);
            r1.Register();
        }
    }

    public class MonkeyArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 0; //projectile moves in a straight line
            Projectile.friendly = true;
            Projectile.timeLeft = 600; //projectile lasts for 10 seconds 
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.rotation = 1.57f;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height); //makes dust based on tile
            //Main.PlaySound(SoundID.Item10, Projectile.position); //plays impact sound
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 15, Projectile.velocity.X * -0.5f, Projectile.velocity.Y * -0.5f);   //spawns dust behind it, this is a spectral light blue dust
        }
    }
}

