using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class MapData
    {
        internal Buffer buffer;
        public static char[,] map;
        internal static int MapWidth;
        internal static int MapHeight;

        public MapData(Buffer buffer) // This is a constructor that does the funny spiderman pointing meme with Buffer.
        {
            this.buffer = buffer;
            buffer.SetMapData(this);
        }

        public void UIBorder()
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int totalWidth = (mapWidth + 3);
            int totalHeight = (mapHeight + 1);

            int hudWidth = (totalWidth / 4) + (totalWidth % 4);
            int hudHeight = (totalHeight / 4) + (totalHeight % 4);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;

            for (int i = totalWidth + 1; i < totalWidth + hudWidth - 1; i++)
            {
                Console.SetCursorPosition(i, totalHeight - hudHeight);
                Console.Write(border[5]); // Top border
                Console.SetCursorPosition(i, totalHeight);
                Console.Write(border[5]); // Bottom border
            }
            for (int j = totalHeight - hudHeight; j < totalHeight; j++)
            {
                Console.SetCursorPosition(totalWidth, j);
                Console.Write(border[4]); // Left border
                Console.SetCursorPosition(totalWidth + hudWidth - 1, j);
                Console.Write(border[4]); // Right border
            }
            Console.ResetColor(); // Reset console colors after drawing
        }

        public void HudBorder()
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int totalWidth = (mapWidth + 3);
            int totalHeight = (mapHeight + 1);

            int hudWidth = (totalWidth / 2) + (totalWidth % 2); 
            int hudHeight = (totalHeight / 2) + (totalHeight % 2);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            for (int i = totalWidth + 1; i < totalWidth + hudWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(border[5]); // Top border
                Console.SetCursorPosition(i, hudHeight);
                Console.Write(border[5]); // Bottom border
            }
            for (int j = 1; j < hudHeight; j++)
            {
                Console.SetCursorPosition(totalWidth, j);
                Console.Write(border[4]); // Left border
                Console.SetCursorPosition(totalWidth + hudWidth - 1, j);
                Console.Write(border[4]); // Right border
            }
            Console.ResetColor(); // Reset console colors after drawing
        }

        public void PrintMap()
        {  
            Array.Copy(map, buffer.secondBuffer, map.Length);
        }
        static string[] border = new string[] // Stores Border ASCII characters
        {
            "╔","╗","╝","╚", "║","═"
        };
        public string[] EnviromentalHazard = new string[] // Stores fractional ASCII characters used for Hazards
        {
            "⅛","⅜","⅝","⅞"
        };
        public void DrawBorder()
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int HorizontalWall = 1;
            int VerticalWall = 1;
            int totalWidth = (mapWidth + 1);
            int totalHeight = (mapHeight + 1);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            Console.SetCursorPosition(0, 0);
            Console.Write(border[0]);
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);
            if (HorizontalWall >= totalWidth)
            {
                HorizontalWall = totalWidth;
            }
            if (VerticalWall >= totalHeight)
            {
                VerticalWall = totalHeight;
            }
            for (int i = 0; i < totalWidth; i++)
            {
                Console.SetCursorPosition(HorizontalWall, 0); // ceiling
                Console.Write(border[5]);
                Console.SetCursorPosition(HorizontalWall, totalHeight); // floor
                Console.Write(border[5]);
                HorizontalWall++;
            }
            for (int j = 0; j < totalHeight; j++)
            {
                Console.SetCursorPosition(0, VerticalWall); // lefthand wall 
                Console.Write(border[4]);
                Console.SetCursorPosition(totalWidth, VerticalWall); // righthand wall 
                Console.Write(border[4]);
                VerticalWall++;
            }
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);
            Console.SetCursorPosition(0, totalHeight);
            Console.Write(border[3]);
            Console.SetCursorPosition(totalWidth, totalHeight);
            Console.Write(border[2]);
            Console.ResetColor();
        }
        public bool IsValidMove(int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < map.GetLength(1) && newCol >= 0 && newCol < map.GetLength(0))
            {
                switch (map[newCol, newRow])
                {
                    case ' ':
                    case '⅛':
                    case '⅜':
                    case '⅝':
                    case '⅞':
                    return true;
                    case '╭':case '─':case '╮': case '╯': case '╰':case '│': case '┘':case '┌': case '┐':case '└': case '├': case '┤':case '┬': case '┴':
                    return false;
                }
            }
            return false;
        }
        public void TxtFileToMapArray() 
        {
            string[] lines = File.ReadAllLines("Map.txt");
            buffer.firstBuffer = new char[lines.GetLength(0), lines[0].Length];
            buffer.secondBuffer = new char[lines.GetLength(0), lines[0].Length];
            map = new char[lines.GetLength(0), lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++) 
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j]; 
                }
            }
        }
    }
}