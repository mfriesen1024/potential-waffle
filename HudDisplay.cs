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
        private int UIX;
        private int UIY;
        private int HudWidth;
        private int HudHeight;
        public static List<string> Status = new();
        public static List<string> messages = new();

        public HudDisplay(ItemManager itemManager)
        {
            itemManager.SetHud(this);
            CalculateHudPosition();
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        public int[] CalculateHudPosition()
        {
            int[] HudXY = new int[2];
            int mapWidth = MapData.map.GetLength(1);
            int mapHeight = MapData.map.GetLength(0);
            int totalWidth = mapWidth + 3;
            int totalHeight = mapHeight + 1;
            HudWidth = (totalWidth / 2) + (totalWidth % 2);
            HudHeight = (totalHeight / 2) + (totalHeight % 2);
            HudX = totalWidth + 1;
            HudY = 1;
            HudXY[0] = HudX;
            HudXY[1] = HudY;
            return HudXY;
        }
        private int[] UIPosition()
        {
            int[] UIXY = new int[2];
            int mapWidth = MapData.map.GetLength(1);
            int mapHeight = MapData.map.GetLength(0);
            int totalWidth = (mapWidth + 3);
            int totalHeight = (mapHeight + 1);

            int hudWidth = (totalWidth / 4) + (totalWidth % 4);
            int hudHeight = (totalHeight / 4) + (totalHeight % 4);
            UIX = totalWidth + 1;
            UIY = 1;
            UIXY[0] = HudX;
            UIXY[1] = HudY;
            return UIXY;
        }

        public void DrawUIMessages()
        {
            int[] UIXY = UIPosition();

            UIY = UIXY[1];
            UIX = UIXY[0];
            foreach (string Status in messages)
            {
                Console.SetCursorPosition(UIX, UIY);
                Console.WriteLine(Status);Console.WriteLine(Status);
                UIY++;
            }
        }

        public void DrawHudMessages()
        {
            if (messages.Count >= HudHeight)
            {
                messages.RemoveAt(0);
            }

            int[] HudXY = CalculateHudPosition();

            HudY = HudXY[1];
            HudX = HudXY[0];
            foreach (string message in messages)
            {
                Console.SetCursorPosition(HudX, HudY);
                Console.WriteLine(message); // not 200
                HudY++;
            }
        }
        public static int AddScore(int scoreToAdd)
        {
            TotalScore += scoreToAdd;
            return scoreToAdd;
        }
    }
}
