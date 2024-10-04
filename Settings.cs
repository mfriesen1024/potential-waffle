using untitled.Map;

namespace untitled
{
    internal class Settings
    {
        #region Collectibles
        public static int[][] keysXY =
        [
        new int[] { 8, 11 },//  key0XY
        new int[] { 24, 2 },//  key1XY
        new int[] { 24, 60 },// key2XY
        new int[] { 9, 54 },//  key3XY
        new int[] { 10, 31 },// key4XY
        new int[] { 2, 30 },//  key5XY
        new int[] { 19, 31 }//  key6XY
        ];
        public static int[][] WinLocation =
        [
            new int[] {19, 76 },
            new int[] {20, 76 },
            new int[] {21, 76 },
            new int[] {22, 76 },
            new int[] {23, 76 },
            new int[] {24, 76 },
            new int[] {25, 76 },
            new int[] {26, 76 },
            new int[] {27, 76 }
        ];
        public const ConsoleColor keyFG = ConsoleColor.Cyan;
        public const char key0c = '↔';
        public static Tile key0 { get { return new Tile() { character = key0c, foreground = keyFG }; } }
        public const char key1c = '>';
        public static Tile key1 { get { return new Tile() { character = key1c, foreground = keyFG }; } }
        public const char key2c = '^';
        public static Tile key2 { get { return new Tile() { character = key2c, foreground = keyFG }; } }
        public const char key3c = '←';
        public static Tile key3 { get { return new Tile() { character = key3c, foreground = keyFG }; } }
        public const char key4c = '↑';
        public static Tile key4 { get { return new Tile() { character = key4c, foreground = keyFG }; } }
        public const char key5c = '↓';
        public static Tile key5 { get { return new Tile() { character = key5c, foreground = keyFG }; } }
        public const char key6c = '→';
        public static Tile key6 { get { return new Tile() { character = key6c, foreground = keyFG }; } }
        public const char HealthChar = 'H';
        public static Tile HealthTile { get { return new Tile() { character = 'H', foreground = ConsoleColor.Red }; } }
        public const char BuffChar = 'A';
        public static Tile BuffTile { get { return new Tile() { character = 'A', foreground = ConsoleColor.Red }; } }
        public static Tile[] Collectibles = { key0, key1, key2, key3, key4, key5, key6, HealthTile, BuffTile };
        #endregion
        #region Walls
        public const char Wall0t = '░';
        public const char Wall1t = '╠';
        public const char Wall2t = '╩';
        public const char Wall3t = '╦';
        public const char Wall4t = '╬';
        public const char Wall5t = '═';
        public const char Wall6t = '╣';
        public static Tile Wall0 { get { return new Tile() { character = '░', hazard = 1 }; } }
        public static Tile Wall1 { get { return new Tile() { character = '╠', hazard = 1 }; } }
        public static Tile Wall2 { get { return new Tile() { character = '╩', hazard = 1 }; } }
        public static Tile Wall3 { get { return new Tile() { character = '╦', hazard = 1 }; } }
        public static Tile Wall4 { get { return new Tile() { character = '╬', hazard = 1 }; } }
        public static Tile Wall5 { get { return new Tile() { character = '═', hazard = 1 }; } }
        public static Tile Wall6 { get { return new Tile() { character = '╣', hazard = 1 }; } }
        public static Tile[] Walls = { Wall0, Wall1, Wall2, Wall3, Wall4, Wall5, Wall6 };
        #endregion
        #region Shops
        /// <summary>
        /// Represents weaponry, such that 0 is the strength, 1 is the price.
        /// </summary>
        public static int[][] weaponData = [
            [5,5],
            [10,15],
            [15,45]
            ];
        /// <summary>
        /// Represents which weapons (by index) each shop sells.
        /// </summary>
        public static int[][] shopInventories = [
            [0,1],
            [0,1,2],
            [1,2]
            ];
        /// <summary>
        /// Where each shop should
        /// </summary>
        public static int[][] shopLocations = [
            [5,10],
            [2,63],
            [9,23]
            ];
        public static Tile ShopTile
        {
            get => new Tile() { character = ShopChar, foreground = ConsoleColor.Black, background = ConsoleColor.DarkCyan };
        }
        private static char ShopChar = 'S';
        #endregion

        public static int playerCol = 4;
        public static int playerRow = 4;
        public static int playerLevel = 1;
        public static int StartingHealth = 100;
        public static int MaxPlayerHealth = StartingHealth + (playerLevel * 40);
        public const int StartingLevel = 1;
        public const int itemCount = 50;

        #region EnemyInfo 
        public static int NPCLevel = 1;
        public const int SmallEnemyHP = 5;
        public const int MediumEnemyHP = 10;
        public const int LargeEnemyHP = 15;
        public const char DuckChar = '♣';
        private const ConsoleColor foeColour = ConsoleColor.Green;
        internal static Tile DuckTile { get => duckTile.Clone(); }
        private static Tile duckTile = new Tile() { character = DuckChar, foreground = foeColour };
        public const int DuckCount = 25;
        public const char GooseChar = '+';
        internal static Tile GooseTile { get => gooseTile.Clone(); }
        private static Tile gooseTile = new Tile() { character = GooseChar, foreground = foeColour };
        public const int GooseCount = 25;
        public const char LionChar = '&';
        internal static Tile LionTile { get => lionTile.Clone(); }
        private static Tile lionTile = new Tile() { character = LionChar, foreground = foeColour };
        public const int LionCount = 10;
        #endregion
        public static Random random = new Random();
    }
}
