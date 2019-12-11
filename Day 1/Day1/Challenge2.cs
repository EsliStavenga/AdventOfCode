using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day1
{
    public class Challenge2
    {
        public string Run(string input)
        {
            //calculate the total amount of fuel needed
            int sum = 0;
            string[] result = Regex.Split(input, "\r\n|\r|\n");
            foreach (string line in result)
            {
                if (int.TryParse(line, out int mass))
                {
                    //to calculate fuel needed for the second challenge set recursive to true
                    sum += FuelMethods.calculateFuelByMass(mass, true);
                }
            }
            return sum.ToString();
        }  
    }
}
