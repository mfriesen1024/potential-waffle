using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameManager.Initialize();
            GameManager.InitializeEnemies1();
            Console.WriteLine("Initialization Complete");
            Console.WriteLine("Trying Game Loop");
            Console.ReadKey(true);
            GameManager.GameLoop();
        }
    }
}
