using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Program
    {
        private static Buffer buffer;
        private static MapData mapData;
        private static Player player;
        private static EnemyManager enemyManager;
        public static ItemManager itemManager;
        private static HudDisplay hudDisplay;
        private static Item item;

        public static void Initialize()
        {
            Console.WriteLine("Initialize Running");
            buffer = new Buffer();
            mapData = new MapData(buffer);
            mapData.TxtFileToMapArray();
            enemyManager = new EnemyManager(mapData);
            itemManager = new ItemManager(buffer, mapData, player, hudDisplay);
            hudDisplay = new HudDisplay(itemManager);
            CreatePlayerInstance();
            buffer.DisplayBuffer();
            itemManager.SpreadItems(buffer);
        }
        static void CreatePlayerInstance()
        {
            player = new Player(mapData, enemyManager, "Sam Robichaud", Settings.StartingHealth, 5, buffer, item, itemManager, hudDisplay); 
        }

        public static void GameLoop()
        {
            Console.WriteLine("Game Loop Initializing");
            do
            {
                while (Console.KeyAvailable) Console.ReadKey(true);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                Environment.Exit(0);
                }
                player.HandleKeyPress(keyInfo.Key);
                enemyManager.MoveEnemies(); 
                mapData.PrintMap(); 
                player.DrawPlayer(); 
                enemyManager.DrawEnemies();
                mapData.DrawBorder();
                mapData.HudBorder();
                mapData.UIBorder();
                player.UpdatePlayerUI();
                itemManager.DrawItems();
                Console.WriteLine(ItemManager.AllItemsList.Count);
                buffer.DisplayBuffer();
                hudDisplay.DrawHudMessages();
            } 
            while (!player.dead);
        }
        static void Populate(MapData mapData, Player player, int attackValue, EnemyManager enemyManager, Buffer buffer, params (Type, int)[] enemyCounts)
        {
            foreach (var (enemyType, count) in enemyCounts)
            {
                switch (enemyType.Name)
                {
                    case nameof(Duck):
                        List<Duck> ducks = Spawner<Duck>(mapData, player, attackValue, enemyManager, buffer, count, "Donald", 10, Enemy.SmallCreatureTypes, 0, 5);
                        break;
                    case nameof(Lion):
                        List<Lion> lions = Spawner<Lion>(mapData, player, attackValue, enemyManager, buffer, count, "Simba", 15, Enemy.LargeCreatureTypes, 0, 8);
                        break;
                    case nameof(Goose):
                        List<Goose> geese = Spawner<Goose>(mapData, player, attackValue, enemyManager, buffer, count, "Gary", 12, Enemy.MediumCreatureTypes, 0, 6);
                        break;
                    // Add cases for other enemy types
                }
            }
        }
        static List<Type> Spawner<Type>(MapData mapData, Player player, int attackValue, EnemyManager enemyManager, Buffer buffer, int count, string name, 
        int health, string[] creatureTypes, int creatureTypeIndex, int enemyAttackValue)
            where Type : Enemy
        {
            List<Type> enemies = new List<Type>();
            for (int i = 0; i < count; i++)
            {
                Type newEnemy = (Type)Activator.CreateInstance(typeof(Type), mapData, player, attackValue, enemyManager, buffer);
                newEnemy.SpawnEnemy(name, health, creatureTypes, creatureTypeIndex, enemyAttackValue); 
                enemies.Add(newEnemy);
            }
            return enemies;
        }
        public static void InitializeEnemies1()
        {
            Console.WriteLine("Enemies Initializing");
            Populate(mapData, player, Settings.EnemyAtk, enemyManager, buffer, (typeof(Duck), Settings.DuckCount), (typeof(Lion), Settings.LionCount), (typeof(Goose), Settings.GooseCount));
        }
    }
}