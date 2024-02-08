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
            TStartsWatching = 0,
            TEndsWatching = 1,
        }

        struct Event
        {
            public EventType Type;
            public int StudentNumber;
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

            var NM = ConvertStringToListOfInt32(input[0]);
            (int N, int M) = (NM[0], NM[1]);

            var events = new List<Event>();

            foreach (var teacher in input.Skip(1).Take(M))
            {
                var be = ConvertStringToListOfInt32(teacher);
                (int b, int e) = (be[0], be[1]);

                events.Add(new Event() { Type = EventType.TStartsWatching, StudentNumber = b });
                events.Add(new Event() { Type = EventType.TEndsWatching, StudentNumber = e });
            }

            int currMonitoringTeachers = 0;
            int lastMonitored = -1;
            int count = 0;
            foreach (var tEvent in events.OrderBy(x => x.StudentNumber).ThenBy(x => x.Type))
            {
                if (tEvent.Type == EventType.TStartsWatching)
                {
                    if (currMonitoringTeachers == 0)
                    {
                        count += tEvent.StudentNumber - (lastMonitored + 1);
                    }

                    ++currMonitoringTeachers;
                    continue;
                }

                --currMonitoringTeachers;

                if (currMonitoringTeachers == 0)
                {
                    lastMonitored = tEvent.StudentNumber;
                }
            }

            if (currMonitoringTeachers == 0)
            {
                count += N - 1 - lastMonitored;
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