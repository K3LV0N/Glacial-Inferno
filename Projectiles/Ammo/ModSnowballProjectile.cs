// using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace glacial_inferno.Projectiles.Ammo
{
    // An abstract class to parent all modded snowball projectiles, manages universal traits
    public abstract class ModSnowballProjectile : ModProjectile
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.glacial_inferno.hjson file.

        public override void SetDefaults()
        {
            // Copy the default properties of the base game snowball
            Projectile.CloneDefaults(ProjectileID.SnowBallFriendly);
            // set the AIType to follow the AI of the base game snowball
            AIType = ProjectileID.SnowBallFriendly;
        }

        public override void OnKill(int timeLeft)
        {
            base.OnKill(timeLeft);
            // Play the base game snowball's death sound (found SoundID on Terraria wiki)
            SoundEngine.PlaySound(SoundID.Item51);
            // Dust dust = Dust.CloneDust(DustID.SnowSpray);
        }
    }
}