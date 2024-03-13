using glacial_inferno.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Systems
{
    internal class GlobalNPC_ : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.ArmsDealer)
            {

                shop.Add(ModContent.ItemType<FrozenBullet>(), Condition.InSnow);
                shop.Add(ModContent.ItemType<FlamingBullet>(), Condition.InUnderworld);
            }
            base.ModifyShop(shop);
        }

   
    }
}
