using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace untitled.Map
{
    internal class Tile
    {
        public char character = ' ';
        public ConsoleColor foreground = ConsoleColor.White, background = ConsoleColor.Black;
        public int hazard = 0;
    }
}
