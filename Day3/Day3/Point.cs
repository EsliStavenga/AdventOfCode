using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    class Point
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Steps { get; set; } 
        public Point intersectingPoint { get; set; }

        /// <summary>
        /// Distance from 0, 0
        /// </summary>
        public int Distance { get; private set; }

        public Point(int x, int y, int steps = 0)
        {
            this.X = x;
            this.Y = y;
            this.Steps = steps;

            this.calculateDistance();
        }

        private void calculateDistance()
        {
            this.Distance = Math.Abs(this.X) + Math.Abs(this.Y);
        }

    }
}
