using glacial_inferno.Projectiles.Ammo.Arrows;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Ammo.Arrows
{
    public class GlacialArrow : ModItem
    {
        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.damage = 7;
            Item.knockBack = 1;
            Item.crit = 4;
            Item.maxStack = 9999;
            Item.value = Terraria.Item.buyPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<GlacialArrowProjectile>();
            Item.ResearchUnlockCount = 99;
        }
        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.WoodenArrow, 50);
            recipe1.AddIngredient(ItemID.IceBlock, 10);
            recipe1.ReplaceResult(this, 50);
            recipe1.AddCondition(Condition.InSnow);
            recipe1.Register();
        }
    }
}
