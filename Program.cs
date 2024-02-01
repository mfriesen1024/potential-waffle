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

        // Method Injection
        static void ProcessData()
        {
            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();
            mapData.PrintMap();
        }

        static void Main(string[] args)
        {
            buffer = new Buffer();
            mapData = new MapData(buffer);
            player = new Player(mapData, buffer);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ProcessData();

            GameLoop();
        }

        static void GameLoop()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    player.Initialize();
                    keyInfo = Console.ReadKey(true);
                }
                player.HandleKeyPress(keyInfo.Key);
                mapData.PrintMap();
                player.DrawPlayer();
                buffer.DisplayBuffer();
                //DrawBorder();
            } 
            while (player.dead == false);
        }
    }
}