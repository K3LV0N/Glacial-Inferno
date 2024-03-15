using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno
{
    internal class testing : ModSystem
    {
        private bool devBranch = true;

        public override void AddRecipes()
        {   
            // Allows creation of any item from glacial inferno
            // to be made from thin air
            if(devBranch)
            {
                int maxItems = ItemLoader.ItemCount;
                for (int i = 0; i < maxItems; i++)
                {
                    ModItem item = ItemLoader.GetItem(i);

                    if (item != null && item.Mod is glacial_inferno)
                    {
                        Recipe testRecipe = Recipe.Create(i, 1);
                        testRecipe.Register();

                    }
                }
            }
        }
    }
}
