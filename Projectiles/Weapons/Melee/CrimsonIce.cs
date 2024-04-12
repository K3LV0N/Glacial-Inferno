using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace glacial_inferno.Projectiles.Weapons.Melee
{
    public class CrimsonIce : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Sickle;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 26;
            Projectile.height = 28;
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            Projectile.ai[1] += 1f;
            Projectile.ai[2] += 1f;

            if (Projectile.ai[0] >= 10f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemRuby,
                    Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, Colors.RarityRed, 0.7f);
            }

            if (Projectile.ai[1] % 12 == 0)
            {
                Projectile.ai[1] = 0f;
                Projectile.velocity.X *= 0.8f;
                Projectile.velocity.Y *= 0.8f;
            }

            if (Projectile.ai[2] > 60 && (Projectile.velocity.X < 0.01f && Projectile.velocity.X > -0.01f))
            {
                Projectile.ai[2] = 0f;
                Projectile.Kill();
            }
        }


    }
}
