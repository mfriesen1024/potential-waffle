using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Item
    {
        Player player;
        Buffer buffer;

        int xPos;
        int yPos;
        public bool Collected = false;

        public Item(Player player, Buffer buffer)
        {
            this.player = player;
            this.buffer = player.buffer;
        }

        public int[] GetItemXY()
        {
            int[] pos = new int[2];
            pos[0] = xPos;
            pos[1] = yPos;
            return pos;
        }
        public void SetItemXY(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
        public void DrawItem()
        {
            if (!Collected)
            {
                buffer.secondBuffer[yPos, xPos] = Settings.HealthChar;
            }
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        public void RemoveItem(Item item)
        {
            ItemManager.AllItemsList.Remove(this);
        }
        public void UseItem()
        {
            GetItemXY();
            if (xPos == Player.playerRow && yPos == Player.playerCol) 
            {
                player.Heal(20);
                Collected = true;
                buffer.secondBuffer[yPos, xPos] = ' ';
                RemoveItem(this);
            }
        }
    }
}
