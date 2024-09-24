using System.ComponentModel.Design;
using System.Text;

namespace untitled
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
