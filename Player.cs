using untitled.Foes;
using untitled.Managers;
using untitled.Map;

namespace untitled
{
    internal class Player : Entity
    {
        private MapData mapData;
        private EnemyManager enemyManager;
        public CBuffer buffer;
        private HudDisplay hudDisplay;
        private PickupManager itemManager;
        public Item weapon = new(0, 0);
        private Pickup pickup;
        Shop currentShop = null;
        private bool isUIUpdated = false;

        public int gold = 0;

        public static int playerCol = Settings.playerCol;
        public static int playerRow = Settings.playerRow;
        public static char playerCharacter { get; } = '☻';
        bool hasAttacked;
        public int CurrentHealth => healthSystem.CurrentHealth;

        public Player(MapData mapData, EnemyManager enemyManager,
            string name, int initialHealth, int attackValue, CBuffer buffer, Pickup item, PickupManager itemManager, HudDisplay hudDisplay)
            : base(name, initialHealth, new string[] { "Player" })
        {
            dead = false;
            this.mapData = mapData;
            this.enemyManager = enemyManager;
            AttackValue = attackValue;
            this.pickup = item;
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
            HudDisplay.Status.Add($"Player ATK Damage: {Damage + weapon.str}");
            HudDisplay.Status.Add($"Player Gold: {gold}");
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
                case ConsoleKey.W:
                    CheckCollision(enemyManager.listOfEnemies, 0, -1);
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    CheckCollision(enemyManager.listOfEnemies, 0, 1);
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    CheckCollision(enemyManager.listOfEnemies, -1, 0);
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    CheckCollision(enemyManager.listOfEnemies, 1, 0);
                    MovePlayer(1, 0);
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1: BuyItem(0); break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2: BuyItem(1); break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3: BuyItem(2); break;
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
            for (int i = 0; i < PickupManager.AllPickups.Count; i++)
            {
                int[] itemCoordinates = PickupManager.AllPickups[i].GetItemXY();
                int itemX = itemCoordinates[0];
                int itemY = itemCoordinates[1];
                if (newCol == itemY && newRow == itemX && !PickupManager.AllPickups[i].Collected)
                {
                    PickupManager.AllPickups[i].Collected = true;
                    DisplayMessage("Player picked up an item");
                    PickupManager.AllPickups[i].UseItem();
                    UpdatePlayerUI();
                }
                mapData.CheckForKeyPickup(newRow, newCol);
            }
            if (GameManager.shopManager.ShopCheck(newCol, newRow, out Shop shop))
            {
                DisplayMessage($"Entered a shop!");
                for (int i = 0; i < shop.inventory.Length; i++)
                {
                    Item item = shop.inventory[i];
                    DisplayMessage($"Item {i + 1}: Strength = {item.str}, Price = {item.price}");
                }
                DisplayMessage("Press number keys to buy!");
                currentShop = shop;
            }
            else { currentShop = null; }
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
            if (mapData.MoveCheck(newRow, newCol))
            {
                playerRow = newRow;
                playerCol = newCol;
                if (Settings.WinLocation.Any(location => location[0] == newCol && location[1] == newRow))
                {
                    WinGame();
                }
            }
        }
        void BuyItem(int itemIndex)
        {
            // only buy items if we're on a shop tile.
            if (currentShop != null)
            {
                Item item = currentShop.inventory[itemIndex];

                if (gold >= item.price)
                {
                    weapon = item;
                    DisplayMessage($"Player bought item {itemIndex + 1}.");
                    gold -= item.price;
                }
                else { DisplayMessage($"Player cannot afford item {itemIndex + 1}"); }
            }
            else { DisplayMessage("Player is not in a shop, and cannot buy items."); }
        }
        public override void Attack(Entity target)
        {
            if (target is Enemy enemy)
            {
                int DamageDealt = Damage + weapon.str;
                target.TakeDamage(DamageDealt);
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
            buffer.secondBuffer[playerCol, playerRow] = (Tile)playerCharacter;
        }
    }
}