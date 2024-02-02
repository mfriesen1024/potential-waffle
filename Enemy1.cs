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

        internal static List<Enemy1> listOfEnemy1s = new List<Enemy1>();
        public Enemy1(MapData mapData, Player player, int attackValue) : base(mapData, player, attackValue)
        {
            listOfEnemy1s.Add(this);
            AttackValue = attackValue;
            // Enemy 1 specific initializations go here so that methods within Enemy1 can see them.  
        }
        public int Index { get; private set; }
        static Random random = new Random();
        char enemyCharacter = '♣';
        public string Enemy1Name { get; set; }
        public int Enemy1Health { get; set; }
        public string Enemy1CreatureType { get; set; }

        public static void DisplayAllEnemy1sInfo()
        {
            foreach (var enemy in listOfEnemy1s)
            {
                enemy.DisplayInfo();
                Console.WriteLine();
            }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Call the base class's DisplayInfo method

            // Add additional information specific to Enemy1
            Console.WriteLine($"Index: {Index}, Enemy Character: {enemyCharacter}");
        }


        internal void SpawnEnemy1(string name, int health, string creatureType, int attackValue)
        {
            int randomX, randomY;
            do
            {
                randomX = random.Next(1, 77);
                randomY = random.Next(1, 27);
            } while (mapData.map[randomY, randomX] != ' ' || mapData.map[randomY, randomX] == '☻' || (randomX < 8 && randomY < 8));
            mapData.map[randomY, randomX] = enemyCharacter;
            Name = name;
        }



        public void MoveEnemy1()
        {
            int randomDirection = random.Next(4);
            int newX = playerCol, newY = playerRow; // Set initial values

            switch (randomDirection) // 0: Up, 1: Right, 2: Down, 3: Left
            {
                case 0: // Up
                    newY = Math.Max(0, playerRow - 1);
                    break;
                case 1: // Right
                    newX = Math.Min(MapWidth - 1, playerCol + 1);
                    break;
                case 2: // Down
                    newY = Math.Min(MapHeight - 1, playerRow + 1);
                    break;
                case 3: // Left
                    newX = Math.Max(0, playerCol - 1);
                    break;
            }

            if (playerRow == newY && playerCol == newX)
            {
                player.Attack(this);
            }
            else
            {
                EnemyRow = newY;
                EnemyCol = newX;
            }
        }
    }
}
