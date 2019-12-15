using IntcodeComputer;
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
            string dayFiveInput = FileController.GetFileContents(string.Format(INPUT_BASE_PATH, "5"));

            dayOne(dayOneInput);
            dayTwo(dayTwoInput);
            //dayThree(dayThreeInput);
            dayFour(dayFourInput);
            dayFive(dayFiveInput);

        }

        private static void dayOne(string input)
        {
            //day one
            ConsoleHelper.WriteLine((new Day1.Challenge1()).Run(input));
            ConsoleHelper.WriteLine((new Day1.Challenge2()).Run(input));
        }

        private static void dayTwo(string input)
        {
            Computer computer = new Computer {
                Commands = String.Format(input, 12, 2)
            };

            //calculate day two output
            int output;
            int verb = 0; // address 2
            int noun = 0; // address 1
            do
            {
                computer.Commands = string.Format(input, noun, verb);
                output = computer.Run()[0];
                if (noun == 99)
                {
                    noun = 0;
                    verb++;
                }
                noun++;
            } while (output != 19690720 && verb <= 99);

            ConsoleHelper.WriteLine(computer.Run()[0].ToString());
            ConsoleHelper.WriteLine("Old output " + new Day2.Challenge1().Run(string.Format(input, 12, 2)));
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
            ConsoleHelper.WriteLine(new Day4.Challenge1().Run(input, false));
            ConsoleHelper.WriteLine(new Day4.Challenge1().Run(input, true));
        }

        private static void dayFive(string input)
        {
            Computer computer = new Computer();
            computer.Commands = string.Format(input, 2, 2);
            computer.Run();
        }
    }
}
