namespace First_Playable
{


    public class MapData
    {
        private Buffer buffer;
        public char[,] ?map;

        public MapData()
        {
            buffer = new Buffer();


        }

        public void DrawMap()
        {
            Array.Copy(map, buffer.secondBuffer, map.Length);
        }
    }






}