using System.Text;

namespace First_Playable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameManager.Initialize();
            GameManager.InitializeEnemies();
            Console.WriteLine("Initialization Complete");
            Console.WriteLine("Trying Game Loop");
            Console.ReadKey(true);
            GameManager.GameLoop();
        }
    }
}
