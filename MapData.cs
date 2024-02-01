using System.Diagnostics;
using System.IO;

namespace First_Playable
{


    public class MapData
    {
        private Buffer buffer;
        public char[,] ?map;

        public MapData()
        {
            buffer = new Buffer();
        }

        public void DrawMap()
        {
            if (map != null)
            {
            buffer.secondBuffer = new char[map.GetLength(0), map.GetLength(1)];

            Array.Copy(map, buffer.secondBuffer, map.Length);

            }
        }
         public void PrintMap()
        {
            // Iterate through the map array and print each element
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine(); // Move to the next line after each row
            }   
        }

        
        public void TxtFileToMapArray()
        {
            buffer = new Buffer();
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