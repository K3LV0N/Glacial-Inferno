using glacial_inferno.Items.Ammo.Bullets;
using glacial_inferno.Items.Other;
using Terraria;
using Terraria.GameContent.ItemDropRules;
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

                // sold in snow biome
                shop.Add(ModContent.ItemType<FrozenBullet>(), Condition.InSnow);

                // sold in the caverns
                shop.Add(ModContent.ItemType<FlamingBullet>(), Condition.InRockLayerHeight);
            }
        }


        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            //Drop the custom lava fragement item from these enemies in hardmode only
            if (npc.type == NPCID.Hellbat || npc.type == NPCID.Lavabat)
                {
                ItemDropWithConditionRule dropInHardmodeOnly =  new ItemDropWithConditionRule( ModContent.ItemType<LavaFragment>(),8,1,2, new Conditions.IsHardmode());
                npcLoot.Add(dropInHardmodeOnly);
            }
            
        }
    }
}
