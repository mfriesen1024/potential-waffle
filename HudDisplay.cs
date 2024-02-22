using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class HudDisplay
    {
        Player player;
        public HudDisplay(Player player)
        {
            this.player = player;
            int currentPlayerHealth = player.CurrentHealth;
            int playerAttackValue = player.AttackValue;
            // the player instance that is referenced here must always be the player instance created with  static void CreatePlayerInstance() within Program.
            // HudDisplay will need to see player currenthealth and attack values
            // Effect the buffer class to change the colors of enemies and the player
            // Display a message whenever the player damages or becomes damaged by an enemy
        }
    }
}
