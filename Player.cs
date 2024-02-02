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
        private EnemyManager enemyManager;
        
        internal int playerCol;
        internal int playerRow;

        bool hasAttacked;

        Buffer buffer;

        public bool dead;
        public Player(MapData mapData, EnemyManager enemyManager, string name, int initialHealth, int attackValue, Buffer buffer) : base(name, initialHealth, "Player")
        {
            this.mapData = mapData;
            this.enemyManager = enemyManager;
            AttackValue = attackValue;
            Level = 1;
            attackValue = Level * 5;
            enemyManager.SetPlayer(this);
            this.buffer = buffer;
        }
        public char playerCharacter { get; } = '☻'; // the use of get here causes the player icon to be read-only which disallows it from changing later on
        public int CurrentHealth => healthSystem.CurrentHealth;

        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackValue, 0);
            //Console.WriteLine($"Player attacked {target.Name}!");

            if (target is EnemyEntity enemy)
            {
                if (enemy.CurrentHealth <= 0)
                {
                    enemy.Die();
                }
            }
        }
        internal void CheckCollision(List<Enemy1> EnemyList, int rowChange, int columnChange)
        {
            //foreach (var enemyList in allEnemyLists)
            //{
            //    if (enemyList.Count > 0)
            //    {
            //        foreach (var enemy in enemyList)
            //        {
            //            if (playerCol == enemy.EnemyCol && playerRow == enemy.EnemyRow)
            //            {
            //                // Collision detected, initiate an attack on the enemy
            //                Attack(enemy);
            //            }
            //        }
            //    }
            //}
            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

            foreach (var enemy in EnemyList)
            {
                if (newCol == enemy.EnemyCol && newRow == enemy.EnemyRow)
                {
                    hasAttacked = true;
                    // collision detected, initiate an attack on the enemy
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
                    CheckCollision(enemyManager.listOfEnemies, 0, -1);
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                    CheckCollision(enemyManager.listOfEnemies, 0, 1);
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                    CheckCollision(enemyManager.listOfEnemies, -1, 0);
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    CheckCollision(enemyManager.listOfEnemies, 1, 0);
                    MovePlayer(1, 0);
                    break;

                case ConsoleKey.W:
                    CheckCollision(enemyManager.listOfEnemies, 0, -1);
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.S:
                    CheckCollision(enemyManager.listOfEnemies, 0, 1);
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.A:
                    CheckCollision(enemyManager.listOfEnemies,-1,0 );
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    CheckCollision(enemyManager.listOfEnemies, 1, 0);
                    MovePlayer(1, 0);
                    break;
            }
            //Enemy1.MoveEnemy1();
        } // Both WASD and Arrows keys (I tried to type Arrow key input here, I'm a stupid.)

        private void MovePlayer(int rowChange, int columnChange)
        {
            Console.CursorVisible = false;
            
            if (hasAttacked)
            {
                hasAttacked = false;
                return;
            }

            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

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
                                TakeDamage(5, 0); // This is amazing how this works, the way I've set this up I don't need any prefix
                            }
                            break;
                        case "⅜":
                            if (damageChance < 3) // 3/8 probability
                            {
                                TakeDamage(5, 0); // I can use the standard name method without needing to tell it where to get it.
                            }
                            break;
                        case "⅝":
                            if (damageChance < 5) // 5/8 probability
                            {
                                TakeDamage(5, 0); // The TakeDamage method is stored in HealthSystem which is delegated to by Entity 
                            }
                            break;
                        case "⅞":
                            if (damageChance < 7) // 7/8 probability
                            {
                                TakeDamage(5, 0); // Player Inherits from Entity and any Health related methods go up to Entity and delegated over to Healthsystem smoothly.
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