using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Player : Entity
    {
        private MapData mapData;
        private EnemyManager enemyManager;
        private Buffer buffer;
        private HudDisplay hudDisplay;
        private ItemManager itemManager; 
        private Item item;  
        
        public static int playerCol = Settings.playerCol; // there should only ever be one player on screen, many player statisics will be static to reflect this.
        public static int playerRow = Settings.playerRow;
        public char playerCharacter { get; } = '☻';
        bool hasAttacked;
        public int CurrentHealth => healthSystem.CurrentHealth;

        public Player(MapData mapData, EnemyManager enemyManager,
            string name, int initialHealth, int attackValue, Buffer buffer, Item item, ItemManager itemManager, HudDisplay hudDisplay)
            : base(name, initialHealth, new string[]{"Player"})
        {
            this.mapData = mapData;
            this.enemyManager = enemyManager;
            AttackValue = attackValue;
            this.item = item;
            //this.hudDisplay = hudDisplay; // useless?
            Level = 1;
            attackValue = Level * 5;
            Modifer = Level * 2;
            playerCol = Settings.playerCol;
            playerRow = Settings.playerRow;
            hudDisplay.SetPlayer(this);
            enemyManager.SetPlayer(this);
            itemManager.SetPlayer(this); // which one?

            this.itemManager = itemManager; // which one?
            this.buffer = buffer;
        }
        public override void DisplayMessage(string message)
        {   
            if (HudDisplay.messages != null)
            {
                HudDisplay.messages.Add(message);
            }
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
                    CheckCollision(enemyManager.listOfEnemies,-1,0 );
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    CheckCollision(enemyManager.listOfEnemies, 1, 0);
                    MovePlayer(1, 0);
                    break;
            }
            //DisplayMessage("Player pressed a key");
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
            foreach (var item in ItemManager.AllItemsList)
            {
                int[] itemCoordinates = item.GetItemXY(); // Get the X and Y coordinates of the item
                int itemX = itemCoordinates[0];
                int itemY = itemCoordinates[1];
                if (newCol == itemY && newRow == itemX)
                {
                    item.Collected = true;
                    item.UseItem();
                }
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
                
                if (mapData.EnviromentalHazard.Contains(MapData.map[playerCol, playerRow].ToString()))
                {
                    int damageChance = Settings.random.Next(8);
                    switch (MapData.map[playerCol, playerRow].ToString())
                    {
                        case "⅛":
                            if (damageChance == 0) 
                            {
                                TakeDamage(5, 20); 
                            }
                            break;
                        case "⅜":
                            if (damageChance < 3) 
                            {
                                TakeDamage(5, 20); 
                            }
                            break;
                        case "⅝":
                            if (damageChance < 5) 
                            {
                                TakeDamage(5, 20);  
                            }
                            break;
                        case "⅞":
                            if (damageChance < 20) 
                            {
                                TakeDamage(5, 20); 
                            }
                            break;
                    }
                }
            }
        }
        public override void Attack(Entity target)
        {
            if (target is Enemy enemy)
            {
                target.TakeDamage(AttackValue, Modifer);
                int DamageDealt = enemy.DetermineMaxHealth() - target.CurrentHealth;
                DisplayMessage("Player dealt " + DamageDealt + " and gained " + DamageDealt + " points.");
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
            // Display Score
            System.Console.WriteLine("You Died");
            Console.ReadKey(true);
            dead = true;
        }
        public void DrawPlayer()
        {
            buffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }
    }
}