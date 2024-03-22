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
        
        public int numKeyCollected = 0;

        public MapData(Buffer buffer)
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

            int hudWidth = (totalWidth / 2) + (totalWidth % 2);
            int hudHeight = (totalHeight / 3) + (totalHeight % 3);
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
            Console.ResetColor();
        }
        public void HudBorder()
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int totalWidth = mapWidth + 3;
            int totalHeight = mapHeight + 5;

            int hudWidth = (totalWidth / 2) + (totalWidth % 2) + 10;
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
            Console.ResetColor();
        }
        public void PrintMap()
        {
            Array.Copy(map, buffer.secondBuffer, map.Length);
        }
        static string[] border = new string[]
        {
            "╔","╗","╝","╚", "║","═"
        };
        public void DrawBorder()
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int HorizontalWall = 1;
            int VerticalWall = 1;
            int totalWidth = mapWidth + 1;
            int totalHeight = mapHeight + 1;

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
        public bool IsValidMove(int newRow, int newCol) // Handles what the player is permitted to walk on.
        {
            if (newRow >= 0 && newRow < map.GetLength(1) && newCol >= 0 && newCol < map.GetLength(0))
            {
                switch (map[newCol, newRow])
                {
                    case ' ':
                    case Settings.BuffChar:
                    case Settings.HealthChar:
                    case Settings.key0:
                    case Settings.key1:
                    case Settings.key2:
                    case Settings.key3:
                    case Settings.key4:
                    case Settings.key5:
                    case Settings.key6:
                        return true;
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
        public void CheckForKeyPickup(int row, int col)
        {
            if (numKeyCollected >= 7)
            { 
            return;
            }
            if (IsValidMove(row, col) && Settings.Collectibles.Contains(map[col, row])) // breaks when outside bounds attempt is made.
            {
                foreach (var keyXY in Settings.keysXY)
                {
                    //HudDisplay.messages.Add(keyXY[0].ToString() + ", " + keyXY[1].ToString());
                    //HudDisplay.messages.Add(row + " AAAAA " + col);
                    if (keyXY[0] == col + 1 && keyXY[1] == row + 1)
                    {
                        numKeyCollected++;
                        ReplaceMapTiles(numKeyCollected);
                        return;
                    }
                }
                //HudDisplay.messages.Add("There is neither a key nor empty space found here.");
            }
        }
        public void ReplaceMapTiles(int numKeyCollected)
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            char wallToReplace;
            char keyToReplace;
            switch (numKeyCollected)
            {
                case 1:
                    keyToReplace = Settings.key0;
                    wallToReplace = Settings.Wall0;
                    break;
                case 2:
                    keyToReplace = Settings.key1;
                    wallToReplace = Settings.Wall1;
                    break;
                case 3:
                    keyToReplace = Settings.key2;
                    wallToReplace = Settings.Wall2;
                    break;
                case 4:
                    keyToReplace = Settings.key3;
                    wallToReplace = Settings.Wall3;
                    break;
                case 5:
                    keyToReplace = Settings.key4;
                    wallToReplace = Settings.Wall4;
                    break;
                case 6:
                    keyToReplace = Settings.key5;
                    wallToReplace = Settings.Wall5;
                    break;
                case 7:
                    keyToReplace = Settings.key6;
                    wallToReplace = Settings.Wall6;
                    break;
                default:
                    keyToReplace = ' ';
                    wallToReplace = ' ';
                    break;
            }
            for (int row = 0; row < mapWidth; row++)
            {
                for (int col = 0; col < mapHeight; col++)
                {
                    if (Settings.Collectibles.Contains(map[col, row]) && map[col, row] == keyToReplace)
                    { 
                        map[col, row] = ' ';
                    }
                    if (Settings.Walls.Contains(map[col, row]) && map[col, row] == wallToReplace)
                    {
                        map[col, row] = ' ';
                    }
                }
            }
        }
    }
}