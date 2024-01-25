using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;


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

        struct DiagonalRectangle
        {
            public int d1;
            public int d2;
            public int d3;
            public int d4;

            public void Extend(int steps)
            {
                d1 += steps;
                d2 -= steps;
                d3 -= steps;
                d4 += steps;
            }

            public DiagonalRectangle Intersect(DiagonalRectangle diagonalRectangle)
            {
                return new DiagonalRectangle()
                {
                    d1 = Math.Min(d1, diagonalRectangle.d1),
                    d2 = Math.Max(d2, diagonalRectangle.d2),
                    d3 = Math.Max(d3, diagonalRectangle.d3),
                    d4 = Math.Min(d4, diagonalRectangle.d4),
                };
            }

            public HashSet<Point> GetPointsInside()
            {
                HashSet<Point> result = new();

                for (int i = d3; i <= d1; i++)
                {
                    for (int j = d2; j <= d4; j++)
                    {
                        if ((i + j) % 2 == 0)
                        {
                            int X = (i + j) / 2;
                            int Y = i - X;

                            result.Add(new Point(X, Y));
                        }
                    }
                }

                return result;
            }
        }

        // Диагональный ужас
        static string Solve(List<string> input)
        {            
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            StringBuilder output = new StringBuilder();

            List<int> TDN = ConvertStringToListOfInt32(input[0]);
            (int T, int D, int N) = (TDN[0], TDN[1], TDN[2]);

            DiagonalRectangle dR = new DiagonalRectangle()
            {
                d1 = 0,
                d2 = 0,
                d3 = 0,
                d4 = 0,
            };

            foreach (string s in input.Skip(1).Take(input.Count - 1)) 
            {
                dR.Extend(T);

                List<int> XY = ConvertStringToListOfInt32(s);
                DiagonalRectangle newDR = new DiagonalRectangle()
                {
                    d1 = XY[0] + XY[1],
                    d2 = XY[0] - XY[1],
                    d3 = XY[0] + XY[1],
                    d4 = XY[0] - XY[1],
                };

                newDR.Extend(D);

                dR = dR.Intersect(newDR);
            }

            HashSet<Point> result = dR.GetPointsInside();

            output.AppendLine(result.Count().ToString());

            foreach (var point in result)
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