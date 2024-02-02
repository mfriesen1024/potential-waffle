using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Buffer
    {
        public char[,] ?firstBuffer;
        public char[,] ?secondBuffer;

        private MapData mapData;

        public void SetMapData(MapData mapData) // This tells MapData what Buffer is, could fix later but its funny to think about.
        {
            this.mapData = mapData;
        }

        public void DisplayBuffer() // Manages the buffer/screen refresh so I don't have a seizure playing my game.
        {
            for (int Y = 0; Y < firstBuffer?.GetLength(0); Y++)
            {

                for (int X = 0; X < firstBuffer.GetLength(1); X++)
                {
                    char MapElements = secondBuffer[Y, X];
                        
                    if (MapElements == firstBuffer[Y, X])
                    {
                        continue;
                    }
                    int Top = Y + 1;
                    int Left = X + 1;
                    switch (MapElements)
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
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '☻':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case '☙':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '♣':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '⅛':
                        case '⅜':
                        case '⅝':
                        case '⅞':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.SetCursorPosition(Left, Top);
                    Console.Write(MapElements); 
                }
            }
            Array.Copy(firstBuffer, secondBuffer, mapData.map.Length);
        }
    }
}