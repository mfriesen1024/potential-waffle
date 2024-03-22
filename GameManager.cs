using System.ComponentModel.Design;
using System.Text;

namespace First_Playable
{
    internal class GameManager
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameLoop.Initialize();
            GameLoop.InitializeEnemies();
            MenuManager.DisplayMenu();
            GameLoop.RunGameLoop();
        }
    }
}
