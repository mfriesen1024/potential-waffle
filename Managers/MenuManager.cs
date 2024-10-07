using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace untitled.Managers
{
    internal class MenuManager
    {
        public static void DisplayMenu()
        {
            Console.SetWindowSize(150, 40);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Starting Game");
            Console.ReadKey(true);
            Console.WriteLine("Navigate through the level with WASD or ARROW KEYS");
            Console.WriteLine();
            Console.WriteLine("Collect all of the CYAN keys!");
            Console.WriteLine("Each KEY points towards the next key in sequence");
            Console.WriteLine();
            Console.WriteLine("Each key opens up a different PASSAGEWAY");
            Console.WriteLine("Walls that can that can be removed to open PASSAGEWAYS are colored WHITE");
            Console.WriteLine();
            Console.WriteLine("Enemies are GREEN, beat them up to increase your score!");
            Console.WriteLine();
            Console.WriteLine("Healthpacks are represented by a RED H");
            Console.WriteLine("Attack buffs are represented by a RED A");
            Console.WriteLine();
            Console.WriteLine("PRESS ANY KEY TWICE TO BEGIN");
            Console.ReadKey(true);
        }
    }
}