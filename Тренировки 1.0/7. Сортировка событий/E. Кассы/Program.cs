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
            TOfficeClosed = 0,
            TOfficeOpened = 1,
            TOfficeClosedForReopening = 2
        }

        struct Time
        {
            public int Hour;
            public int Minute;
        }

        struct Event
        {
            public EventType Type;
            public Time Time;

            public string ToString()
            {
                return $"{Type} : {Time.Hour:f2}:{Time.Minute:f2}";
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

            int N = ConvertStringToListOfInt32(input[0])[0];

            int numOfOffices = N;
            List<Event> events = new();
            foreach (var tOffice in input.Skip(1).Take(N))
            {
                var times = ConvertStringToListOfInt32(tOffice);

                (int openHour, int openMinute, int closeHour, int closeMinute) 
                    = (times[0], times[1], times[2], times[3]);

                if (openHour == closeHour && openMinute == closeMinute)
                {
                    --numOfOffices;
                    continue;
                }                

                events.Add(new Event()
                {
                    Type = EventType.TOfficeOpened,
                    Time = new() { Hour = openHour, Minute = openMinute }
                });

                events.Add(new Event()
                {
                    Type = EventType.TOfficeClosed,
                    Time = new() { Hour = closeHour, Minute = closeMinute }
                });

                if (closeHour < openHour || (closeHour == openHour && closeMinute < openMinute))
                {
                    if (openHour == 0 && openMinute == 0 || closeHour == 0 && closeMinute == 0)
                    {
                        continue;
                    }

                    events.Add(new Event()
                    {
                        Type = EventType.TOfficeClosedForReopening,
                        Time = new() { Hour = 23, Minute = 59 }
                    });

                    events.Add(new Event()
                    {
                        Type = EventType.TOfficeOpened,
                        Time = new() { Hour = 0, Minute = 0 }
                    });
                }                                
            }

            if (numOfOffices == 0)
            {
                return $"{24 * 60}";
            }

            int currOpenedOffices = 0;
            int sumOfMinutes = 0;
            Time lastTimeOfficeOpened = new() { Hour = -1, Minute = -1 };
            foreach (var e in events.OrderBy(e => e.Time.Hour).ThenBy(e => e.Time.Minute).ThenBy(e => e.Type))
            {
                if (e.Type == EventType.TOfficeOpened)
                {
                    ++currOpenedOffices;
                    lastTimeOfficeOpened = e.Time;
                }

                if (e.Type == EventType.TOfficeClosed)
                {
                    if (currOpenedOffices == numOfOffices)
                    {
                        int hoursDelta = e.Time.Hour - lastTimeOfficeOpened.Hour;
                        int minutesDelta = e.Time.Minute - lastTimeOfficeOpened.Minute;

                        sumOfMinutes += hoursDelta * 60 + minutesDelta;
                    }

                    if (currOpenedOffices > 0)
                    {
                        --currOpenedOffices;
                    }
                }                
            }

            if (currOpenedOffices == numOfOffices)
            {
                int hoursDelta = 23 - lastTimeOfficeOpened.Hour;
                int minutesDelta = 60 - lastTimeOfficeOpened.Minute;

                sumOfMinutes += hoursDelta * 60 + minutesDelta;
            }

            return $"{sumOfMinutes}";
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}