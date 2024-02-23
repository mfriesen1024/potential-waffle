using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class ItemManager
    {
        Buffer buffer;
        MapData mapData;
        Player player;
        static internal List<Item> AllItemsList = new List<Item>();

        public ItemManager(Buffer buffer, MapData mapData, Player player)
        {
            this.mapData = mapData;
            this.buffer = buffer;
            this.player = player;
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        public void DrawItems()
        {
            foreach (var item in AllItemsList)
            {
                item.DrawItem(buffer);
            }
        }
        public void SpreadItems(MapData mapData, Buffer buffer) // does not place items on the map just makes them and provides XY
        {
            int randomX, randomY;
            for (int i = 0; i < Settings.itemCount; i++)
            {
                randomX = Settings.random.Next(1, 77);
                randomY = Settings.random.Next(1, 27);
                while (mapData.map[randomY, randomX] != ' ')
                {
                    randomX = Settings.random.Next(1, 77);
                    randomY = Settings.random.Next(1, 27);
                }
                Item item = new Item();
                item.SetItemXY(randomX, randomY);
                AllItemsList.Add(item); // And adds to list
            }
        }
    }
}

