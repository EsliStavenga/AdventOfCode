using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Challenge1
    {
        private List<Point> overlap;

        /// <summary>
        /// It takes quite a lot of time to calculate  all this, so that's why we use the constructor
        /// </summary>
        /// <param name="input"></param>
        public Challenge1(string input)
        {
            string[] wires = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<Point> firstWirePoints = getWirePoints(wires[0]);
            List<Point> secondWirePoints = getWirePoints(wires[1]);
            overlap = calculateOverlap(firstWirePoints, secondWirePoints);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="calcClosestPoint">if true, calculate the closest intersection. Otherwise calculate the intersection with the least amount of steps</param>
        /// <returns></returns>
        public string Run(bool calcClosestPoint = true)
        {
            if(calcClosestPoint)
            {
                Point closestPoint = calculateClosestPoint(overlap);
                return closestPoint.Distance.ToString();
            } else
            {
                Point closestPoint = calculateFewestStepsPoint(overlap);
                return (closestPoint.Steps + closestPoint.intersectingPoint.Steps).ToString();
            }

        }

        private Point calculateFewestStepsPoint(List<Point> overlap)
        {
            return overlap.OrderBy(x => x.Steps + x.intersectingPoint.Steps).First();
        }

        private List<Point> getWirePoints(string wire)
        {
            int curX = 0;
            int curY = 0;
            int steps = 0;
            List<Point> result = new List<Point>();

            string[] commands = wire.Split(',');
            foreach(string command in commands)
            {
                int xAdd = 0;
                int yAdd = 0;
                string direction = command.Substring(0, 1);
                int parts = int.Parse(command.Substring(1, command.Length - 1));

                //calculate the direction in which to move the wire
                if(direction == "U" || direction == "D")
                {
                    xAdd = (direction == "U" ? 1 : -1);
                } else
                {
                    yAdd = (direction == "L" ? -1 : 1);
                }

                //add that direction X amount of times
                for(int i = 0; i < parts; i++)
                {
                    result.Add(new Point(curX += xAdd, curY += yAdd, ++steps));
                }
            }

            return result;
        }

        private List<Point> calculateOverlap(List<Point> firstWirePoints, List<Point> secondWirePoints)
        {
            List<Point> overlappingPoints = new List<Point>();

            firstWirePoints.ForEach(fwPoint =>
            {
                secondWirePoints.ForEach(swPoint =>
                {
                    if(fwPoint.X == swPoint.X && fwPoint.Y == swPoint.Y)
                    {
                        fwPoint.intersectingPoint = swPoint;
                        overlappingPoints.Add(fwPoint); //if two points overlap, add it to the reuslt
                    }
                });
            });

            return overlappingPoints;
        }

        private Point calculateClosestPoint(List<Point> points)
        {
            return points.OrderBy(x => x.Distance).First();
        }
    }
}
