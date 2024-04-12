using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace glacial_inferno.Projectiles.Weapons.Melee
{
    public class CorruptedIce : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Sickle;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 26;
            Projectile.height = 19;
            //Projectile.Hitbox.
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            Projectile.ai[1] += 1f;
            if (Projectile.ai[0] >= 10f)
            {
                Projectile.ai[0] = 0f;
                Projectile.netUpdate = true;
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GemAmethyst,
                    Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, Colors.RarityPurple, 0.7f);
            }

            if (Projectile.ai[1] % 15 == 0)
            {
                Projectile.ai[1] = 0f;
                Projectile.velocity.X += Projectile.velocity.X * 0.2f;
                Projectile.velocity.Y += Projectile.velocity.Y * 0.2f;
            }
        }

        //public override void Kill(int timeLeft)
        //{
            
        //}

    }
}
