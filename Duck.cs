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

        public Duck(MapData mapData, Player player, int attackValue,
            EnemyManager enemyManager, Buffer buffer)
            : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            Level = 1;
            AttackValue = Level * 2;
            Modifer = Level;
            EnemyCharacter = Settings.DuckChar;
            // Duck specific initializations go here so that methods within Enemy1 can see them.  
        }
        public int Index { get; private set; }
        public string Enemy1Name { get; set; }
        public int Enemy1Health { get; set; }
        public string Enemy1CreatureType { get; set; }

        public override void MoveEnemy()
        {
            int randomDirection = Settings.random.Next(4);
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
            target.TakeDamage(AttackValue, Modifer);
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
