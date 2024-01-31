namespace First_Playable
{


internal class Buffer
    {
        public char[,] ?firstBuffer;
        public char[,] ?secondBuffer;





        public void DisplayBuffer()
        {
            for (int Y = 0; Y < firstBuffer?.GetLength(0); Y++)
            {

                for (int X = 0; X < firstBuffer.GetLength(1); X++)
                {
                    char MapElements = secondBuffer[Y, X];
                        
                    if (MapElements == firstBuffer[Y, X])
                    {
                        continue;
                    }
                    int Top = Y + 1;
                    int Left = X + 1;
                    switch (MapElements)
                    {
                        case '╭':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '─':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '╮':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '╯':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '╰':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '│':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┘':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┌':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┐':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '└':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '├':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┤':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┬':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┴':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '☻':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case '☙':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '♣':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '⅛':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '⅜':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '⅝':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '⅞':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                    }
                    Console.SetCursorPosition(Left, Top);
                    Console.Write(MapElements); 
                }
            }
        }
    }
}