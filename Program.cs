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
        private static ItemManager itemManager;
        private static HudDisplay hudDisplay;
        private static Item item;

        public static void Initialize()
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            enemyManager = new EnemyManager(mapData);
            itemManager = new ItemManager(buffer, mapData);
            CreatePlayerInstance();
            hudDisplay = new HudDisplay(player);
            item = new Item();
            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();
            itemManager.SpreadItems(mapData, buffer);
        }
        static void CreatePlayerInstance() 
        { 
            player = new Player(mapData, enemyManager, "Sam Robichaud", 10, 5, buffer, item); 
        }
        public static void GameLoop()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                //Console.Clear();
                //Console.SetCursorPosition(0, 0); // Needed for some Border reason that could likely be solved another way
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                Environment.Exit(0);
                }
                player.HandleKeyPress(keyInfo.Key);
                enemyManager.MoveEnemies(); 
                mapData.PrintMap(); // Prevents the player from leaving a trail of player icons
                player.DrawPlayer(); // Put player on the map
                enemyManager.DrawEnemies();
                buffer.DisplayBuffer(); // Double buffer prevents flickering
                mapData.DrawBorder(); 
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
            Populate(mapData, player, Settings.EnemyAtk, enemyManager, buffer, (typeof(Duck), 2), (typeof(Lion), 4), (typeof(Goose), 10));
        }

        
    }
}