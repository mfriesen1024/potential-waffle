﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Goose : Enemy
    {
        public Goose(MapData mapData, Player player, int attackValue,
            EnemyManager enemyManager, Buffer buffer)
            : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            Level = 1;
            AttackValue = Level * 2;
            Modifer = Level;
            EnemyCharacter = Settings.GooseChar;
        }
        public int Index { get; private set; }
        public string GooseName { get; set; }
        public int GooseHealth { get; set; }
        public string GooseCreatureType { get; set; }

        public override void DetermineMaxHealth()
        {
            MaxHealth = 10;
        }
        public override void MoveEnemy()
        {
            if (!dead)
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
