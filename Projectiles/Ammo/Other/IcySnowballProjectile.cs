using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Buffs;

namespace glacial_inferno.Projectiles.Ammo.Other
{
    public class IcySnowballProjectile : ModSnowballProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Copy the defaults of the parent class
            base.SetDefaults();
            // set the size to match the texture of the icy snowball
            Projectile.width = 12;
            Projectile.height = 12;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            // LUKE KISSLING MADE THIS BUFF NOT ME -RYAN
            target.AddBuff(ModContent.BuffType<Frozen>(), 300);
        }
    }
}