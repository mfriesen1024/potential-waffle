using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class HudDisplay
    {
        public static int TotalScore;
        Player player;
        public HudDisplay(Player player)
        {
            this.player = player;
            int currentPlayerHealth = player.CurrentHealth;
            int playerAttackValue = player.AttackValue;
            int playerX = Settings.playerRow;
            int playerY = Settings.playerCol;
        }
        public static void AddScore(int scoretoadd)
        {
            TotalScore += scoretoadd;
        }
    }
}
