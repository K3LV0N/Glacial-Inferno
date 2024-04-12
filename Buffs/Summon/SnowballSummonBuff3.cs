using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;

namespace glacial_inferno.Buffs.Summon
{
    public class SnowballSummonBuff3 : SnowballSummonBuff2
    {
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SnowballSummon3>()] > 0)
            {
                player.buffTime[buffIndex] = 7200;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
