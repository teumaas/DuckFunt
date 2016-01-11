using System;

namespace SpaceHunt
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceHunt game = new SpaceHunt())
            {
                game.Run();
            }
        }
    }
#endif
}

