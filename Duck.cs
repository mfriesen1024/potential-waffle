using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Duck : Enemy
    {
        // Constructor for Enemy1, it needs to pass mapData and player to the base class constructor

        public Duck(MapData mapData, Player player, int attackValue, EnemyManager enemyManager, Buffer buffer) : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            Level = 1;
            AttackValue = Level * 5;
            // Enemy 1 specific initializations go here so that methods within Enemy1 can see them.  
        }
        public int Index { get; private set; }
        static Random random = new Random();
        public string Enemy1Name { get; set; }
        public int Enemy1Health { get; set; }
        public string Enemy1CreatureType { get; set; }

        internal void SpawnEnemy1(string name, int health, string creatureType, int attackValue)
        {
            EnemyCharacter = '♣';

            int randomX, randomY;
            do
            {
                randomX = random.Next(1, 77);
                randomY = random.Next(1, 27);
            } while (mapData.map[randomY, randomX] != ' ');//|| (randomX < 8 && randomY < 8));
            DrawEnemy();
            EnemyCol = randomY;
            EnemyRow = randomX;
            Name = name;
        }
        public override void MoveEnemy()
        {
            int randomDirection = random.Next(4);
            int newX = EnemyCol, newY = EnemyRow; 

            switch (randomDirection) // 0: Up, 1: Right, 2: Down, 3: Left
            {
                case 0: // Up
                    newY = EnemyRow - 1;
                    break;
                case 1: // Right
                    newX = EnemyCol + 1;
                    break;
                case 2: // Down
                    newY = EnemyRow + 1;
                    break;
                case 3: // Left
                    newX = EnemyCol - 1;
                    break;
            }

            if (enemyManager.player.playerRow == newY && enemyManager.player.playerCol == newX)
            {
                Attack(player);
            }
            else
            {
                if (mapData.IsValidMove(newY, newX))
                {
                    EnemyRow = newY;
                    EnemyCol = newX;
                }
            }
        }
        public override void Attack(Entity target)
        {
            target.TakeDamage(AttackValue, 0);
            if (target is Entity player)
            {
                if (player.CurrentHealth <= 0)
                {
                    player.Die();
                }
            }
        }
    }
}
