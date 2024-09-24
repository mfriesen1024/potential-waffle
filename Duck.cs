﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using untitled.Map;

namespace untitled
{
    internal class Duck : Enemy
    {
        public Duck(MapData mapData, Player player, int attackValue,
            EnemyManager enemyManager, Buffer buffer)
            : base(mapData, attackValue, enemyManager, buffer)
        {
            AttackValue = attackValue;
            this.player = player;
            AttackValue = Settings.NPCLevel * 2;
            Modifer = Settings.NPCLevel;
            EnemyCharacter = Settings.DuckChar;  
            MaxHealth = 5;
        }
        public int Index { get; private set; }
        public string DuckName { get; set; }
        public int DuckHealth { get; set; }
        public string DuckCreatureType { get; set; }

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
            if (!dead)
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
            else if (dead)
            {
                buffer.secondBuffer[EnemyCol, EnemyRow] = ' ';
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
                DisplayMessage("Player was damaged by a Duck for " + Damage + " damage.");
                if (player.CurrentHealth <= 0)
                {
                    player.Die();
                }
            }
        }
    }
}
