using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using untitled.Managers;
using untitled.Map;
using static System.Net.Mime.MediaTypeNames;

namespace untitled
{
    internal class Player : Entity
    {
        private MapData mapData;
        private EnemyManager enemyManager;
        public CBuffer buffer;
        private HudDisplay hudDisplay;
        private ItemManager itemManager; 
        private Item item;
        private bool isUIUpdated = false;

        public static int playerCol = Settings.playerCol;
        public static int playerRow = Settings.playerRow;
        public static char playerCharacter { get; } = '☻';
        bool hasAttacked;
        public int CurrentHealth => healthSystem.CurrentHealth;

        public Player(MapData mapData, EnemyManager enemyManager,
            string name, int initialHealth, int attackValue, CBuffer buffer, Item item, ItemManager itemManager, HudDisplay hudDisplay)
            : base(name, initialHealth, new string[]{"Player"})
        {
            dead = false;
            this.mapData = mapData;
            this.enemyManager = enemyManager;
            AttackValue = attackValue;
            this.item = item;
            this.hudDisplay = hudDisplay;
            Modifer = Settings.playerLevel * 2;
            playerCol = Settings.playerCol;
            playerRow = Settings.playerRow;
            hudDisplay.SetPlayer(this);
            enemyManager.SetPlayer(this);
            itemManager.SetPlayer(this);
            this.itemManager = itemManager;
            this.buffer = buffer;
            Damage = attackValue + Modifer;
        }
        public override void DisplayMessage(string message)
        {   
            if (HudDisplay.messages != null)
            {
                HudDisplay.messages.Add(message);
            }
        }
        public bool UpdatePlayerUI()
        {
            HudDisplay.Status.Clear();
            HudDisplay.Status.Add("Player Level: " + Settings.playerLevel);
            HudDisplay.Status.Add("Player Location: " + playerRow + ", " + playerCol);
            HudDisplay.Status.Add("Player HP: " + CurrentHealth + " / " + Settings.MaxPlayerHealth);
            HudDisplay.Status.Add("Player ATK Damage: " + Damage);
            HudDisplay.Status.Add("Score: " + HudDisplay.TotalScore);
            HudDisplay.OneUpCheck();
            hudDisplay.DrawUIMessages();
            return isUIUpdated;
        }
        public void Buff()
        {
            Damage += 2;
        }
        public void DisplayUI(string status)
        {
            HudDisplay.Status.Add(status);
        }
        public void HandleKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    CheckCollision(enemyManager.listOfEnemies, 0, -1);
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                    CheckCollision(enemyManager.listOfEnemies, 0, 1);
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                    CheckCollision(enemyManager.listOfEnemies, -1, 0);
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    CheckCollision(enemyManager.listOfEnemies, 1, 0);
                    MovePlayer(1, 0);
                    break;

                case ConsoleKey.W:
                    CheckCollision(enemyManager.listOfEnemies, 0, -1);
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.S:
                    CheckCollision(enemyManager.listOfEnemies, 0, 1);
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.A:
                    CheckCollision(enemyManager.listOfEnemies, -1, 0);
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    CheckCollision(enemyManager.listOfEnemies, 1, 0);
                    MovePlayer(1, 0);
                    break;
            }
            UpdatePlayerUI();
        }
        internal void CheckCollision(List<Enemy> EnemyList, int rowChange, int columnChange)
        {
            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

            foreach (var enemy in EnemyList)
            {
                if (newCol == enemy.EnemyCol && newRow == enemy.EnemyRow && !enemy.dead)
                {
                    hasAttacked = true;
                    Attack(enemy);
                }
            }
            for (int i = 0; i < ItemManager.AllItemsList.Count; i++)
            {
                int[] itemCoordinates = ItemManager.AllItemsList[i].GetItemXY();
                int itemX = itemCoordinates[0];
                int itemY = itemCoordinates[1];
                if (newCol == itemY && newRow == itemX && !ItemManager.AllItemsList[i].Collected)
                {
                    ItemManager.AllItemsList[i].Collected = true;
                    DisplayMessage("Player picked up an item");
                    ItemManager.AllItemsList[i].UseItem();
                    UpdatePlayerUI();
                }
                mapData.CheckForKeyPickup(newRow, newCol);
            }
        }
        private void MovePlayer(int rowChange, int columnChange)
        {
            Console.CursorVisible = false;
            if (hasAttacked)
            {
                hasAttacked = false;
                return;
            }
            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;
            if (mapData.IsValidMove(newRow, newCol))
            { 
                playerRow = newRow;
                playerCol = newCol;
                if (Settings.WinLocation.Any(location => location[0] == newCol && location[1] == newRow))
                {
                    WinGame();
                }
            }
        }
        public override void Attack(Entity target)
        {
            if (target is Enemy enemy)
            {
                int DamageDealt = Damage;
                target.TakeDamage(Damage);
                DisplayMessage("Player dealt " + DamageDealt + " damage and gained " + DamageDealt + " points.");
                HudDisplay.AddScore(DamageDealt);
                if (enemy.CurrentHealth <= 0)
                {
                    enemy.Die();
                }
            }
        }
        public override void Die()
        {
            Console.Clear();
            Console.WriteLine("You Died with a Score of: " + HudDisplay.TotalScore.ToString());
            Console.ReadKey(true);
            dead = true;
        }
        public void WinGame()
        {
            Console.Clear();
            Console.WriteLine("YOU WIN!!! YOUR SCORE WAS: " + HudDisplay.TotalScore.ToString());
            Console.ReadKey(true);
            dead = true;
        }
        public void DrawPlayer()
        {
            buffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }
    }
}