using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Buffs
{
    public class LittleBluePillBuff : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true; // Cannot be canceled
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.immune = true; // Player is invulnerable to damage
            player.controlLeft = false; // Disables left movement
            player.controlRight = false; // Disables right movement
            player.controlUp = false; // Disables up/jump movement
            player.controlDown = false; // Disables down movement
            player.controlJump = false; // Disables jumping
            player.controlUseItem = false; // Disables using items
            player.velocity = Vector2.Zero; // Stops any player movement
            
            // Surround player with a blue block visual (purely cosmetic)
            for (int i = 0; i < 8; i++) {
                Vector2 position = player.Center + new Vector2(Main.rand.Next(-1, 2), Main.rand.Next(-1, 2)) * 16;
                Dust.NewDustPerfect(position, Terraria.ID.DustID.Ice, Vector2.Zero, 150, Color.Blue, 1.5f);
            }
        }
    }
}
