using Ionic.Zip;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using glacial_inferno.Dusts;

namespace glacial_inferno.Projectiles.Weapons.Magic
{
    public class BigFlareBlastProj : ModProjectile
    {
     
        public override void SetDefaults()
        {
            Projectile.scale = 1.5f;
            Projectile.width = (int)(9f * Projectile.scale);
            Projectile.height = (int)(19f * Projectile.scale);
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.light = .5f;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.penetrate = 4;
           
        }

        public override bool PreAI()
        {
            //Spawns dusts 
            for (int i = 0; i < 2; i++)
            {
                Random rand = new Random();
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, ModContent.DustType<FlareBlastDust>(), 0f, 0f, 0, default, 1+(float)rand.NextDouble());
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 0, default, .25f + (float)rand.NextDouble());

            }
            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
        }
    }
}
