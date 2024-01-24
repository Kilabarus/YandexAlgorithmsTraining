using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Immutable;


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
            
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }
            
            List<int> NM = ConvertStringToListOfInt32(input[0]);            
            int N = NM[0];
            int M = NM[1];

            SortedSet<int> anyaCubes = new SortedSet<int>();
            SortedSet<int> boryaCubes = new SortedSet<int>();

            for (int i = 1; i < input.Count; i++)
            {
                if (i <= N)
                {
                    anyaCubes.Add(int.Parse(input[i]));
                    continue;
                }

                boryaCubes.Add(int.Parse(input[i]));
            }

            void AddSetToOutput(IEnumerable<int> set)
            {
                output.AppendLine(set.Count().ToString());

                foreach (int i in set)
                {
                    output.Append($"{i} ");
                }

                output.Append('\n');
            }
            
            SortedSet<int> sameCubes = new SortedSet<int>(anyaCubes.Intersect(boryaCubes));

            AddSetToOutput(sameCubes);
            AddSetToOutput(anyaCubes.Except(sameCubes));
            AddSetToOutput(boryaCubes.Except(sameCubes));

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