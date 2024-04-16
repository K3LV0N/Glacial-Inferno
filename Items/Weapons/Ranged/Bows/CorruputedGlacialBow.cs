using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Projectiles.Ammo.Arrows;

namespace glacial_inferno.Items.Weapons.Ranged.Bows
{
    public class CorruptedGlacialBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<CrimsonGlacialBow>());
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<GlacialArrowProjectile>();
            }
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.DemoniteBar, 20);
            r1.AddIngredient<GlacialBow>();
            r1.AddTile(TileID.Anvils);
            r1.AddCondition(Condition.InSnow);
            r1.Register();
        }
    }
}
