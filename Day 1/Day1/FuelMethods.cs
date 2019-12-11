using System;

namespace Day1
{
    public class FuelMethods
    {

        /// <summary>
        /// Calculate the fuel needed to lift off this mass
        /// </summary>
        /// <param name="mass">The mass of the object to lift off</param>
        /// <param name="recursive">Calculate the fuel needed to lift off the fuel that's needed to lift off the mass</param>
        /// <returns>The total amount of fuel needed</returns>
        public static int calculateFuelByMass(int mass, bool recursive = true)
        {
            int fuelNeeded = (int)Math.Floor((float)mass / 3) - 2;
            if (recursive && fuelNeeded > 0)
            {
                fuelNeeded += calculateFuelByMass(fuelNeeded, recursive);
            }

            return Math.Max(0, fuelNeeded);
        }
    }
}
