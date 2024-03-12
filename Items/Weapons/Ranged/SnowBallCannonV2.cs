using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class SnowBallCannonV2 : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee.
            // See ExampleGun.SetDefaults to see comments explaining those properties
            Item.DefaultToRangedWeapon(ProjectileID.PurificationPowder, AmmoID.Snowball, 5, 16f, true);
            Item.useAnimation = 15;
            Item.useTime = 3; 
            Item.reuseDelay = 13;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.useAmmo = ItemID.Snowball; 

            // Item.SetWeaponValues can quickly set damage, knockBack, and crit
            Item.SetWeaponValues(11, 1f);

            Item.width = 54; // Hitbox width of the item.
            Item.height = 22; // Hitbox height of the item.
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.DirtBlock, 1);
            //r1.AddIngredient(ItemID.IllegalGunParts, 2);
            //r1.AddIngredient(ItemID.Minishark, 1);
            //r1.AddIngredient(ItemID.IceBlock, 100);
            //r1.AddIngredient(ItemID.SnowballCannon, 1);
            //r1.AddTile(TileID.TinkerersWorkbench);
            r1.Register();
        }

        // The following method gives this gun a 75% chance to not consume ammo
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.75f;
        }


        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -2f);
        }

        public override bool CanRightClick()
        { 
            return base.CanRightClick();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 8; // The number of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                // Create a projectile.
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }


    }
}