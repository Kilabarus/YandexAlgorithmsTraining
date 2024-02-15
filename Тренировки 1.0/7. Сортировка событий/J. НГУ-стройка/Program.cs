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
            EndOfBlock = 0,
            StartOfBlock = 1,
        }

        class Event
        {
            public EventType Type;
            public int X1, X2;
            public int Y1, Y2;
            public int Z;
            public int BlockNumber;
        }

        static string Solve(List<string> input)
        {
            static List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            StringBuilder output = new();

            var NWL = ConvertStringToListOfInt32(input[0]);
            (int N, int W, int L) = (NWL[0], NWL[1], NWL[2]);

            int blockNumber = 1;
            List<Event> events = new();
            foreach (var line in input.Skip(1).Take(N))
            {
                var coords = ConvertStringToListOfInt32(line);
                (int x1, int y1, int z1, int x2, int y2, int z2) 
                    = (coords[0], coords[1], coords[2], coords[3], coords[4], coords[5]);

                events.Add(new Event() 
                { 
                    Type = EventType.StartOfBlock, 
                    X1 = x1, Y1 = y1, 
                    X2 = x2, Y2 = y2, 
                    Z = z1, 
                    BlockNumber = blockNumber 
                });

                events.Add(new Event() 
                { 
                    Type = EventType.EndOfBlock, 
                    X1 = x1, Y1 = y1, 
                    X2 = x2, Y2 = y2, 
                    Z = z2,
                    BlockNumber = blockNumber
                });

                ++blockNumber;
            }

            int S = W * L;
            int currS = 0;                        
            HashSet<int> currBlocks = new();
            HashSet<int> minBlocks = new();
            foreach (var e in events.OrderBy(e => e.Z).ThenBy(e => e.Type))
            {
                if (e.Type == EventType.StartOfBlock)
                {
                    currBlocks.Add(e.BlockNumber);
                    currS += (e.Y2 - e.Y1) * (e.X2 - e.X1);

                    if (currS == S && (currBlocks.Count < minBlocks.Count || minBlocks.Count == 0))
                    {
                        minBlocks = new(currBlocks);
                    }
                }

                if (e.Type == EventType.EndOfBlock)
                {
                    currBlocks.Remove(e.BlockNumber);                    
                    currS -= (e.Y2 - e.Y1) * (e.X2 - e.X1);
                }
            }

            if (minBlocks.Count == 0)
            {
                return "NO";
            }

            output.AppendLine("YES");
            output.AppendLine($"{minBlocks.Count}");
            foreach (var block in minBlocks)
            {
                output.AppendLine($"{block}");
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