using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.WorldBuilding;
using Terraria.IO;

namespace glacial_inferno.Items.Other;

public class BitterfrostOre : ModTile
{
    public override void SetStaticDefaults()
    {
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileID.Sets.Ore[Type] = true;

        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileOreFinderPriority[Type] = 280;
        Main.tileShine[Type] = 700;

        DustType = DustID.Ice;
        HitSound = SoundID.Item27; //Striking ice
        MinPick = 55;              //Requires Gold pickaxe and up
        MineResist = 1.2f;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 1;
        TileObjectData.newTile.StyleHorizontal = true;
        RegisterItemDrop(ModContent.ItemType<BitterfrostBlock>());
        TileObjectData.addTile(Type);

        LocalizedText ore_name = CreateMapEntryName();
        AddMapEntry(new Microsoft.Xna.Framework.Color(0, 150, 255), ore_name);

    }

}

public class BitterFrostOreSystem : ModSystem
{
    public static LocalizedText BitterFrostOrePassMessage { get; private set; }

    public override void SetStaticDefaults()
    {
        BitterFrostOrePassMessage = Mod.GetLocalization($"WorldGen.{nameof(BitterFrostOrePassMessage)}");
    }

    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

        if (ShiniesIndex != -1)
        {
            tasks.Insert(ShiniesIndex + 1, new BitterFrostOrePass("Frosty Ores", 237.4298f));
        }
    }

}

public class BitterFrostOrePass : GenPass
{
    public BitterFrostOrePass(string name, float loadWeight) : base(name, loadWeight)
    {

    }

    protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
    {
    
        //progress.Message = "Condensing sorrow";

        for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
        {
         
            int x = WorldGen.genRand.Next(0, Main.maxTilesX);
            int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);

   
            Tile tile = Framing.GetTileSafely(x, y);
            if (tile.HasTile && tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock) {
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 10), WorldGen.genRand.Next(2, 10), ModContent.TileType<BitterfrostOre>());
            }
        }
    }
}
