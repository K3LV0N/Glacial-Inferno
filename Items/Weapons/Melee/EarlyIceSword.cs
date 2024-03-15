using glacial_inferno.Projectiles.Weapons.Magic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Weapons.Melee
{
    public class EarlyIceSword : ShatterItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.knockBack = 3;
            Item.DamageType = DamageClass.Melee;

            Item.scale = 1.5f;
            Item.width = (int)(27f * Item.scale);
            Item.height = (int)(32f * Item.scale);

            Item.useTime = 25;
            Item.useAnimation = Item.useTime;
            Item.UseSound = SoundID.Item1;

            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 15, 10);


            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
        }

      
        public override void AddRecipes()
        {

            Recipe r1 = CreateRecipe();
            r1.AddIngredient(ItemID.IceBlock, 30);
            r1.AddTile(TileID.Anvils);
            r1.AddCondition(Condition.InSnow);
            r1.Register();
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            int projectileAmount = 3;
            int damage = 3;
            int min = 30;
            int max = 150;
            float vel = 2f;
            float knockBack = 0.5f;
            float yoffset = 10;

            BasicShatter<IceBolt>(target, projectileAmount, damage, min, max, vel, knockBack, yoffset);
        }
    }
}