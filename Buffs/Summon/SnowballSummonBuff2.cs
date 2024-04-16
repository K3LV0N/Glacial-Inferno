using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;

namespace glacial_inferno.Buffs.Summon
{
    public class SnowballSummonBuff2 : SnowballSummonBuff
    {
        public float reviveTimer = 0f;
        public float reviveTime = 4f * 60;
        public bool revive = false;

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SnowballSummon2>()] > 0)
            {
                player.buffTime[buffIndex] = 6000;
                if (!revive)
                {
                    revive = true;
                }
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;

                if (revive)
                {
                    reviveTimer++;
                    if (reviveTimer > reviveTime)
                    {

                    }
                }
            }
        }
    }
}
