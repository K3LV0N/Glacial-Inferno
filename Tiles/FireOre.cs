using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace glacial_inferno.Tiles
{
    public class FireOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true; 
            Main.tileOreFinderPriority[Type] = 320; //Metal detector value
            Main.tileShine2[Type] = true; 
            Main.tileShine[Type] = 975; 
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            //Adds entry to the minimap
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(230, 50, 0), name);

            DustType = DustID.Lava; 
            HitSound = SoundID.Tink;

            MineResist = 1f; 
            MinPick = 50;
        }
    }

    public class FireOrePass : GenPass
    {
        public FireOrePass(string name, float loadWeight) : base(name, loadWeight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = FireOreSystem.FireOrePassMessage.Value;

            for (int i = 0; i < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); i++)
            {
                //randomly place a splosh of ore in the world 

                //Generate random x and y coords to place this splosh of ore
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<FireOre>());
            }
        }
    }

    public class FireOreSystem : ModSystem
    {
        public static LocalizedText FireOrePassMessage { get; private set; }

        public override void SetStaticDefaults()
        {
            FireOrePassMessage = Mod.GetLocalization($"WorldGen.{nameof(FireOrePassMessage)}");
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new FireOrePass("Fire Ore", 237.4298f));
            }
        }
    }
}


