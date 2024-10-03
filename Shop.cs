using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace untitled
{
    /// <summary>
    /// Defines a location where the player can purchase items.
    /// </summary>
    internal class Shop
    {
        public int x, y; // position.
        public Item[] inventory;

        public Shop(int x, int y, Item[] inventory)
        {
            this.x = x;
            this.y = y;
            this.inventory = inventory;
        }
    }
}
