using System.Diagnostics;

namespace untitled
{
    public static class Utils
    {
        /// <summary>
        /// Print an object.
        /// </summary>
        /// <param name="content">What to print.</param>
        /// <param name="waitWhenDone">Waits for a readkey before continuing.</param>
        public static void Print(object content, bool waitWhenDone = false)
        {
            Console.SetCursorPosition(0, 0);
            if(content is string)
            {
                Console.Write(content as string);
                Debug.WriteLine(content as string);
            }
            else
            {
                Console.Write(content.ToString());
                Debug.WriteLine(content.ToString());
            }

            if(waitWhenDone) Console.ReadKey(true);
        }
    }
}
