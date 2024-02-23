using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Lion : Enemy
    {
        public Lion(MapData mapData, Player player, int attackValue,
            EnemyManager enemyManager, Buffer buffer)
            : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            Level = 1;
            AttackValue = Level * 2;
            Modifer = Level;
            EnemyCharacter = Settings.LionChar;
            MaxHealth = 10;
        }
        public int Index { get; private set; }
        public string LionName { get; set; }
        public int LionHealth { get; set; }
        public string LionCreatureType { get; set; }

        public override int DetermineMaxHealth()
        {
            MaxHealth = 10;
            return MaxHealth;
        }
        public override void MoveEnemy()
        {
            if (!dead)
            {
                int randomDirection = Settings.random.Next(12);
                int newX = EnemyCol, newY = EnemyRow;

                switch (randomDirection) // 0: Up, 1: Right, 2: Down, 3: Left
                {
                    case 0: // Up
                        newY = EnemyRow - 3;
                        break;
                    case 1: // Right
                        newX = EnemyCol + 3;
                        break;
                    case 2: // Down
                        newY = EnemyRow + 3;
                        break;
                    case 3: // Left
                        newX = EnemyCol - 3;
                        break;
                }

                if (Player.playerRow == newY && Player.playerCol == newX)
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
        }
        public override void Die()
        {
            dead = true;

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
