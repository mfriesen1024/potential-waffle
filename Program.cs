using System.Diagnostics;
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

            program.mapData.TxtFileToMapArray();
            program.mapData.DrawMap();
            program.mapData.PrintMap();
            Console.ReadKey(false);
        }

   
    }
}