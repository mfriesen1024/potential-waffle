using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{

    internal class Program
    {
        private readonly MapData mapData;
        private readonly Player player;
        private readonly Buffer buffer;

        public Program(MapData mapData, Player player, Buffer buffer)
        {
            this.mapData = mapData;
            this.player = player;
            this.buffer = buffer;
        }

        // Method Injection
        void ProcessData()
        {
            mapData.TxtFileToMapArray();
            buffer.DisplayBuffer();
            mapData.PrintMap();
        }

        static void Main(string[] args)
        {
            MapData mapData = new MapData();
            Player player = new Player();
            Buffer buffer = new Buffer();

            Program program = new Program(mapData, player, buffer);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            program.ProcessData();

            Console.ReadKey(false);
        }




        //private MapData mapData; // Instance variable of type MapData
        //private Player player;
        //private Buffer buffer; // Instance variable of type Buffer
        //public Program()
        //{
        //    mapData = new MapData();
        //    player= new Player();
        //    buffer = new Buffer();
        //}
        //static void Main(string[] args)
        //{
        //    Program program = new Program();
        //    Console.OutputEncoding = System.Text.Encoding.UTF8;

        //    program.mapData.TxtFileToMapArray();
        //    program.buffer.DisplayBuffer();
        //    program.mapData.PrintMap();
        //    Console.ReadKey(false);
        //}


    }
}