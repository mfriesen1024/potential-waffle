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
            Utils.Print("Preparing to init.", true);
            GameManager.Initialize();
            Utils.Print("Init foes", true);
            GameManager.InitializeEnemies();
            Utils.Print("Display menu", true);
            MenuManager.DisplayMenu();
            Utils.Print("Run game.", true);
            GameManager.RunGameLoop();
        }
    }
}
