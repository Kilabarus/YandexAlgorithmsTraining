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
            StringBuilder output = new StringBuilder();

            Dictionary<string, int> firstDuos = new Dictionary<string, int>();
            for (int i = 1; i < input[0].Length; i++)
            {
                string pair = $"{input[0][i - 1]}{input[0][i]}";
                
                if (firstDuos.ContainsKey(pair))
                {
                    firstDuos[pair]++;
                    continue;
                }

                firstDuos.Add(pair, 1);
            }

            HashSet<string> secondPairs = new HashSet<string>();
            for (int i = 1; i < input[1].Length; i++)
            {
                secondPairs.Add($"{input[1][i - 1]}{input[1][i]}");
            }

            int count = 0;
            foreach (string pair in firstDuos.Keys)
            {
                if (secondPairs.Contains(pair))
                {
                    count += firstDuos[pair];
                }
            }

            output.Append(count);
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