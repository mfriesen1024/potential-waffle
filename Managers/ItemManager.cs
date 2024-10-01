using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Map;

namespace untitled.Managers
{
    internal class ItemManager
    {
        CBuffer buffer;
        MapData mapData;
        Player player;
        HudDisplay hudDisplay;
        static internal List<Item> AllItemsList = new List<Item>();

        public ItemManager(CBuffer buffer, MapData mapData, Player player, HudDisplay hudDisplay)
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
                item.DrawItem();
            }
        }
        public void SetHud(HudDisplay hudDisplay)
        {
            this.hudDisplay = hudDisplay;
        }
        public void SpreadItems(CBuffer buffer) // does not place items on the map just makes them and provides XY
        {
            Utils.Print("Spawning items");
            int randomX, randomY;
            for (int i = 0; i < Settings.itemCount; i++)
            {
                randomX = Settings.random.Next(8, 77);
                randomY = Settings.random.Next(8, 27);
                while (!MapData.map[randomY, randomX].Equals(new()))
                {
                    randomX = Settings.random.Next(8, 77);
                    randomY = Settings.random.Next(8, 27);
                }
                Item item = new Item(player, buffer);
                item.SetItemXY(randomX, randomY);
                AllItemsList.Add(item);
                Utils.Print($"Added item {i+1} of {Settings.itemCount} at position {randomX}, {randomY}");
            }
        }
    }
}

