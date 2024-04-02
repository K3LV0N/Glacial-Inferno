using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Items.Ammo.Other;
using System;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class BlizzardBlower : ModItem
    {
        private double manaAccumulator = 0;
        //A weapon that "blows" bits of blizzard towards the enemy.
        //Shoots very many small projectiles that simulate wind
        //when projectiles hit they FrostBurn the enemy and "blow them back" 
        //as if they're being blown away by a blizzard
        //uses very small amount of mana as ammo

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.knockBack = 0f;
            Item.noMelee = true;
            Item.notAmmo = true;
            Item.DamageType = DamageClass.Magic;
            //Item.useAmmo = AmmoID.None;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 20000;
            //Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.width = 43;
            Item.height = 23;







            //dont matter so set to random values
            Item.shoot = ProjectileID.SnowBallFriendly; // Set this to the ID of the projectile you want to shoot
            Item.shootSpeed = 10f; // How fast the projectile is shot


        }

        //move the weapon to the player's hand
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 10);
        }

        //on use
        public override bool CanUseItem(Player player)
        {
            //if the player has no mana, return false
            if (player.statMana == 0)
            {
                return false;
            }
            //otherwise take some mana and return true
            manaAccumulator += 0.1;
            if (manaAccumulator >= 1)
            {
                player.statMana -= 1;
                manaAccumulator = 0;
            }
            return true;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            // Calculate the rotation to match the direction of the velocity
            float rotation = (float)Math.Atan2(velocity.Y, velocity.X);

            // Create the projectile at the specified position with the calculated rotation
            Projectile projectile = Main.projectile[Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<BlizzardBlowerProjectile>(), damage, knockback, player.whoAmI)];

            // Set the rotation of the projectile
            projectile.rotation = rotation;

            // Make sure the sprite faces the right way if it has a direction
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += MathHelper.Pi;
            }

            // Return false because we don't want Terraria to shoot the projectile automatically
            return false;
        }





    }
}