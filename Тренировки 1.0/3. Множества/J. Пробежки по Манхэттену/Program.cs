using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;


namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            const string INPUT_FILE = "input.txt";

            return File.ReadAllLines(INPUT_FILE).ToList();
        }

        static void WriteOutput(string output)
        {
            const string OUTPUT_FILE = "output.txt";

            File.WriteAllText(OUTPUT_FILE, output);
        }

        struct Point
        {
            public int X; 
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static string Solve(List<string> input)
        {            
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            StringBuilder output = new StringBuilder();            
            
            int GetDistanceBetweenPoints(Point p1, Point p2)
            {
                return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
            }
            
            HashSet<Point> GetPossiblePoints(Point currentPoint, int maxSteps)
            {
                HashSet<Point> possiblePoints = new();

                for (int i = 0; i <= maxSteps; i++)
                {
                    int x = currentPoint.X;
                    int y = currentPoint.Y - maxSteps + i;

                    while (y <= currentPoint.Y)
                    {
                        possiblePoints.Add(new Point(x, y));
                        possiblePoints.Add(new Point(x, currentPoint.Y + (currentPoint.Y - y)));
                        possiblePoints.Add(new Point(currentPoint.X - (x - currentPoint.X), y));
                        possiblePoints.Add(new Point(currentPoint.X - (x - currentPoint.X), currentPoint.Y + (currentPoint.Y - y)));

                        ++x;
                        ++y;
                    }
                }

                return possiblePoints;
            }

            List<int> TDN = ConvertStringToListOfInt32(input[0]);
            (int T, int D, int N) = (TDN[0], TDN[1], TDN[2]);

            HashSet<Point> possiblePoints = new HashSet<Point>()
            {
                new Point(0, 0)
            };

            for (int i = 1; i <= N; i++)
            {
                HashSet<Point> t = new();

                foreach (var point in possiblePoints)
                {
                    t = new(t.Union(GetPossiblePoints(point, T)));
                }

                possiblePoints = t;

                List<int> XY = ConvertStringToListOfInt32(input[i]);
                HashSet<Point> newPossiblePoints = GetPossiblePoints(new Point(XY[0], XY[1]), D);

                possiblePoints = new(possiblePoints.Intersect(newPossiblePoints));                
            }

            output.AppendLine(possiblePoints.Count().ToString());

            foreach (var point in possiblePoints)
            {
                output.AppendLine($"{point.X} {point.Y}");
            }

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}