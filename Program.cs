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

        static void Main(string[] args)
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            enemyManager = new EnemyManager(mapData);
            player = new Player(mapData, enemyManager,"Sam Robichaud", 100, 10, buffer); 
            
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed at the top of Main so that ASCII display properly

            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();

            List<Duck> listOfEnemies = Populate(5);

            GameLoop();
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

        

        static void GameLoop()
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