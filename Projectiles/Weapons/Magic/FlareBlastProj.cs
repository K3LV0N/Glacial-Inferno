using Ionic.Zip;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles.Weapons.Magic
{
    public class FlareBlastProj : ModProjectile
    {
        
        public override void SetDefaults()
        {
            Projectile.scale = 1.2f;
            Projectile.width = (int)(9f * Projectile.scale);
            Projectile.height = (int)(19f * Projectile.scale);
            Projectile.ai[0] = 0;
            Projectile.friendly = true;

            Projectile.aiStyle = ProjAIStyleID.Arrow;
        }

        public override bool PreAI()
        {
            
            Projectile.ai[1]++;
            if (Projectile.ai[1] % 3 == 0)
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 0, default, 0.8f);
            }
            return true;
        }
   

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
