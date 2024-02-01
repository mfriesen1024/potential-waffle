using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Player
    {
        private MapData mapData;
        private Buffer buffer;

        private int playerCol;
        private int playerRow;

        public bool dead;

        public void Initialize()
        {
            dead = false;
            playerCol = 4;
            playerRow = 4;
        }

        public Player(MapData mapData, Buffer buffer)
        {
            this.mapData = mapData;
            this.buffer = buffer;
        }

        public char playerCharacter { get; } = '☻'; // the use of get here causes the player icon to be read-only which disallows it from changing later on

        public void HandleKeyPress(ConsoleKey key)
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

            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

            //// Add conditional checking before updating the position
            if (mapData.IsValidMove(newRow, newCol))
            {
                playerRow = newRow;
                playerCol = newCol;
            }
        }
        
        public void DrawPlayer()
        {
            buffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }
    }
}