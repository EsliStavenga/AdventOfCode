using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Day2
{
    public class Challenge1
    {

        private enum OPCODES { ADDITION = 1, MULTIPLY = 2, STOP = 99  }

        public string Run(string input)
        {
            int intcode = 0;
            int index = 0;
            int[] intcodes = input.Split(',').Select(x => int.Parse(x)).ToArray();
            while ((intcode = intcodes.ElementAt(index)) != (int) OPCODES.STOP)
            {
                //get input of this sequence
                int inputOne = intcodes.ElementAt(intcodes.ElementAt(index + 1));
                int inputTwo = intcodes.ElementAt(intcodes.ElementAt(index + 2));
                int result = 0;

                //calculate sum of this sequence
                if (intcode == (int)OPCODES.ADDITION)
                {
                    result = inputOne + inputTwo;
                }
                else if (intcode == (int)OPCODES.MULTIPLY) 
                {
                    result = inputOne * inputTwo;
                }
                //write result to  this position specified by 4th int of the sequence
                intcodes[intcodes.ElementAt(index + 3)] = result;
                index += 4;
            }

            //return the first int
            return intcodes[0].ToString();
        }

    }
}
