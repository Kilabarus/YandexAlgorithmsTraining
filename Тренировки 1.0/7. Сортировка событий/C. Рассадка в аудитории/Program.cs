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
            Student = 0,
            IntEnd = 1
        }

        struct Event
        {
            public EventType Type;
            public int Desk;            
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

            var ND = ConvertStringToListOfInt32(input[0]);
            (int N, int D) = (ND[0], ND[1]);

            var studentDesks = ConvertStringToListOfInt32(input[1]);

            var events = new List<Event>();
            var deskToVariant = new Dictionary<int, int>();
            foreach (var studentDesk in studentDesks)
            {
                deskToVariant.Add(studentDesk, -1);
                
                events.Add(new Event() { Type = EventType.Student, Desk = studentDesk });
                events.Add(new Event() { Type = EventType.IntEnd, Desk = studentDesk + D });
            }

            Stack<int> vars = new();
            for (int i = N; i > 0; i--)
            {
                vars.Push(i);
            }

            foreach (var e in events.OrderBy(e => e.Desk).ThenBy(e => e.Type))
            {
                if (e.Type == EventType.Student)
                {
                    deskToVariant[e.Desk] = vars.Pop();
                    continue;
                }

                if (e.Type == EventType.IntEnd)
                {
                    vars.Push(deskToVariant[e.Desk - D]);
                }
            }

            output.AppendLine($"{deskToVariant.Values.Max()}");
            foreach (var studentDesk in studentDesks)
            {
                output.Append($"{deskToVariant[studentDesk]} ");
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