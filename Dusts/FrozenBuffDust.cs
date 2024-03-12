using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Dusts
{
    public class FrozenBuffDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.frame = new Rectangle(0, Main.rand.Next(3)*8, 8, 8);
            dust.scale = .8f;
            // If our texture had 3 different dust on top of each other (a 30x90 pixel image), we might do this:
            // dust.frame = new Rectangle(0, Main.rand.Next(3) * 30, 30, 30);
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.scale -= 0.01f;

            if (dust.scale < 0.6f)
                dust.active = false;

            return false;
        }
    }
}