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
        public char HealthPickupChar = Settings.HealthChar;

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
        public void DrawItem(Buffer buffer)
        {
            Console.WriteLine("DrawItem is being called");
            if (!Collected)
            {
                buffer.secondBuffer[yPos, xPos] = HealthPickupChar;
                Console.WriteLine("Health Pick up has been put on buffer");
            }
            else
            { 
            Console.WriteLine("Draw Item Called but no pickup");
            }
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        public void RemoveItem(Item item)
        {
            ItemManager.AllItemsList.Remove(item);
        }
        public void UseItem()
        {
            char charValue = buffer.secondBuffer[Player.playerRow, Player.playerCol];
            if (charValue == Settings.HealthChar)
            {
                player.Heal(20);
                Collected = true;
                buffer.secondBuffer[yPos, xPos] = ' ';
                RemoveItem(this);
            }
        }
    }
}
