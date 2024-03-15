using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Projectiles.Ammo.Arrows;

namespace glacial_inferno.Items.Weapons.Ranged
{
    public class IceBow : ModItem
    {
        public override void SetDefaults()
        {
            int shotTime = 15;
            float velocity = 15f;
            bool autoReuse = true;
            Item.DefaultToBow(shotTime, velocity, autoReuse);
            Item.scale = 1.2f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<IceArrowProjectile>();
            }
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.IceBlock, 30);
            r1.AddTile(TileID.WorkBenches);
            r1.AddCondition(Condition.InSnow);
            r1.Register();
        }
    }
}
