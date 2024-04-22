using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Projectiles.Ammo.Other;
using System;

// Define a namespace for the modded items, specifically ranged weapons
namespace glacial_inferno.Items.Weapons.Ranged.Other
{
    // Declare a new class BlizzardBlower that inherits from ModItem to represent a custom weapon
    public class BlizzardBlower : ModItem
    {
        // Field to keep track of mana consumption over time
        private double manaAccumulator = 0;

        // Set the default properties for the BlizzardBlower item
        public override void SetDefaults()
        {
            Item.damage = 1; // The damage dealt by the weapon
            Item.useTime = 5; // Time in frames before the item can be used again
            Item.useAnimation = 5; // Duration of the item's use animation
            Item.knockBack = 0f; // Knockback strength of the weapon's projectiles
            Item.noMelee = true; // Indicates this is not a melee weapon
            Item.notAmmo = true; // Indicates this item is not considered ammo
            Item.DamageType = DamageClass.Magic; // Classifies the item as a magic weapon
            Item.useStyle = ItemUseStyleID.Shoot; // Sets the use style to shooting
            Item.value = 20000; // The value of the item in coins
            Item.autoReuse = true; // Allows the item to be automatically reused when holding down the mouse button
            Item.width = 43; // The width of the item's hitbox
            Item.height = 23; // The height of the item's hitbox

            // Projectile settings (values set arbitrarily)
            Item.shoot = ProjectileID.SnowBallFriendly; // ID of the projectile to shoot
            Item.shootSpeed = 10f; // Speed at which the projectile is fired
        }

        // Adjusts the position where the weapon is held by the player
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 10); // Offset position for holding the weapon
        }

        // Determines whether the item can be used by the player
        public override bool CanUseItem(Player player)
        {
            // Prevents use if the player has no mana left
            if (player.statMana == 0)
            {
                return false;
            }

            // Consumes a fraction of mana on each use and checks if enough has been accumulated to subtract 1 mana point
            manaAccumulator += 0.1;
            if (manaAccumulator >= 1)
            {
                player.statMana -= 1; // Subtract 1 mana point from the player's mana
                manaAccumulator = 0; // Reset the accumulator
            }
            return true; // Allow the item to be used
        }

        // Handles the creation and firing of the projectile when the weapon is used
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Calculate the rotation to match the direction of the velocity
            float rotation = (float)Math.Atan2(velocity.Y, velocity.X);

            // Create the projectile at the specified position with the calculated rotation
            Projectile projectile = Main.projectile[Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<BlizzardBlowerProjectile>(), damage, knockback, player.whoAmI)];

            // Set the rotation of the projectile to match the calculated rotation
            projectile.rotation = rotation;

            // If the projectile sprite direction is negative, adjust the rotation to flip the sprite
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += MathHelper.Pi;
            }

            // Return false because we don't want Terraria to shoot the projectile automatically
            return false;
        }

        // Defines the crafting recipe for the BlizzardBlower item
        public override void AddRecipes()
        {
            CreateRecipe() // Start defining a new recipe
                .AddIngredient(ItemID.IronBar, 10) // Requires 10 Iron Bars
                .AddIngredient(ItemID.SnowBlock, 50) // Requires 50 Snow Blocks
                .AddIngredient(ItemID.IceBlock, 50) // Requires 50 Ice Blocks
                .AddIngredient(ItemID.IllegalGunParts, 1) // Requires 1 Illegal Gun Parts
                .AddTile(TileID.Anvils) // Must be crafted at an Anvil
                .Register(); // Register the recipe in the game
        }
    }
}
