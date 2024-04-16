using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;
using glacial_inferno.Buffs.Summon;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace glacial_inferno.Items.Weapons.Summon
{
    public class IceSummon3 : IceSummon2
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.damage = 10;
            Item.knockBack = 3f;
            Item.mana = 20;

            Item.width = 30;
            Item.height = 49;
            
            Item.buffType = ModContent.BuffType<SnowballSummonBuff3>();
            Item.shoot = ModContent.ProjectileType<SnowballSummon3>();

            Item.value = Item.buyPrice(gold: 180);
            Item.value = Item.sellPrice(gold: 100);
            Item.rare = ItemRarityID.Purple;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<IceSummon2>(), 1);
            recipe.AddIngredient(ItemID.IceFeather, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
