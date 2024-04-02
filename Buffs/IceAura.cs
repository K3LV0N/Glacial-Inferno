using glacial_inferno.Dusts;
using glacial_inferno.Projectiles.Other;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace glacial_inferno.Buffs
{
    public class IceAura: ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            base.SetStaticDefaults();
        }

        //check to see if enemy is in radius of the player
        //if they are, slow them and do DOT
        public override void Update(Player player, ref int buffIndex)
        {

            //Vector2 spawnPosition = player.Center + new Vector2(Main.rand.Next(-50, 51), Main.rand.Next(-50, 51));
            //Vector2 spawnVelocity = new Vector2(0f);
            //int projectileType = ModContent.ProjectileType<IceAuraProjectile>();
            //Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), spawnPosition, spawnVelocity, projectileType, 0, 0);
            for (int i = 0; i < Main.npc.Length; i++)
            {
                NPC nPC = Main.npc[i];
                Vector2 distance = player.Center - nPC.Center;
                if (nPC.active && !nPC.friendly && !nPC.dontTakeDamage && !nPC.CountsAsACritter && distance.Length() <= 75f && !nPC.dontTakeDamage)
                {
                    nPC.AddBuff(BuffID.Chilled, 120);
                    nPC.AddBuff(BuffID.Frostburn, 120);
                }
            }
            // Create visual effects
            if (Main.rand.NextBool(4)) // Adjust frequency of dust creation
            {
                Dust.NewDust(player.position, player.width, player.height, DustID.SnowflakeIce, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, default(Color), 1.5f); // Adjust dust parameters
            }

            base.Update(player, ref buffIndex);
        }
    }


}
