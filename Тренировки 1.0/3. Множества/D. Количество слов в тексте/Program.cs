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

            HashSet<string> set = new();
            foreach (string s in input)
            {
                foreach (string word in s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    set.Add(word);
                }
            }

            output.Append(set.Count());

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