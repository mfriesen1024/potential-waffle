using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Item
    {
        public char HealthPickupChar;
        Item()
        { 
        HealthPickupChar = Settings.HealthChar;
        }
    }
}
