using System.ComponentModel.Design;
using System.Text;
using untitled.Managers;

namespace untitled
{
    public class Entry
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            GameManager.Initialize();
            GameManager.InitializeEnemies();
            MenuManager.DisplayMenu();
            GameManager.RunGameLoop();
        }
    }
}
