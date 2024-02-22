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
        public static int playerCol = 4;
        public static int playerRow = 4;
        public const int StartingHealth = 100;
        public const int MaxPlayerHealth = 5;
        public const int StartingLevel = 1;
        public const int EnemyAtk = 5;

        public const char DuckChar = '1';
        public const char GooseChar = '2';
        public const char PenguinChar = '3';
        public const char HealthChar = '☙';

        public static DateTime lastInputTime = DateTime.MinValue;
        public static TimeSpan inputDelay = TimeSpan.FromSeconds(0.1);
        public static Random random = new Random();

    }
}
