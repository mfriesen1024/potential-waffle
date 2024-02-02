using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            enemyManager = new EnemyManager(mapData);
            player = new Player(mapData, enemyManager,"Sam Robichaud", 100, 5, buffer); // This is for Matt's class, Sam will never know he is the default character.
            
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed at the top of Main so that ASCII display properly

            ProcessData();

            List<Enemy1> listOfEnemies = Populate();

            // Print the contents of the list
            //foreach (Enemy1 enemy in listOfEnemies) // Used for Debug purposes of reading list contents
            //{
            //    Console.WriteLine(enemy.ToString()); 
            //}

            GameLoop();
        }


        static List<Enemy1> Populate()
        {
            Enemy1 newEnemy1 = new Enemy1(mapData, player, Settings.EnemyAtk, enemyManager, buffer);
            newEnemy1.SpawnEnemy1("Donald", 10, "Duck", 5);
            enemyManager.listOfEnemies.Add(newEnemy1);
            return enemyManager.listOfEnemies;
        }

        static void GameLoop()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0); // Needed for some Border reason that could likely be solved another way
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    player.Initialize(); 
                    keyInfo = Console.ReadKey(true);
                }
                player.HandleKeyPress(keyInfo.Key);

                enemyManager.MoveEnemies();

                player.CheckCollision(enemyManager.allEnemyLists);
                mapData.PrintMap(); // Prevents the player from leaving a trail of player icons
                player.DrawPlayer(); // Put player on da map
                enemyManager.DrawEnemies();
                buffer.DisplayBuffer(); // Anti-Seizure protocol
                mapData.DrawBorder(); // What do you think this does?
            } 
            while (player.dead == false);
        }
        static void ProcessData()
        {
            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();
        }
    }
}