using System;
using System.IO;

namespace Advent_Of_Code
{
    class Program
    {

        private const string INPUT_BASE_URL = "https://adventofcode.com/2019/day/{0}/input";
        private static string INPUT_BASE_PATH = Directory.GetCurrentDirectory() + "\\input\\{0}.txt";

        static void Main(string[] args)
        {
            string dayOneInput = FileController.GetFileContents(string.Format(INPUT_BASE_PATH, "1"));
            string dayTwoInput = FileController.GetFileContents(string.Format(INPUT_BASE_PATH, "2"));
            string dayThreeInput = FileController.GetFileContents(string.Format(INPUT_BASE_PATH, "3"));
            string dayFourInput = FileController.GetFileContents(string.Format(INPUT_BASE_PATH, "4"));

            dayOne(dayOneInput);
            dayTwo(dayTwoInput);
            //dayThree(dayThreeInput);
            dayFour(dayFourInput);

        }

        private static void dayOne(string input)
        {
            //day one
            ConsoleHelper.WriteLine((new Day1.Challenge1()).Run(input));
            ConsoleHelper.WriteLine((new Day1.Challenge2()).Run(input));
        }

        private static void dayTwo(string input)
        {
            //calculate day two output
            string output;
            int verb = 0; // address 2
            int noun = 0; // address 1
            do
            {
                output = new Day2.Challenge1().Run(string.Format(input, noun, verb));
                if (noun == 99)
                {
                    noun = 0;
                    verb++;
                }
                noun++;
            } while (output != "19690720" && verb <= 99);

            ConsoleHelper.WriteLine(new Day2.Challenge1().Run(string.Format(input, 12, 2)));
            ConsoleHelper.WriteLine(string.Format("{0} - 100 * {1} + {2} = {3}", output, noun, verb, 100 * noun + verb));
        }

        private static void dayThree(string input)
        {
            Day3.Challenge1 day3 = new Day3.Challenge1(input);

            ConsoleHelper.WriteLine(day3.Run());
            ConsoleHelper.WriteLine(day3.Run(false));
        }
        private static void dayFour(string input)
        {
            ConsoleHelper.WriteLine(new Day4.Challenge1().Run(input));
        }
    }
}
