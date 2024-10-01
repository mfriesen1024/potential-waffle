namespace untitled
{
    public static class Utils
    {
        /// <summary>
        /// Print an object.
        /// </summary>
        /// <param name="content">What to print.</param>
        /// <param name="waitWhenDone">Waits for a readkey before continuing.</param>
        static void Print(object content, bool waitWhenDone = false)
        {
            if(content is string)  Console.WriteLine(content as string); 
            else Console.WriteLine(content.ToString());

            if(waitWhenDone) Console.ReadKey(true);
        }
    }
}
