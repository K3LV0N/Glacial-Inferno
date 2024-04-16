using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using glacial_inferno.Buffs.Summon;
using System;

namespace glacial_inferno.Projectiles.Weapons.Summon
{
    public class SnowballSummon2 : SnowballSummon
    {
        public override int jumpCooldown { get { return 45; } }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.minionSlots = 0.25f;
            Projectile.width = 24;
            Projectile.height = 18;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Skip applying the buff effects for bosses or ice biome mobs
            if (target.boss || target.buffImmune[BuffID.Frostburn])
            {
                return;
            }
            target.AddBuff(ModContent.BuffType<FrozenBuff>(), 4 * 60);
            target.AddBuff(ModContent.BuffType<PermaFreezeBuff>(), 60 * 60);
            Projectile.Kill();
        }
    }
}
