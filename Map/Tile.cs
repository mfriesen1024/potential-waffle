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

        // We'll use this to convert from settings things
        public static explicit operator Tile(char c)
        {
            Tile t = new() {character = c };
            switch (c)
            {
                case '╭':
                case '─':
                case '╮':
                case '╯':
                case '╰':
                case '│':
                case '┘':
                case '┌':
                case '┐':
                case '└':
                case '├':
                case '┤':
                case '┬':
                case '┴':
                    t.foreground = ConsoleColor.DarkMagenta;
                    t.hazard = 1; // 1 means its a wall.
                    break;
                case '☻':
                    t.foreground = ConsoleColor.Blue;
                    break;
                case '╳':
                    t.foreground = ConsoleColor.DarkGray;
                    break;
                case Settings.DuckChar:
                case Settings.GooseChar:
                case Settings.LionChar:
                    t.foreground = ConsoleColor.Green;
                    break;
                case '░':
                case '╦':
                case '╠':
                case '╣':
                case '╩':
                case '╬':
                case '═':
                    t.foreground = ConsoleColor.White; // white means they will be replaced with blanks when certain keys are obtained
                    t.hazard = 1; // 1 means its a wall.
                    break;
                case 'H':
                case 'A':
                    t.foreground = ConsoleColor.Red;
                    break;
                case Settings.key0c:
                case Settings.key1c:
                case Settings.key2c:
                case Settings.key3c:
                case Settings.key4c:
                case Settings.key5c:
                case Settings.key6c:
                    t.foreground = ConsoleColor.Cyan;
                    break;
            }

            return t;
        }
    }
}
