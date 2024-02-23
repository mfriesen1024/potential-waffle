﻿using System;
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
                Console.WriteLine(message); // should be (message) but that will be a lot of things later
                // "tomato" will be used for testing this
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
