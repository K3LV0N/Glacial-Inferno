using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace glacial_inferno.NPCs
{
    public abstract class BasicNPC : ModNPC
    {
        // this class contains some helpful functions for 
        // enemies that we may want to use a multitude of times


        /// <summary>
        /// <para><c>InertiaMove</c> is a function that moves an enemy accounting for inertia, leading to organic movement.</para> 
        /// <paramref name="inertia"/> needs to be greater than 1.<br />
        /// <paramref name="speed"/> is the TOTAL speed.<br />
        /// <paramref name="xDirection"/> is the direction.<br />
        /// </summary>
        public virtual void InertiaMove(float speed, float inertia, int xDirection)
        {
            Vector2 direction = new Vector2(xDirection, 0);
            direction.Normalize();
            direction *= speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + direction) / inertia;

        }
    }
}
