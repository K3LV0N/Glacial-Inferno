using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Buffs
{
    public class IceAura: ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            base.SetStaticDefaults();
        }

        //check to see if enemy is in radius of the player
        //if they are, slow them and do DOT
        public override void Update(Player player, ref int buffIndex)
        {
            for (int i = 0; i < 600; i++)
            {
                if 
            }
            base.Update(player, ref buffIndex);
        }
    }


}
