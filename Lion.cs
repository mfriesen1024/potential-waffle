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
            TurnCount = 0;
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
        public override void DisplayMessage(string message)
        {
            throw new NotImplementedException();
        }
        public override void MoveEnemy()
        {
            int deltaX;
            int deltaY;
            if (!dead)
            {
                deltaX = EnemyRow - Player.playerRow;
                deltaY = EnemyCol - Player.playerCol;
                if (deltaX > -18 && deltaX < 18 && deltaY > -18 && deltaY < 18) // Creatures proximity to player in order to move
                { 
                    TurnCount++;
                    if (TurnCount % 3 == 0)
                    {
                        int randomDirection = Settings.random.Next(3);
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
                                // Cases 4 through 11 result in staying in place
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
