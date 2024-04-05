using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace glacial_inferno.Dusts
{
    public class FrozenBuffDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= .8f;
            dust.noGravity = true;
            dust.frame = new Rectangle(0, Main.rand.Next(3)*8, 8, 8);   //Randomly selects one of the three dust sprites to spawn
            dust.scale = .7f;
        }

        public override bool Update(Dust dust)
        {
            //Shrinks the dust and deletes it when it reaches a certain size
            dust.position += dust.velocity;
            dust.scale -= 0.01f;

            if (dust.scale < 0.6f)
                dust.active = false;

            return false;
        }
    }
}