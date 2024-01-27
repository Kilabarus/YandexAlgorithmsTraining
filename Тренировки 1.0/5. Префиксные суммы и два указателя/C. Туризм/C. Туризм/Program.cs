using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            const string INPUT_FILE = "input.txt";

            if (File.Exists(INPUT_FILE))
            {
                return File.ReadAllLines(INPUT_FILE).ToList();
            }

            List<string> input = new();
            do
            {
                input.Add(Console.ReadLine());
            } while (input[^1] != "");

            return input;
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

            List<Point> points = new List<Point>();

            int numberOfPoints = int.Parse(input[0]);
            foreach (var pointStr in input.Skip(1).Take(numberOfPoints))
            {
                var pointXY = ConvertStringToListOfInt32(pointStr);
                points.Add(new Point(pointXY[0], pointXY[1]));
            }

            // points.Sort();

            var ascPrefixSum = new List<int>(points.Count + 1) { 0 };
            var descPrefixSum = new List<int>(points.Count + 1) { 0 };

            int prevHeight = points[0].Y;
            foreach (var point in points)
            {
                if (point.Y > prevHeight)
                {
                    ascPrefixSum.Add(ascPrefixSum[^1] + point.Y - prevHeight);
                    descPrefixSum.Add(descPrefixSum[^1]);
                    prevHeight = point.Y;

                    continue;
                }

                ascPrefixSum.Add(ascPrefixSum[^1]);
                descPrefixSum.Add(descPrefixSum[^1] + prevHeight - point.Y);
                prevHeight = point.Y;
            }

            int numberOfTracks = int.Parse(input[1 + numberOfPoints]);
            foreach (var trackStr in input.Skip(1 + numberOfPoints + 1).Take(numberOfTracks))
            {
                var startFinish = ConvertStringToListOfInt32(trackStr);

                int start = startFinish[0];
                int finish = startFinish[1];

                if (start < finish)
                {
                    output.AppendLine($"{ascPrefixSum[finish] - ascPrefixSum[start]}");
                    continue;
                }

                output.AppendLine($"{descPrefixSum[start] - descPrefixSum[finish]}");
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