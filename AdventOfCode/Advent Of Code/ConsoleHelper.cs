using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_Of_Code
{
    class ConsoleHelper
    {
        public static void WriteWarning(string line)
        {
            WriteColoredLine(line, ConsoleColor.Yellow, "WARNING");
        }

        public static void WriteError(string line)
        {
            WriteColoredLine(line, ConsoleColor.DarkRed, "ERROR");

        }

        public static void WriteLine(string line, string context = "INFO")
        {
            Console.WriteLine(string.Format("[{0}] {1} - {2}", DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), context.ToUpper(), line));
        }

        private static void WriteColoredLine(string line, ConsoleColor color = ConsoleColor.White, string context = "INFO")
        {
            ConsoleColor oldCol = Console.ForegroundColor;
            Console.ForegroundColor = color;
            ConsoleHelper.WriteLine(line, context);
            Console.ForegroundColor = oldCol;
        }
    }
}
