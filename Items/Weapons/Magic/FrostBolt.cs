using glacial_inferno.Projectiles.Weapons.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Magic
{
    public class FrostBolt : ModItem
    {
        public override void SetDefaults()
        {
            int shotTime = 15;
            float velocity = 15f;
            bool autoReuse = true;
            Item.DefaultToMagicWeapon(ModContent.ProjectileType<GlacialBoltShatter>(), shotTime, velocity, autoReuse);
            Item.mana = 7;
            Item.UseSound = SoundID.Item1;
            Item.damage = 10;
        }

        public override void AddRecipes()
        {
            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.Book);
            r1.AddIngredient(ItemID.IceBlock, 25);
            r1.AddTile(TileID.Bookcases);
            r1.AddCondition(Condition.InSnow);
            r1.Register();
        }
    }
}
