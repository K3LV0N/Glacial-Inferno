using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Buffs
{
    public class MeltedIce: ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            base.SetStaticDefaults();
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += (float) 1.0;
            base.Update(player, ref buffIndex);
        }
    }
}
