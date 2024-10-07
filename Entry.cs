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
            Utils.Print("Preparing to init.");
            GameManager.Initialize();
            Utils.Print("Init foes");
            GameManager.InitializeEnemies();
            Utils.Print("Display menu");
            MenuManager.DisplayMenu();
            HudDisplay.Init();
            Utils.Print("Run game.");
            GameManager.RunGameLoop();
        }
    }
}
