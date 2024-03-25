using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;
using glacial_inferno.Buffs.Summon;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace glacial_inferno.Items.Weapons.Summon
{
    public class IceSummon2 : IceSummon
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.damage = 5;
            Item.knockBack = 3f;
            Item.mana = 10;
            
            Item.buffType = ModContent.BuffType<SnowballSummonBuff2>();
            Item.shoot = ModContent.ProjectileType<SnowballSummon2>();

            Item.value = Item.buyPrice(gold: 60);
            Item.value = Item.sellPrice(gold: 50);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            //recipe.AddIngredient(ModContent.ItemType<IceSummon>(), 1);
            //recipe.AddIngredient(ItemID.FrostCore, 1);
            //recipe.AddIngredient(ItemID.IceFeather, 1);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
