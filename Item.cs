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
        public char HealthPickupChar = '☙';

        internal Item()
        { 
            HealthPickupChar = Settings.HealthChar;
        }
        public void SpreadItems(MapData mapData, Buffer buffer)
        {
            int randomX, randomY;
            for (int i = 0; i < Settings.itemCount; i++)
            {
                do
                {
                    randomX = Settings.random.Next(1, 77);
                    randomY = Settings.random.Next(1, 27);
                    buffer.secondBuffer[randomY, randomX] = Settings.HealthChar;
                } while (mapData.map[randomY, randomX] != ' ');
            } 
        }
        public string[] PickUpItems = new string[]
        {
        "☙", "PlaceHolder ATK buff", "PlaceHolder another buff" 
        };
        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void UseItem(Player player)
        {

        
        }

    }
}
