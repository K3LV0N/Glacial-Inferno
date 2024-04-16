using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Items.Other
{
    //A crafting material dropped in the underworld in hardmode
    public class LavaFragment : ModItem
    {
        public override void SetDefaults()
        {
           Item.maxStack = 9999;
           Item.rare = ItemRarityID.LightRed; 
        }
    }
}
