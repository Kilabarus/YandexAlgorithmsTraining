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
            Died = 0,
            Turned18 = 1,
        }

        struct Event
        {
            public EventType Type;
            public DateOnly Time;
            public int PersonId;
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

            int id = 1;
            List<Event> events = new();
            foreach (var bdDates in input.Skip(1).Take(N))
            {
                var ints = ConvertStringToListOfInt32(bdDates);

                (int bDay, int bMonth, int bYear, int dDay, int dMonth, int dYear)
                    = (ints[0], ints[1], ints[2], ints[3], ints[4], ints[5]);

                DateOnly bDate = new(bYear, bMonth, bDay);
                DateOnly dDate = new(dYear, dMonth, dDay);

                DateOnly t18Date = bDate.AddYears(18);
                DateOnly t80Date = bDate.AddYears(80);

                if (dDate <= t18Date)
                {
                    ++id;
                    continue;
                }

                events.Add(new Event() { Time = t18Date, Type = EventType.Turned18, PersonId = id });

                dDate = t80Date < dDate ? t80Date : dDate;

                events.Add(new Event() { Time = dDate, Type = EventType.Died, PersonId = id });

                ++id;
            }

            bool newParticipant = false;
            HashSet<int> currParticipating = new();
            List<HashSet<int>> sets = new();
            foreach (var e in events.OrderBy(e => e.Time).ThenBy(e => e.Type))
            {
                if (e.Type == EventType.Turned18)
                {
                    currParticipating.Add(e.PersonId);
                    newParticipant = true;
                }

                if (e.Type == EventType.Died)
                {
                    if (newParticipant)
                    {
                        sets.Add(new(currParticipating));
                        newParticipant = false;
                    }

                    currParticipating.Remove(e.PersonId);
                }
            }

            if (sets.Count == 0)
            {
                return "0";
            }

            foreach (var set in sets)
            {
                foreach (var participant in set)
                {
                    output.Append($"{participant} ");
                }

                output.AppendLine();
            }

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}