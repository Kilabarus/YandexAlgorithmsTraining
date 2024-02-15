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
            RouteEnd = 0,
            RouteStart = 1,
        }

        class Event
        {
            public EventType Type;
            public int City;
            public int Hour;
            public int Minute;
            public int RouteId;
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

            List<Event> events = new();
            foreach (var route in input.Skip(1).Take(M))
            {
                var routeParts = route.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var sHourMinute = routeParts[1].Split(':');
                var eHourMinute = routeParts[3].Split(':');

                events.Add(new Event()
                {
                    Type = EventType.RouteStart,
                    City = int.Parse(routeParts[0]),
                    Hour = int.Parse(sHourMinute[0]),
                    Minute = int.Parse(sHourMinute[1]),
                    RouteId = events.Count
                });

                events.Add(new Event()
                {
                    Type = EventType.RouteEnd,
                    City = int.Parse(routeParts[2]),
                    Hour = int.Parse(eHourMinute[0]),
                    Minute = int.Parse(eHourMinute[1]),
                    RouteId = events.Count - 1
                });
            }

            events.Sort((a, b) => a.Hour != b.Hour
                ? a.Hour.CompareTo(b.Hour)
                : a.Minute != b.Minute
                    ? a.Minute.CompareTo(b.Minute)
                    : a.Type.CompareTo(b.Type));

            Dictionary<int, int> cityBalance = new();
            foreach (var e in events)
            {
                if (e.Type == EventType.RouteStart)
                {
                    if (!cityBalance.ContainsKey(e.City))
                    {
                        cityBalance.Add(e.City, 0);
                    }

                    cityBalance[e.City]--;
                }

                if (e.Type == EventType.RouteEnd)
                {
                    if (!cityBalance.ContainsKey(e.City))
                    {
                        cityBalance.Add(e.City, 0);
                    }

                    cityBalance[e.City]++;
                }
            }

            if (cityBalance.Any(x => x.Value < 0))
            {
                return "-1";
            }

            int numOfBuses = 0;
            cityBalance = new();
            HashSet<int> startedRoutes = new();
            foreach (var e in events)
            {
                if (e.Type == EventType.RouteStart)
                {
                    if (!cityBalance.ContainsKey(e.City))
                    {
                        cityBalance.Add(e.City, 0);
                    }

                    startedRoutes.Add(e.RouteId);

                    if (cityBalance[e.City] == 0)
                    {
                        numOfBuses++;
                        continue;
                    }

                    cityBalance[e.City]--;
                }

                if (e.Type == EventType.RouteEnd)
                {
                    if (!startedRoutes.Contains(e.RouteId))
                    {
                        continue;
                    }

                    if (!cityBalance.ContainsKey(e.City))
                    {
                        cityBalance.Add(e.City, 0);
                    }

                    cityBalance[e.City]++;
                }
            }

            foreach (var e in events)
            {
                if (e.Type == EventType.RouteStart)
                {
                    if (!cityBalance.ContainsKey(e.City))
                    {
                        cityBalance.Add(e.City, 0);
                    }                    

                    if (cityBalance[e.City] == 0)
                    {
                        numOfBuses++;
                        continue;
                    }

                    cityBalance[e.City]--;
                }

                if (e.Type == EventType.RouteEnd)
                {                    
                    if (!cityBalance.ContainsKey(e.City))
                    {
                        cityBalance.Add(e.City, 0);
                    }

                    cityBalance[e.City]++;
                }
            }

            return $"{numOfBuses}";
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}