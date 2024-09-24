using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Map;

namespace untitled
{
    internal class Lion : Enemy
    {
        public Lion(MapData mapData, Player player, int attackValue,
            EnemyManager enemyManager, Buffer buffer)
            : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            AttackValue = Settings.NPCLevel * 2;
            Modifer = Settings.NPCLevel * 2;
            EnemyCharacter = Settings.LionChar;
            MaxHealth = 15;
            TurnCount = 0;
        }
        public int Index { get; private set; }
        public string LionName { get; set; }
        public int LionHealth { get; set; }
        public string LionCreatureType { get; set; }

        public override int DetermineMaxHealth()
        {
            MaxHealth = 15;
            return MaxHealth;
        }
        public override void DisplayMessage(string message)
        {
            HudDisplay.messages.Add(message);
        }
        public override void MoveEnemy()
        {
            int deltaX;
            int deltaY;
            if (!dead)
            {
                deltaX = EnemyRow - Player.playerRow;
                deltaY = EnemyCol - Player.playerCol;
                if (deltaX > -18 && deltaX < 18 && deltaY > -18 && deltaY < 18) // Required proximity to player in order to move
                { 
                    TurnCount++;
                    if (TurnCount % 3 == 0)
                    {
                        int randomDirection = Settings.random.Next(4);
                        int newX = EnemyCol, newY = EnemyRow;

                        switch (randomDirection)
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
            }
        }
        public override void Die()
        {
            dead = true;
        }
        public override void Attack(Entity target)
        {
            int Damage = AttackValue + Modifer;
            target.TakeDamage(Damage);
            if (target is Entity player)
            {
                DisplayMessage("Player was damaged by a Lion for " + Damage + " damage.");
                if (player.CurrentHealth <= 0)
                {
                    player.Die();
                }
            }
        }
    }
}
