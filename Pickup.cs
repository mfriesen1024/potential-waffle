using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Managers;
using untitled.Map;

namespace untitled
{
    internal class Pickup
    {
        Player player;
        CBuffer buffer;

        int xPos;
        int yPos;
        public bool Collected = false;

        public enum ItemType
        {
            health,
            key,
            buff
        }
        public ItemType itemType;

        public Pickup(Player player, CBuffer buffer)
        {
            this.player = player;
            this.buffer = player.buffer;
            DetermineType();
        }
         public void SetPlayer(Player player)
        {
            this.player = player;
        }
        void DetermineType()
        {
            int randomInt = Settings.random.Next(5);
            switch (randomInt)
            {
                case 0:
                case 1:
                case 2:
                    itemType = ItemType.health;
                    break;
                case 3:
                case 4:
                    itemType = ItemType.buff;
                    break;
            }
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
                Tile tileToDraw = null;
                switch(itemType)
                {
                    case ItemType.health:
                        tileToDraw = Settings.HealthTile;
                        break;
                    case ItemType.buff:
                        tileToDraw = Settings.BuffTile;
                        break;
                    default:
                        throw new NotImplementedException($"Item type {itemType} is not valid");
                }
                buffer.secondBuffer[yPos, xPos] = tileToDraw;
            }
        }
        public void RemoveItem(Pickup item)
        {
            PickupManager.AllPickups.Remove(this);
        }
        public void UseItem()
        {
            GetItemXY();
            switch (itemType)
            {
                case ItemType.health:
                    player.Heal(20 + 2*Settings.NPCLevel);
                    break;
                case ItemType.buff:
                    player.Buff();
                    break;
            }
            Collected = true;
            buffer.secondBuffer[yPos, xPos] = new();
            RemoveItem(this);
        }
    }
}
