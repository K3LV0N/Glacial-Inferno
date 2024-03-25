using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private int aiUpdateTimer = 0;
        private bool shouldUpdateAI = true;

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
                aiUpdateTimer++;

                if (aiUpdateTimer >= 120)
                {
                    shouldUpdateAI = !shouldUpdateAI;
                    aiUpdateTimer = 0;
                }

                if (shouldUpdateAI)
                {
                    base.AI(npc);
                }
            }
            else
            {
                aiUpdateTimer = 0;
                shouldUpdateAI = true;
                base.AI(npc);
            }
        }
    }

}
