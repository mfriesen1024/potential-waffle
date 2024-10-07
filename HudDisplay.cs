using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Managers;
using untitled.Map;

namespace untitled
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
        private int UIWidth;
        private int UIHeight;
        public static List<string> Status = new();
        public static List<string> messages = new();

        public HudDisplay(ItemManager itemManager)
        {
            itemManager.SetHud(this);
            CalculateHudPosition();
        }
        public static void Init()
        {
            DisplayFirstObjective();

            void DisplayFirstObjective()
            {
                messages.Add($"The next key is key number {1}, and should look-");
                messages.Add($"-like a {Settings.key0c}");
            }
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

            UIWidth = (totalWidth / 4) + (totalWidth % 4);
            UIHeight = (totalHeight / 4) + (totalHeight % 4);
            UIX = totalWidth + 1;
            UIY = totalHeight - UIHeight - 2;
            UIXY[0] = UIX;
            UIXY[1] = UIY;
            return UIXY;
        }

        public void DrawUIMessages()
        {
            Console.ResetColor();

            int[] UIXY = UIPosition();

            UIY = UIXY[1];
            UIX = UIXY[0];
            foreach (string status in Status)
            {
                Console.SetCursorPosition(UIX, UIY);
                Console.WriteLine(status);
                UIY++;
            }
        }

        public void DrawHudMessages()
        {
            Console.ResetColor();

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

                string newMessage = message;

                int remainder = HudWidth + 8 - message.Length;
                for (int i = 0; i < remainder; i++)
                    newMessage += ' ';

                Console.WriteLine(newMessage);
                HudY++;
            }
        }
        public static void OneUpCheck()
        {
            //if (TotalScore / (100 * Settings.playerLevel) >= 1)
            //{ 
            //    Settings.playerLevel++;
            //    TotalScore = 0;
            //}
        }
        public static int AddScore(int scoreToAdd)
        {
            TotalScore += scoreToAdd;
            OneUpCheck();
            return scoreToAdd;
        }
    }
}
