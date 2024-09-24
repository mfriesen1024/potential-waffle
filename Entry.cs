using System.ComponentModel.Design;
using System.Text;

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
