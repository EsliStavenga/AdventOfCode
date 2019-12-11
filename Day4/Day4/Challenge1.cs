using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Challenge1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="groupOfExactlyTwo">Should there be at least one group of exactly 2 digits? (Challenge 2)</param>
        /// <returns></returns>
        public string Run(string input, bool groupOfExactlyTwo = true)
        {
            string[] limits = input.Split('-');
            int lowerLimit = int.Parse(limits[0]);
            int upperLimit = int.Parse(limits[1]);
            
            return calculateNumbersInRange(lowerLimit, upperLimit, groupOfExactlyTwo).ToString();
        }

        private int calculateNumbersInRange(int lowerLimit, int upperLimit, bool strict = true)
        {
            int options = 0;

            for(int i = lowerLimit; i < upperLimit; i++)
            {
                if(areDigitsDescending(i) && numberContainsDoubleDigit(i, strict))
                {
                    options++;
                }
            }

            return options;

        }

        private bool numberContainsDoubleDigit(int number, bool strict = true)        
        {
            IEnumerable<int> numCount = number.ToString().ToCharArray().GroupBy(x => x).Select(x => x.Count());

            return numCount.Where(x => (strict ? x == 2 : x >= 2)).Count() > 0;
        }

        private bool areDigitsDescending(int number)
        {
            int lastDigit = 0;
            int[] digits = number.ToString().Select(x => int.Parse(x.ToString())).ToArray();

            foreach (int digit in digits)
            {
                //if the current digit is larger than or equal to the currentDigit we can assume the number is still ascending
                if (digit >= lastDigit)
                {
                    lastDigit = digit;
                } else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
