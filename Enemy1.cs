using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Enemy1 : EnemyEntity
    {
        // Constructor for Enemy1, it needs to pass mapData and player to the base class constructor
        public Enemy1(MapData mapData, Player player) : base(mapData, player)
        {
            Index = listOfEnemies.Count + 1;
            // Enemy 1 specific initializations go here so that methods within Enemy1 can see them.  
        }
        internal List<Enemy1> listOfEnemies = new List<Enemy1>();
        public int Index { get; private set; }
        static Random random = new Random();
        char enemyCharacter = '♣';
        public string Enemy1Name { get; set; }
        public int Enemy1Health { get; set; }
        public string Enemy1CreatureType { get; set; }

        internal void SpawnEnemy1(string name, int health, string creatureType)
        {
            int randomX, randomY;
            do
            {
                randomX = random.Next(MapWidth - 1);
                randomY = random.Next(MapHeight - 1);
            } while (mapData.map[randomY, randomX] != ' ' || mapData.map[randomY, randomX] == '☻' || (randomX < 8 && randomY < 8));
            mapData.map[randomY, randomX] = enemyCharacter;
            Name = name;
        }


        public void MoveEnemy1()
        {
            for (int x = 0; x < 76; x++)
            {
                for (int y = 0; y < 27; y++)
                {
                    if (mapData.map[y, x] == enemyCharacter)
                    {
                        int randomDirection = random.Next(4);
                        int newX = x, newY = y;
                        switch (randomDirection) // 0: Up, 1: Right, 2: Down, 3: Left
                        {
                            case 0: // Up
                                newX = Math.Max(0, x - 1);
                                break;
                            case 1: // Right
                                newY = Math.Min(MapHeight - 1, y + 1);
                                break;
                            case 2: // Down
                                newX = Math.Min(MapWidth - 1, x + 1);
                                break;
                            case 3: // Left
                                newY = Math.Max(0, y - 1);
                                break;
                        }
                    }
                }
            }
        }
    }
}
