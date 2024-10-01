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

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Tile) { return false; }
            else
            {
                Tile t = obj as Tile;

                if(character != t.character) { return false; }
                if(foreground != t.foreground) { return false; }
                if(background != t.background) { return false; }
                if(hazard != t.hazard) { return false; }

                // if nothing doesn't match, then it must be the same object.
                return true;
            }
        }
    }
}
