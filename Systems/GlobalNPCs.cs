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
             
                shop.Add(ModContent.ItemType<FrozenBullet>(), Condition.InSnow);
                shop.Add(ModContent.ItemType<FlamingBullet>(), Condition.InUnderworld);
            }
            base.ModifyShop(shop);
        }

        public override void ModifyGlobalLoot(GlobalLoot globalLoot)
        {
       
            base.ModifyGlobalLoot(globalLoot);
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Hellbat || npc.type == NPCID.LavaSlime || npc.type == NPCID.Lavabat)
            {
                ItemDropWithConditionRule rule = new ItemDropWithConditionRule(ModContent.ItemType<LavaFragment>(), 5, 1, 2,new Conditions.IsHardmode());
                npcLoot.Add(rule);
            }
            base.ModifyNPCLoot(npc, npcLoot);
        }
    }
}
