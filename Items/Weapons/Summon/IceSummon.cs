using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;
using glacial_inferno.Buffs.Summon;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace glacial_inferno.Items.Weapons.Summon
{
    public class IceSummon : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 0;
            Item.knockBack = 2f;
            Item.mana = 5;

            Item.noMelee = true;
            Item.autoReuse = true;
            Item.notAmmo = true;
            Item.maxStack = 1;

            Item.width = 26;
            Item.height = 26;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.shoot = ModContent.ProjectileType<SnowballSummon>();
            Item.shootSpeed = 10;

            Item.buffType = ModContent.BuffType<SnowballSummonBuff>();
            Item.buffTime = 3600;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            // Add crafting recipes for the item if desired
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        /*
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(true);
                return false;
            }

            return true;
        }
        */
    }
}
