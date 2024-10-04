namespace untitled.Map
{
    internal class CBuffer
    {
        public Tile[,]? firstBuffer;
        public Tile[,]? secondBuffer;
        private MapData mapData;
        public void SetMapData(MapData mapData)
        {
            this.mapData = mapData;
        }

        public void DisplayBuffer()
        {
            for (int Y = 0; Y < firstBuffer?.GetLength(0); Y++)
            {

                for (int X = 0; X < firstBuffer.GetLength(1); X++)
                {
                    Tile MapElement = secondBuffer[Y, X] ?? new Tile();

                    if (MapElement is not null && MapElement.Equals(firstBuffer[Y, X]))
                    {
                        continue;
                    }
                    int Top = Y + 1;
                    int Left = X + 1;
                    Console.ForegroundColor = MapElement.foreground;
                    Console.BackgroundColor = MapElement.background;
                    Console.SetCursorPosition(Left, Top);
                    Console.Write(MapElement.character);
                }
            }
            Array.Copy(firstBuffer, secondBuffer, MapData.map.Length);
        }
    }
}