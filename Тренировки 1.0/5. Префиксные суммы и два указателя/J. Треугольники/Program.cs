using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;


namespace YandexTraining
{
    internal class Program
    {
        const string LOCAL_INPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\input.txt";
        const string SERVER_INPUT_FILE = "input.txt";

        const string LOCAL_OUTPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\output.txt";
        const string SERVER_OUTPUT_FILE = "output.txt";

        static List<string> ReadInput() => File.Exists(LOCAL_INPUT_FILE)
            ? File.ReadAllLines(LOCAL_INPUT_FILE).ToList()
            : File.ReadAllLines(SERVER_INPUT_FILE).ToList();

        static void WriteOutput(string output)
        {
            string outputFile = File.Exists(LOCAL_OUTPUT_FILE)
                ? LOCAL_OUTPUT_FILE
                : SERVER_OUTPUT_FILE;

            File.WriteAllText(outputFile, output);
        }

        struct Point
        {
            public int X;
            public int Y;

            public Point(List<int> XY)
            {
                X = XY[0];
                Y = XY[1];
            }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public BigInteger GetSquaredDistanceTo(Point p) => (BigInteger)(X - p.X) * (X - p.X) + (BigInteger)(Y - p.Y) * (Y - p.Y);
        }

        static string Solve(List<string> input)
        {
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            int numOfPoints = int.Parse(input[0]);
            List<Point> points = new List<Point>(numOfPoints);
            for (int i = 1; i <= numOfPoints; i++)
            {
                var point = ConvertStringToListOfInt32(input[i]);
                points.Add(new Point(point));
            }

            BigInteger count = 0;
            for (int i = 0; i < numOfPoints; i++)
            {
                List<BigInteger> distances = new List<BigInteger>();
                HashSet<(BigInteger vX, BigInteger vY)> usedVectors = new HashSet<(BigInteger vX, BigInteger vY)>();
                for (int j = 0; j < numOfPoints; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    distances.Add(points[i].GetSquaredDistanceTo(points[j]));

                    BigInteger vectorX = points[i].X - (BigInteger)points[j].X;
                    BigInteger vectorY = points[i].Y - (BigInteger)points[j].Y;

                    if (usedVectors.Contains((vectorX, vectorY)))
                    {
                        --count;
                    }

                    usedVectors.Add((-vectorX, -vectorY));
                }

                distances.Sort();

                int left = 0;
                int right = 0;
                while (left < distances.Count)
                {
                    while (right < distances.Count && distances[left] == distances[right])
                    {
                        ++right;
                    }

                    count += right - left - 1;
                    ++left;
                }
            }

            return $"{count}";
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}