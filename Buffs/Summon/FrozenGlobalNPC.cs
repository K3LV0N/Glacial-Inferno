using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Buffs.Summon
{
    public class FrozenGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        //Frozen Buff
        private int originalAIStyle = -1;
        private int originalDamage = -1;
        public bool isFrozen = false;

        //Perma Freeze
        private const float maxDistance = 500f;
        public DateTime buffAppliedTime { get; set; }
        private float minTime = 8f;
        private bool isPermaFrozen = false;

        public override void SetDefaults(NPC npc)
        {
            buffAppliedTime = DateTime.MinValue; // Initialize to a minimum value
        }

        public override void ResetEffects(NPC npc)
        {
            if (!npc.HasBuff(ModContent.BuffType<FrozenBuff>()))
            {
                isFrozen = false;
                if (originalAIStyle >= 0)
                {
                    npc.aiStyle = originalAIStyle;
                    npc.damage = originalDamage;
                    originalAIStyle = -1;
                    originalDamage = -1;
                }
            }
        }

        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 position, Color drawColor)
        {
            //Applies a blue tint to represent that it is perma frozen
            if (npc.HasBuff(ModContent.BuffType<PermaFreezeBuff>()))
            {
                Texture2D texture = Terraria.GameContent.TextureAssets.Npc[npc.type].Value;
                Vector2 drawPosition = npc.position - Main.screenPosition + new Vector2(npc.width / 2, npc.height - texture.Height * npc.scale / Main.npcFrameCount[npc.type] + 4f);
            
                Rectangle frame = npc.frame;

                Color color = new Color(0, 118, 214, 200);
                spriteBatch.Draw(texture, drawPosition, frame, color, npc.rotation, npc.frame.Size() / 2, npc.scale, SpriteEffects.None, 0f);

                return false;
            }

            return true;
        }

        public override void AI(NPC npc)
        {
            if (npc.HasBuff(ModContent.BuffType<FrozenBuff>()))
            {
                if (!isFrozen)
                {
                    originalAIStyle = npc.aiStyle;
                    originalDamage = npc.damage;
                    isFrozen = true;
                }
                npc.aiStyle = 0;
                npc.damage = 0;
            }

            if (npc.HasBuff(ModContent.BuffType<PermaFreezeBuff>()))
            {
                if (!isPermaFrozen)
                {
                    buffAppliedTime = DateTime.UtcNow;
                    isPermaFrozen = true;
                }
            }
            else
            {
                isPermaFrozen = false;
            }

            int buffId = ModContent.BuffType<PermaFreezeBuff>();
            int buffIndex = npc.FindBuffIndex(buffId);

            //Disables the buff
            if (buffIndex != -1)
            {
                TimeSpan elapsed = DateTime.UtcNow - buffAppliedTime;
                if (elapsed.TotalSeconds >= 8)
                {
                    foreach (Player player in Main.player)
                    {
                        if (player.active && !player.dead)
                        {
                            float distance = Vector2.Distance(player.Center, npc.Center) / 16;
                            if (distance > maxDistance)
                            {
                                npc.DelBuff(buffIndex);
                                break;
                            }
                        }
                    }
                }
            }
        }

        //Disables the Perma Freeze Debuff if it gets hit by the Player
        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            RemoveBuff(npc);
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.owner == Main.myPlayer && Main.player[projectile.owner].active)
            {
                RemoveBuff(npc);
            }
        }

        private void RemoveBuff(NPC npc)
        {
            TimeSpan elapsed = DateTime.UtcNow - buffAppliedTime;

            if (elapsed.TotalSeconds >= minTime && isPermaFrozen)
            {
                int buffIndex = npc.FindBuffIndex(ModContent.BuffType<PermaFreezeBuff>());
                if (buffIndex != -1)
                {
                    npc.DelBuff(buffIndex);
                }
                isPermaFrozen = false;
            }
        }
    }

}
