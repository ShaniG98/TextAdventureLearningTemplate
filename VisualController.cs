using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class VisualController
    {
        public static void Print(string text, int delay = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            //Console.WriteLine();
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void Continue()
        {

            Console.WriteLine("\n" + "Press any key to continue" + "\n");
            Console.ReadKey();
            ClearScreen();
        }

        public static void SetColour()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void SetDecisionColour()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void SetWinColour()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void SetLossColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
