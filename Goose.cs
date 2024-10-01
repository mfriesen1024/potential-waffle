using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using untitled.Managers;
using untitled.Map;

namespace untitled
{
    internal class Goose : Enemy
    {
        public Goose(MapData mapData, Player player, int attackValue,
            EnemyManager enemyManager, CBuffer buffer)
            : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            AttackValue = Settings.NPCLevel * 2;
            Modifer = Settings.NPCLevel;
            EnemyTile = Settings.GooseChar;
            MaxHealth = 10;
            TurnCount = 0;
        }
        public int Index { get; private set; }
        public string GooseName { get; set; }
        public int GooseHealth { get; set; }
        public string GooseCreatureType { get; set; }

        public override int DetermineMaxHealth()
        {
            MaxHealth = 10;
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
                if (deltaX > -8 && deltaX < 8 && deltaY > -8 && deltaY < 8)
                {
                    TurnCount++;
                    if (TurnCount % 2 == 0)
                    {
                        int randomDirection = Settings.random.Next(4);
                        int newX = EnemyCol, newY = EnemyRow;

                        switch (randomDirection)
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
                DisplayMessage("Player was damaged by a Goose for " + Damage + " damage.");
                if (player.CurrentHealth <= 0)
                {
                    player.Die();
                }
            }
        }
    }
}
