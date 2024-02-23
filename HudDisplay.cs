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
        private Player player;
        private ItemManager itemManager;

        private int HudX;
        private int HudY;
        private int HudWidth;
        private int HudHeight;
        public static List<string> messages;

        public HudDisplay(ItemManager itemManager)
        {
            itemManager.SetHud(this);
            CalculateHudPosition();
            this.player = player;
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        private void CalculateHudPosition()
        {
            int mapWidth = MapData.map.GetLength(1);
            int mapHeight = MapData.map.GetLength(0);
            int totalWidth = mapWidth + 3;
            int totalHeight = mapHeight + 1;
            HudWidth = (totalWidth / 2) + (totalWidth % 2);
            HudHeight = (totalHeight / 2) + (totalHeight % 2);
            HudX = HudWidth - 1;
            HudY = 1;
        }
        public void DrawHudMessages(List<string> messages)
        {
            foreach (string message in messages)
            {
                Console.SetCursorPosition(HudX, HudY);
                Console.WriteLine(message);
                HudY++;
                if (HudY == HudHeight)
                {
                    if (messages.Count >= HudHeight)
                    {
                        Console.SetCursorPosition(HudX, HudY - messages.Count);
                        Console.Write(new string(' ', HudWidth));
                        messages.RemoveAt(0); 
                    }
                }
            }
        }
        public static void AddScore(int scoreToAdd)
        {
            TotalScore += scoreToAdd;
        }
    }
}
