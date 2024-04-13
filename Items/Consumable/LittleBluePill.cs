using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Consumable
{   
    //Little Blue Pill
    //On consumption, grants complete invulnerability for 30 seconds, but
    //user cannot move at all and is inside a blue block as if they are frozen
	public class LittleBluePill : ModItem
	{
		public override void SetStaticDefaults() {
			//Item.ResearchUnlockCount = 5;

			// This allows you to change the color of the crumbs that are created when you eat.
			// The numbers are RGB (Red, Green, and Blue) values which range from 0 to 255.
			// Most foods have 3 crumb colors, but you can use more or less if you desire.
			// Depending on if you are making solid or liquid food switch out FoodParticleColors
			// with DrinkParticleColors. The difference is that food particles fly outwards
			// whereas drink particles fall straight down and are slightly transparent
			ItemID.Sets.FoodParticleColors[Item.type] = new Color[3] {
            new Color(30, 45, 150),   // A deep blue similar to Viagra's color
            new Color(60, 105, 180),  // A medium shade of blue
            new Color(130, 180, 220)  // A lighter shade of blue
        };

			ItemID.Sets.IsFood[Type] = true; //This allows it to be placed on a plate and held correctly
		}

		public override void SetDefaults() {
			// This code matches the ApplePie code.

			// DefaultToFood sets all of the food related item defaults such as the buff type, buff duration, use sound, and animation time.
			//Item.DefaultToFood(22, 22, BuffID.WellFed3, 57600); // 57600 is 16 minutes: 16 * 60 * 60
			Item.value = Item.buyPrice(0, 3);
			Item.rare = ItemRarityID.Blue;
            Item.width = 21;
            Item.height = 21;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 3);
            Item.rare = ItemRarityID.Blue;
            Item.buffType = ModContent.BuffType<Buffs.LittleBluePillBuff>();
            Item.buffTime = 1800; // 30 seconds
       
		}


		public override void OnConsumeItem(Player player) {
            
		}
        public override bool CanUseItem(Player player) {
            // Prevent use if buff is already active to avoid stacking effects
            return !player.HasBuff(Item.buffType);
        }

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Moonglow)
                .AddTile(TileID.Bottles)
                .Register();
		}
	}
}