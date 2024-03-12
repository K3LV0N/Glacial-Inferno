using glacial_inferno.Dusts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Buffs 
{
    public class Frozen : ModBuff
    {
        
        public override void Update(NPC npc, ref int buffIndex)
        {
            for (int i = 0; i < 1; i++) {
                Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<FrozenBuffDust>());
          
            }
            npc.position.X -= (npc.velocity.X * .2f);
            if (npc.gravity == 0)
            {
                npc.position.Y -= (npc.velocity.Y * .2f);
            }

        }
        
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FrozenPlayer>().PlayerHasFrozenBuff = true;
            player.position.X -= (player.velocity.X * .1f);
            
            base.Update(player, ref buffIndex);
        }
        
        
        
        
    }
    public class FrozenPlayer : ModPlayer
    {
        public bool PlayerHasFrozenBuff;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (PlayerHasFrozenBuff)
            {
                target.AddBuff(ModContent.BuffType<Frozen>(), 600);
            }
        }
        public override void ResetEffects()
        {
            PlayerHasFrozenBuff = false;
        }
    }
    public class FrozenEnemy : NPC
    {
        public bool NPCHasFrozenDebuff;

    }

}
