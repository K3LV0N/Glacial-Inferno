using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Projectiles.Ammo.Other;
using System;

// Define the namespace for the modded items, specifically ranged weapons
namespace glacial_inferno.Items.Weapons.Ranged.Other
{
    // Declare a new class InfernoBlower that inherits from ModItem to represent a custom weapon
    public class InfernoBlower : ModItem
    {
        private double manaAccumulator = 0; // A variable to accumulate fractional mana costs

        // Set the default properties for the item
        public override void SetDefaults()
        {
            Item.damage = 1; // The damage dealt by the weapon
            Item.useTime = 5; // The time in frames between uses of the weapon
            Item.useAnimation = 5; // The animation time in frames for using the weapon
            Item.knockBack = 0f; // The knockback effect of the weapon
            Item.noMelee = true; // Indicates that the item is not a melee weapon
            Item.notAmmo = true; // Indicates that the item is not ammo
            Item.DamageType = DamageClass.Magic; // Sets the damage type to Magic
            Item.useStyle = ItemUseStyleID.Shoot; // The style of using the item (shooting)
            Item.value = 20000; // The value of the item in copper coins
            Item.autoReuse = true; // Allows the item to be used repeatedly when holding down the mouse button
            Item.width = 25; // The width of the item's hitbox
            Item.height = 18; // The height of the item's hitbox

            // Projectile settings
            Item.shoot = ProjectileID.SnowBallFriendly; // The ID of the projectile shot by this weapon
            Item.shootSpeed = 10f; // The speed at which the projectile is fired
        }

        // Offset the weapon to align with the player's hand
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5, 0); // Move the weapon 5 pixels to the right when held
        }

        // Logic that runs when the player tries to use the item
        public override bool CanUseItem(Player player)
        {
            // If the player has no mana, prevent the item from being used
            if (player.statMana == 0)
            {
                return false;
            }
            // Otherwise, consume a small amount of mana and allow the item to be used
            manaAccumulator += 0.1; // Increment the accumulator by a fraction of mana
            if (manaAccumulator >= 1) // Check if a whole mana point has been accumulated
            {
                player.statMana -= 1; // Consume 1 mana from the player
                manaAccumulator = 0; // Reset the accumulator
            }
            return true; // Allow the item to be used
        }

        // Logic that runs when the item is used to shoot a projectile
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Calculate the rotation based on the direction of the velocity
            float rotation = (float)Math.Atan2(velocity.Y, velocity.X);

            // Create the projectile and get its index
            int projectileIndex = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<InfernoBlowerProjectile>(), damage, knockback, player.whoAmI);
            Projectile projectile = Main.projectile[projectileIndex];

            // Set the rotation of the projectile to match the calculated rotation
            projectile.rotation = rotation;

            // Adjust the sprite direction if necessary
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += MathHelper.Pi; // Rotate the sprite by 180 degrees
            }

            // Return false because we manually create the projectile and don't want the default behavior
            return false;
        }

        // Defines the recipe for crafting the InfernoBlower
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IronBar, 10) // Requires 10 Iron Bars
                .AddIngredient(ItemID.Torch, 50) // Requires 50 Torches
                .AddIngredient(ItemID.IllegalGunParts, 1) // Requires 1 Illegal Gun Parts
                .AddTile(TileID.Anvils) // Must be crafted at an Anvil
                .Register(); // Registers the recipe
        }
    }
}
