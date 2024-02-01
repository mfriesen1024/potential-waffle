using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{


    internal class MapData
    {
        private Buffer buffer;
        private Program program;
        public char[,] ?map;

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
                    return false;
                }
                // if (map[newCol, newRow] == EnemyManager.enemyCharacter)
                // {
                //     map[newCol, newRow] = ' ';
                // }
                // if (map[newCol, newRow] == Player.Fruit && Player.health < Player.maxHealth)
                // {
                //     map[newCol, newRow] = ' ';
                //     Player.GainHealth();
                // }
            }
            return false;
        }


        public void TxtFileToMapArray() // works now
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