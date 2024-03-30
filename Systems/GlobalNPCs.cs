using glacial_inferno.Items.Ammo.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Systems
{
    public class GlobalNPC_ : GlobalNPC
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
