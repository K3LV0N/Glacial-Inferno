using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;

namespace glacial_inferno.Buffs.Summon
{
    public class SnowballSummonBuff3 : SnowballSummonBuff2
    {
        public override float reviveTime => 2 * 60f;
        public override int summonType => ModContent.ProjectileType<SnowballSummon3>();
        public override int buffType => ModContent.BuffType<SnowballSummonBuff3>();
        public override int damage => 10;
    }
}
