using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Player
    {
        private PlayerStats playerStats;

        public char playerCharacter { get; } = '☻'; // the use of get here causes the player icon to be read-only which disallows it from changing later on


        public void StructAccessor()
        {
            playerStats = new PlayerStats
            {
                playerRow = 0, // Initialize the starting row
                playerCol = 0 // Initialize the starting column
            };
        }



        private void HandleKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    MovePlayer(1, 0);
                    break;

                case ConsoleKey.W:
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.S:
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.A:
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    MovePlayer(1, 0);
                    break;
            }
        }

        private void MovePlayer(int rowChange, int columnChange)
        {
            Console.CursorVisible = false;

            int newRow = playerStats.playerRow + rowChange;
            int newCol = playerStats.playerCol + columnChange;

            //// Add conditional checking before updating the position
            //if (program.mapData.IsValidMove(newRow, newCol))
            //{
            //    playerStats.playerRow = newRow;
            //    playerStats.playerCol = newCol;
            //}
        }


        
    }
}