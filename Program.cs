namespace First_Playable
{

    public class Program
    {
        private MapData mapData; // Instance variable of type MapData
        private Program program; // Instance variable of type Program
        
        public Program()
        {
            mapData = new MapData();

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            program.TxtFileToMapArray();
        }


        public void TxtFileToMapArray()
        {
            string[] lines = File.ReadAllLines("Map.txt");
            // Buffer info
            mapData.map = new char[lines.GetLength(0), lines[0].Length];
            // for (int i = 0; i < lines.GetLength(0); i++)
            // {
            //     for (int j = 0; j < lines[i].Length; j++)
            //     {
            //         MapData.map[i, j] = lines[i][j];
            //     }
            // }
        }
    }
}