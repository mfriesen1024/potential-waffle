using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Interfaces;

namespace untitled
{
    /// <summary>
    /// Represents an inventory item.
    /// </summary>
    internal class Item:ICustomCloneable<Item>
    {
        public int str = 0;
        public int price = 0;

        public Item(int str, int price)
        {
            this.str = str;
            this.price = price;
        }

        public Item Clone()
        {
            return new Item(str, price);
        }
    }
}
