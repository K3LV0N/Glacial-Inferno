using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using glacial_inferno.Buffs;
namespace glacial_inferno.Items.Other
{
    public class FlaskOfFreezing :ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 17;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.consumable = true;
            Item.value = 100;
            Item.buffType = ModContent.BuffType<Frozen>(); 
            Item.buffTime = 60*60*5; // Buff duration in ticks, 60 ticks = 1 second
        }
        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.BottledWater);
            r1.AddIngredient(ItemID.Shiverthorn);
            r1.AddIngredient(ItemID.IceBlock);
            r1.AddTile(TileID.Bottles);
            r1.Register();
        }

    }

}

