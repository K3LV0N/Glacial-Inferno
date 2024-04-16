using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace glacial_inferno.Projectiles.Weapons.Magic
{
    public class GlacialBoltShatter : SpecialProjectile
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int projAmt = 3;
            int dmg = damageDone / 2;
            int minAng = 30;
            int maxAng = 150;
            float startingVel = Projectile.velocity.Length() / 4;
            float yOffset = 10;
            BasicShatter<GlacialBolt>(target, projAmt, dmg, minAng, maxAng, startingVel, Projectile.knockBack, yOffset);
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
