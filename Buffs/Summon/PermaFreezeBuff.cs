using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Buffs.Summon
{
    public class PermaFreezeBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.position.X -= (npc.velocity.X * .5f);
            if (npc.gravity == 0)
            {
                npc.position.Y -= (npc.velocity.Y * .5f);
            }
        }
    }
}
