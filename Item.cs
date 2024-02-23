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
        MapData mapData;
        Buffer buffer;

        int xPos;
        int yPos;

        public char HealthPickupChar = Settings.HealthChar;
        public string[] PickUpItems = new string[]
        {
        "☙", "PlaceHolder ATK buff", "PlaceHolder another buff"
        };
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

        // DrawItem()

        public bool Collected;
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
            char charValue = buffer.secondBuffer[Settings.playerCol, Settings.playerRow];
            switch (charValue) 
            {
                case Settings.HealthChar:
                    player.Heal(20);
                    Collected = true;
                    buffer.secondBuffer[Settings.playerCol, Settings.playerRow] = ' ';
                    RemoveItem(this);
                break;
                    // case item char cases
            }
        }

    }
}
