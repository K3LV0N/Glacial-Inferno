using Terraria;
using Terraria.ModLoader;
using glacial_inferno.Projectiles.Weapons.Summon;
using glacial_inferno.Items.Weapons.Summon;
using Microsoft.Xna.Framework;

namespace glacial_inferno.Buffs.Summon
{
    public class SnowballSummonBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public float reviveTimer = 0f;
        public bool revive = false;

        public virtual float reviveTime => 8f * 60;
        public virtual int summonType => ModContent.ProjectileType<SnowballSummon>();
        public virtual int buffType => ModContent.BuffType<SnowballSummonBuff>();
        public virtual int damage => 1;

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[summonType] > 0)
            {
                player.buffTime[buffIndex] = 3600;
                if (!revive)
                {
                    revive = true;
                }
            }
            else
            {
                if (revive)
                {
                    reviveTimer++;
                    if (reviveTimer > reviveTime)
                    {
                        revive = false;
                        Vector2 spawnPosition = player.Center;
                        Vector2 velocity = Vector2.Zero;
                        Projectile.NewProjectileDirect(player.GetSource_FromThis(), spawnPosition, velocity, summonType, 0, 0, player.whoAmI).originalDamage = damage;
                    }
                }
            }
        }
    }
}
