// using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Buffs;

namespace glacial_inferno.Projectiles.Ammo
{
    public class IcySnowballProjectile : ModProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SnowBallFriendly);
            // Projectile.width = 12;
            // Projectile.height = 12;
            AIType = ProjectileID.SnowBallFriendly;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            // LUKE KISSLING MADE THIS BUFF NOT ME -RYAN
            target.AddBuff(ModContent.BuffType<Frozen>(), 600);
        }
    }
}