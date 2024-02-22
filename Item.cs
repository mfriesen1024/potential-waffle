using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Item
    {

        public int Quantity { get; private set; }
        public char HealthPickupChar = '☙';
        Item(int quantity)
        { 
            HealthPickupChar = Settings.HealthChar;
            Quantity = quantity;

        }


    public void UseItem()
    {

        
    }

    }
}
