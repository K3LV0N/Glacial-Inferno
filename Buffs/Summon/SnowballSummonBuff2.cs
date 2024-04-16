using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;
using glacial_inferno.Items.Weapons.Summon;

namespace glacial_inferno.Buffs.Summon
{
    public class SnowballSummonBuff2 : SnowballSummonBuff
    {
        public override float reviveTime => 4 * 60f;
        public override int summonType => ModContent.ProjectileType<SnowballSummon2>();
        public override int buffType => ModContent.BuffType<SnowballSummonBuff2>();
        public override int damage => 5;
    }
}
