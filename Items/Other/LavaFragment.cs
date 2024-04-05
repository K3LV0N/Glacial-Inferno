using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Other
{
    public class LavaFragment : ModItem
    {
        public override void SetDefaults()
        {
           Item.maxStack = 9999;
            Item.rare = 4;
        }
    }
}
