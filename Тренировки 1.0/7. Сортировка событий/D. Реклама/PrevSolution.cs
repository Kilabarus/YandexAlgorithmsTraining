using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace YandexTraining
{
    internal class PrevSolution
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
            CustomerEntered = 0,
            AdFinished = 1,
            CustomerLeft = 2
        }

        struct Event
        {
            public EventType Type;
            public int Time;
            public int CustomerId;
        }

        static (HashSet<int> chosenCustomers, int BestTime) ChooseBestTime(List<Event> events, HashSet<int> prevChosenCustomers, int prevBestTime = -1)
        {
            int bestTime = -1;

            HashSet<int> currCustomers = new();
            HashSet<int> chosenCustomers = new();

            Dictionary<int, HashSet<int>> d = new();
            foreach (var e in events)
            {
                if (e.Type == EventType.CustomerEntered)
                {
                    currCustomers.Add(e.CustomerId);

                    if (!d.ContainsKey(e.Time))
                    {
                        d.Add(e.Time, new HashSet<int>(currCustomers));
                        continue;
                    }

                    d[e.Time] = new HashSet<int>(currCustomers);
                }

                if (e.Type == EventType.AdFinished)
                {
                    int possBestTime = e.Time - 5;

                    if (prevBestTime != -1)
                    {
                        if (prevBestTime + 5 > possBestTime && prevBestTime < possBestTime + 5)
                        {
                            continue;
                        }
                    }

                    var prevCustomers = d[e.Time - 5];
                    var adCustomers = prevCustomers.Intersect(currCustomers).Except(prevChosenCustomers).ToHashSet();

                    if (adCustomers.Count > chosenCustomers.Count)
                    {
                        chosenCustomers = new(adCustomers);
                        bestTime = e.Time - 5;
                    }
                }

                if (e.Type == EventType.CustomerLeft)
                {
                    currCustomers.Remove(e.CustomerId);
                }
            }

            return (chosenCustomers, bestTime);
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

            int N = ConvertStringToListOfInt32(input[0])[0];

            int customerId = 0;
            var events = new List<Event>();
            foreach (var customer in input.Skip(1).Take(N))
            {
                var times = ConvertStringToListOfInt32(customer);
                (int enterTime, int leaveTime) = (times[0], times[1]);

                if (leaveTime - enterTime < 5)
                {
                    continue;
                }

                events.Add(new Event() { Type = EventType.CustomerEntered, Time = enterTime, CustomerId = customerId });
                events.Add(new Event() { Type = EventType.CustomerEntered, Time = enterTime + 5, CustomerId = customerId });
                events.Add(new Event() { Type = EventType.CustomerLeft, Time = leaveTime, CustomerId = customerId });

                events.Add(new Event() { Type = EventType.AdFinished, Time = enterTime + 5, CustomerId = customerId });
                events.Add(new Event() { Type = EventType.AdFinished, Time = enterTime + 10, CustomerId = customerId });

                ++customerId;
            }

            var ordEvents = events.OrderBy(e => e.Time).ThenBy(e => e.Type).ToList();

            (var chosenCustomers1, int bestTime1) = ChooseBestTime(ordEvents, new());

            if (bestTime1 == -1)
            {
                return $"0 0 10";
            }

            //ordEvents.RemoveAll(e => chosenCustomers1.Contains(e.CustomerId));                                  

            (var chosenCustomers2, int bestTime2) = ChooseBestTime(ordEvents, chosenCustomers1, bestTime1);

            if (bestTime2 == -1)
            {
                bestTime2 = bestTime1 + 10;
            }

            if (bestTime1 > bestTime2)
            {
                (bestTime1, bestTime2) = (bestTime2, bestTime1);
            }

            return $"{chosenCustomers1.Count + chosenCustomers2.Count} {bestTime1} {bestTime2}";
        }

        static void S(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}