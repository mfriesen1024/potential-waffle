using System.IO;


namespace First_Playable
{

    public class Program
    {
        private MapData mapData; // Instance variable of type MapData
        private Buffer buffer; // Instance variable of type Buffer
        
        public Program()
        {
            mapData = new MapData();

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            program.TxtFileToMapArray();
            Console.ReadKey(true);
        }


        public void TxtFileToMapArray()
        {
        buffer = new Buffer();
        string[] lines = File.ReadAllLines("Map.txt");
        buffer.firstBuffer = new char[lines.GetLength(0), lines[0].Length];
        buffer.secondBuffer = new char[lines.GetLength(0), lines[0].Length];
        mapData.map = new char[lines.GetLength(0), lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    mapData.map[i, j] = lines[i][j]; 
                }
            }
        }
    }
}