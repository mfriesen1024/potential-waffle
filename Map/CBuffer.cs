using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace untitled.Map
{
    internal class CBuffer
    {
        public char[,]? firstBuffer;
        public char[,]? secondBuffer;
        private MapData mapData;
        public void SetMapData(MapData mapData)
        {
            this.mapData = mapData;
        }

        public void DisplayBuffer()
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
                        case '╳':
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                        case Settings.DuckChar:
                        case Settings.GooseChar:
                        case Settings.LionChar:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '░':
                        case '╦':
                        case '╠':
                        case '╣':
                        case '╩':
                        case '╬':
                        case '═':
                            Console.ForegroundColor = ConsoleColor.White; // white means they will be replaced with blanks when certain keys are obtained
                            break;
                        case Settings.HealthChar:
                        case Settings.BuffChar:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case Settings.key0:
                        case Settings.key1:
                        case Settings.key2:
                        case Settings.key3:
                        case Settings.key4:
                        case Settings.key5:
                        case Settings.key6:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                    }
                    Console.SetCursorPosition(Left, Top);
                    Console.Write(MapElements);
                }
            }
            Array.Copy(firstBuffer, secondBuffer, MapData.map.Length);
        }
    }
}