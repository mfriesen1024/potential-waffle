using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    // F12 on anything shows you where it comes from
    internal class Settings
    {
        public const int StartingHealth = 100;
        public const int MaxPlayerHealth = 5;
        public const int StartingLevel = 1;
        public const int EnemyAtk = 5;

        public static Random random = new Random();
    }
}
