using glacial_inferno.Items.Ammo.Arrows;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace glacial_inferno.Projectiles.Weapons.Magic
{
    public class IceBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.scale = 1.2f;
            Projectile.width = (int)(9f * Projectile.scale);
            Projectile.height = (int)(19f * Projectile.scale);

            Projectile.friendly = true;

            // aistyle is general, EX: ARROW
            // AiType is specific, EX: FIRE ARROW
            Projectile.aiStyle = ProjAIStyleID.Arrow;
        }

        public override bool PreAI()
        {
            Projectile.ai[1]++;
            if (Projectile.ai[1] % 3 == 0)
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Ice, 0f, 0f, 0, default, 0.8f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
