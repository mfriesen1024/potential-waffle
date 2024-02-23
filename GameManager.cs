using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class GameManager
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Program.Initialize();
            Program.InitializeEnemies1();
            Console.WriteLine("Initialization Complete");
            Console.WriteLine("Trying Game Loop");
            Console.ReadKey(true);
            Program.GameLoop();
        }
    }
}
