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
        private static HudDisplay hudDisplay;

        public static void Initialize()
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            enemyManager = new EnemyManager(mapData);
            CreatePlayerInstance();
            hudDisplay = new HudDisplay(player);
            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();
        }

        // public static void InitializeEnemies()
        // { 
        //     List<Duck> listOfEnemies = Populate(5); 
        // }

        static void CreatePlayerInstance() 
        { 
            player = new Player(mapData, enemyManager, "Sam Robichaud", 10, 5, buffer); 
        }


        // static List<Duck> Populate(int amount)
        // {
        //     for (int i = 0; i < amount; i++)
        //     {
        //         Duck newEnemy = new Duck(mapData, player, Settings.EnemyAtk, enemyManager, buffer);
        //         newEnemy.SpawnEnemy("Donald", 10, Enemy.SmallCreatureTypes, 0, 5);
        //         enemyManager.listOfEnemies.Add(newEnemy);
                
        //     }
        //     return enemyManager.listOfEnemies;
        // }

        

        public static void GameLoop()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0); // Needed for some Border reason that could likely be solved another way
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    keyInfo = Console.ReadKey(true);
                }
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


        static void Populate1(MapData mapData, Player player, int attackValue, EnemyManager enemyManager, Buffer buffer, params (Type, int)[] enemyCounts)
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
                    // Add cases for other enemy types...
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
                newEnemy.SpawnEnemy(name, health, creatureTypes, creatureTypeIndex, enemyAttackValue); // Use enemyAttackValue here
                enemies.Add(newEnemy);
            }
            return enemies;
        }


        public static void InitializeEnemies1()
        {
            Populate1(mapData, player, Settings.EnemyAtk, enemyManager, buffer, (typeof(Duck), 5), (typeof(Lion), 2), (typeof(Goose), 3));
        }

        
    }
}