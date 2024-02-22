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

        public static void Initialize()
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            enemyManager = new EnemyManager(mapData);
            CreatePlayerInstance();
            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();
        }

        public static void InitializeEnemies()
        { 
            List<Duck> listOfEnemies = Populate(5); 
        }

        static void CreatePlayerInstance() 
        { 
            player = new Player(mapData, enemyManager, "Sam Robichaud", 10, 5, buffer); 
        }


        static List<Duck> Populate(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Duck newEnemy1 = new Duck(mapData, player, Settings.EnemyAtk, enemyManager, buffer);
                newEnemy1.SpawnEnemy("Donald", 10, "Duck", 5);
                enemyManager.listOfEnemies.Add(newEnemy1);
            }
            return enemyManager.listOfEnemies;
        }

        

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
            while (player.dead == false);
        }
    }
}