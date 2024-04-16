using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Ranged.Guns
{
    public class GreatWhite : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToRangedWeapon(ProjectileID.PurificationPowder, AmmoID.Snowball, 5, 16f, true);
            Item.useAnimation = 15;
            Item.useTime = 5;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.useAmmo = ItemID.Snowball;

            Item.SetWeaponValues(15, 1f);

            Item.width = 54;
            Item.height = 22;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item11;
        }


        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.IllegalGunParts, 1);
            r1.AddIngredient(ItemID.Minishark, 1);
            r1.AddIngredient(ItemID.IceBlock, 100);
            r1.AddIngredient(ItemID.SnowballCannon, 1);
            r1.AddTile(TileID.TinkerersWorkbench);
            r1.Register();
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= 0.75f;
        }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -2f);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }



    }
}