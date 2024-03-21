﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Settings
    {
        #region Collectibles
        public static int[][] keysXY = new int[][]
    {
        new int[] { 8, 11 },// key0XY
        new int[] { 24, 2 },// key1XY
        new int[] { 24, 50 },// key2XY
        new int[] { 9, 50 },// key3XY
        new int[] { 10, 15 },//key4XY
        new int[] { 2, 16 },// key5XY
        new int[] { 19, 21 }// key6XY
    };
        public const char key0 = '↔';
        public const char key1 = '>';
        public const char key2 = '^';
        public const char key3 = '←';
        public const char key4 = '↑';
        public const char key5 = '↓';
        public const char key6 = '→';
        public const char HealthChar = 'H';
        public const char BuffChar = 'A';
        public static char[] Collectibles = new char[] { key0, key1, key2, key3, key4, key5, key6,HealthChar, BuffChar};
        #endregion
        #region Walls
        public const char Wall0 = '░';
        public const char Wall1 = '╠';
        public const char Wall2 = '╩';
        public const char Wall3 = '╦';
        public const char Wall4 = '╬';
        public const char Wall5 = '═';
        public const char Wall6 = '╣';
        public static char[] Walls = new char[] {Wall0, Wall1, Wall2, Wall3, Wall4, Wall5, Wall6};
        #endregion

        public static int playerCol = 4;
        public static int playerRow = 4;
        public const int StartingHealth = 20;
        public const int MaxPlayerHealth = 60;
        public const int StartingLevel = 1;
        public const int itemCount = 12;

        #region EnemyInfo 
        public const int EnemyAtk = 5;
        public const char DuckChar = '♣';
        public const int DuckCount = 25;
        public const char GooseChar = '+';
        public const int GooseCount = 10;
        public const char LionChar = '&';
        public const int LionCount = 5;
        #endregion

        public static DateTime lastInputTime = DateTime.MinValue;
        public static TimeSpan inputDelay = TimeSpan.FromSeconds(0.1);
        public static Random random = new Random();
    }
}
