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
            CustomerEntered = 0,
            AdWatched = 1,            
            CustomerLeft = 2
        }

        struct Event
        {
            public EventType Type;
            public int Time;
            public int CustomerId;
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
                events.Add(new Event() { Type = EventType.CustomerLeft, Time = leaveTime - 5, CustomerId = customerId });
                
                events.Add(new Event() { Type = EventType.AdWatched, Time = enterTime, CustomerId = customerId });

                if (leaveTime - enterTime > 5)
                {
                    events.Add(new Event() { Type = EventType.AdWatched, Time = leaveTime - 5, CustomerId = customerId });
                }                

                ++customerId;
            }
            
            var ordEvents = events.OrderBy(e => e.Time).ThenBy(e => e.Type).ToList();

            int bestTime1 = -1;
            int bestTime2 = -1;

            int bestCount = 0;
            
            HashSet<int> customersCurrentlyInShop = new();
            for (int i = 0; i < ordEvents.Count; i++)
            {
                Event e = ordEvents[i];
                
                if (e.Type == EventType.CustomerEntered)
                {
                    customersCurrentlyInShop.Add(e.CustomerId);
                }

                if (e.Type == EventType.AdWatched)
                {
                    HashSet<int> customersToIgnore = new(customersCurrentlyInShop);
                    
                    int time1 = ordEvents[i].Time;                    
                    int count1 = customersToIgnore.Count;

                    int numOfNewCustomers = 0;
                    for (int j = i + 1; j < ordEvents.Count; j++)
                    {
                        Event innerE = ordEvents[j];

                        if (innerE.Type == EventType.CustomerEntered)
                        {
                            ++numOfNewCustomers;                            
                        }

                        if (innerE.Type == EventType.AdWatched)
                        {
                            int time2 = ordEvents[j].Time;

                            if (time2 - time1 < 5)
                            {
                                continue;
                            }

                            int count2 = numOfNewCustomers;

                            if (bestCount < count1 + count2)
                            {
                                bestTime1 = time1;
                                bestTime2 = time2;

                                bestCount = count1 + count2;
                            }
                        }

                        if (innerE.Type == EventType.CustomerLeft && !customersToIgnore.Contains(innerE.CustomerId))
                        {
                            --numOfNewCustomers;
                        }
                    }

                    if (bestCount < count1)
                    {
                        bestCount = count1;
                        
                        bestTime1 = time1;
                        bestTime2 = time1 + 5;
                    }
                }

                if (e.Type == EventType.CustomerLeft)
                {
                    customersCurrentlyInShop.Remove(e.CustomerId);
                }
            }

            if (bestCount == 0)
            {
                bestTime1 = 69;
                bestTime2 = 420;
            }

            if (bestCount == 1)
            {
                bestTime2 = bestTime1 + 1337;
            }

            return $"{bestCount} {bestTime1} {bestTime2}";
        }

        static void Main(string[] args)
        {            
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}