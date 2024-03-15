using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna;
using Terraria.ObjectData;

namespace glacial_inferno.Items.Other.Blocks
{
    public class bitterFrostOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.addTile(Type);
            Main.tileLighted[Type] = true;
            //Main.
            //Main.
            //DustType = ;
            //AddMapEntry(new Color(200, 200, 200));
        }

    }
}
