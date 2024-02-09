using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


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

        enum EventType
        {
            IntBegin = 0,
            Point = 1,
            IntEnd = 2
        }

        struct Event
        {
            public EventType Type;
            public int Coord;
        }

        static string Solve(List<string> input)
        {
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            StringBuilder output = new();

            var NM = ConvertStringToListOfInt32(input[0]);
            (int N, int M) = (NM[0], NM[1]);

            var events = new List<Event>();
            foreach (var intervalStr in input.Skip(1).Take(N))
            {
                var AB = ConvertStringToListOfInt32(intervalStr);
                (int A, int B) = (AB[0], AB[1]);

                if (A > B)
                {
                    (A, B) = (B, A);
                }

                events.Add(new Event() { Type = EventType.IntBegin, Coord = A });
                events.Add(new Event() { Type = EventType.IntEnd, Coord = B });
            }

            var points = ConvertStringToListOfInt32(input[1 + N]);
            var pointToNumOfIntervals = new Dictionary<int, int>();
            foreach (var point in points)
            {
                if (!pointToNumOfIntervals.ContainsKey(point))
                {
                    pointToNumOfIntervals.Add(point, 0);
                    events.Add(new Event() { Type = EventType.Point, Coord = point });
                }
            }
            
            int currNumOfIntervals = 0;
            foreach (var e in events.OrderBy(x => x.Coord).ThenBy(x => x.Type))
            {
                if (e.Type == EventType.IntBegin)
                {
                    ++currNumOfIntervals;
                    continue;
                }

                if (e.Type == EventType.IntEnd)
                {
                    --currNumOfIntervals;
                    continue;
                }

                pointToNumOfIntervals[e.Coord] = currNumOfIntervals;
            }

            foreach (var point in points)
            {
                output.Append($"{pointToNumOfIntervals[point]} ");
            }

            return output.ToString().TrimEnd();
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}