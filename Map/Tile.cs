using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Interfaces;

namespace untitled.Map
{
    internal class Tile : ICustomCloneable<Tile>
    {
        public char character = ' ';
        public ConsoleColor foreground = ConsoleColor.White, background = ConsoleColor.Black;
        public int hazard = 0;

        public Tile Clone()
        {
            return new Tile() { character = character, background = background, foreground = foreground, hazard = hazard };
        }
    }
}
