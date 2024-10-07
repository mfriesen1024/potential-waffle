using System.Diagnostics;

namespace untitled
{
    public static class Utils
    {
        /// <summary>
        /// Can be activated to forcibly disable the print function so it isn't visible in a release build.
        /// </summary>
        public static bool allowPrinting = false;

        /// <summary>
        /// Print an object.
        /// </summary>
        /// <param name="content">What to print.</param>
        /// <param name="waitWhenDone">Waits for a readkey before continuing.</param>
        public static void Print(object content, bool waitWhenDone = false)
        {
            if(allowPrinting)
            {
                Console.SetCursorPosition(0, 0);
                if (content is string)
                {
                    Console.Write(content as string);
                    Debug.WriteLine(content as string);
                }
                else
                {
                    Console.Write(content.ToString());
                    Debug.WriteLine(content.ToString());
                }

                if (waitWhenDone) Console.ReadKey(true);
            }
        }
    }
}
