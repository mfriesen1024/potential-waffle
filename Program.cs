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
        private static EnemyEntity enemyEntity;
        

        static void Main(string[] args)
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            player = new Player(mapData, buffer,enemyEntity,"Sam Robichaud", 100, 5); // This is for Matt's class, Sam will never know he is the default character.
            enemyEntity = new EnemyEntity(mapData, player, 5);
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Needed at the top of Main so that ASCII display properly

            ProcessData();

            List<Enemy1> listOfEnemies = Populate(enemyEntity);

            // Print the contents of the list
            //foreach (Enemy1 enemy in listOfEnemies) // Used for Debug purposes of reading list contents
            //{
            //    Console.WriteLine(enemy.ToString()); 
            //}

            GameLoop();
        }


        static List<Enemy1> Populate(EnemyEntity enemyEntity)
        {
            Enemy1 newEnemy1 = new Enemy1(mapData, player, enemyEntity.AttackValue);
            newEnemy1.SpawnEnemy1("Donald", 10, "Duck", 5);
            enemyEntity.listOfEnemies.Add(newEnemy1);
            return enemyEntity.listOfEnemies;
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
                enemyEntity.PlayerDetection(); // Update player position in EnemyEntity

                foreach (Enemy1 enemy in Enemy1.listOfEnemy1s) 
                {
                    enemy.MoveEnemy1();
                }

                player.CheckCollision(enemyEntity.allEnemyLists);
                mapData.PrintMap(); // Prevents the player from leaving a trail of player icons
                player.DrawPlayer(); // Put player on da map
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