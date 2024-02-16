using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;

namespace glacial_inferno.Buffs.Summon
{
    public class SnowballSummonBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            SnowballSummonPlayer modPlayer = player.GetModPlayer<SnowballSummonPlayer>();
            if (player.ownedProjectileCounts[ModContent.ProjectileType<SnowballSummon>()] > 0)
            {
                modPlayer.snowballSummon = true;
            }

            if (!modPlayer.snowballSummon) 
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 3600;
            }
        }
    }

    public class SnowballSummonPlayer : ModPlayer
    {
        public bool snowballSummon;

        public override void ResetEffects()
        {
            snowballSummon = false;
        }
        public override void PostUpdateMiscEffects()
        {
            Player.maxMinions = snowballSummon ? 3 : 0;
        }
    }
}
