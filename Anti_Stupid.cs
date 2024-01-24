using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    // Use this example to determine if there is more than one instance of a class when there should not be.
    internal class Map
    {
        private static int count;

        public Map() 
        { 
        Debug.Assert(count == 0);
        
        }
    }
}
