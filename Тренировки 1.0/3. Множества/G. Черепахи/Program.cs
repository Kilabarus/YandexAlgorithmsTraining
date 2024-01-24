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

            return File.ReadAllLines(INPUT_FILE).ToList();
        }

        static void WriteOutput(string output)
        {
            const string OUTPUT_FILE = "output.txt";

            File.WriteAllText(OUTPUT_FILE, output);
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

            int numberOfTortoises = int.Parse(input[0]);
            HashSet<int> occupiedPlaces = new HashSet<int>();

            for (int i = 1; i <= numberOfTortoises; i++)
            {
                List<int> l = ConvertStringToListOfInt32(input[i]);

                int ahead = l[0];
                int behind = l[1];

                if (ahead >= 0 && behind >= 0
                    && ahead + behind == numberOfTortoises - 1 
                    && !occupiedPlaces.Contains(ahead + 1))
                {
                    occupiedPlaces.Add(ahead + 1);
                }
            }

            output.Append(occupiedPlaces.Count());

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