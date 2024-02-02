using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Player : Entity
    {
        private MapData mapData;
        private Buffer buffer;

        internal int playerCol;
        internal int playerRow;

        public bool dead;
        public Player(MapData mapData, Buffer buffer, string name, int initialHealth) : base(name, initialHealth, "Player")
        {
            this.mapData = mapData;
            this.buffer = buffer;
        }
        public char playerCharacter { get; } = '☻'; // the use of get here causes the player icon to be read-only which disallows it from changing later on


        public override void Attack(Entity target)
        {
            DisplayInfo();
            target.TakeDamage(5);
            // Implement player-specific attack logic
        }
        private void CheckCollision(List<EnemyEntity> enemies)
        {
            foreach (EnemyEntity enemy in enemies)
            {
                if (playerCol == enemy.EnemyCol && playerRow == enemy.EnemyRow)
                {
                    // Collision detected, initiate an attack on the enemy
                    Attack(enemy);
                }
            }
        }
        public void Initialize()
        {
            dead = false;
            playerCol = 4;
            playerRow = 4;
        }

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
            CheckCollision(enemyEntity.listOfEnemies);
        } // Both WASD and Arrows keys (I tried to type Arrow key input here, I'm a stupid.)

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
                if (mapData.EnviromentalHazard.Contains(mapData.map[playerCol, playerRow].ToString())) // In short if the player occupies a hazard the following code runs.
                {
                    Random random = new Random();
                    int damageChance = random.Next(8);

                    switch (mapData.map[playerCol, playerRow].ToString()) // Reads Char array from MapData and converts back to string for switch statement check.
                    {
                        case "⅛":
                            if (damageChance == 0) // 1/8 probability
                            {
                                TakeDamage(5); // This is amazing how this works, the way I've set this up I don't need any prefix
                            }
                            break;
                        case "⅜":
                            if (damageChance < 3) // 3/8 probability
                            {
                                TakeDamage(5); // I can use the standard name method without needing to tell it where to get it.
                            }
                            break;
                        case "⅝":
                            if (damageChance < 5) // 5/8 probability
                            {
                                TakeDamage(5); // The TakeDamage method is stored in HealthSystem which is delegated to by Entity 
                            }
                            break;
                        case "⅞":
                            if (damageChance < 7) // 7/8 probability
                            {
                                TakeDamage(5); // Player Inherits from Entity and any Health related methods go up to Entity and delegated over to Healthsystem smoothly.
                            }
                            break; // Here's what the method actually looks like TakeDamage(int damage) => healthSystem.TakeDamage(damage);
                    }
                }
            }
        }
        
        public void DrawPlayer()
        {
            buffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }
    }
}