using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace First_Playable
{

    public class Program
    
    {
        private MapData mapData; // Instance variable of type MapData

        private Buffer buffer; // Instance variable of type Buffer
        public Program()
        {
            mapData = new MapData(this);
            Player player= new Player(this);
            buffer = new Buffer();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            program.mapData.TxtFileToMapArray();
            program.mapData.DrawMap();
            program.buffer.DisplayBuffer();
            program.mapData.PrintMap();
            Console.ReadKey(false);
        }

   
    }
}