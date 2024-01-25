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

            int g = int.Parse(input[0].Split()[0]);

            Dictionary<char, int> wOriginal = new();
            foreach (char c in input[1])
            {
                if (!wOriginal.ContainsKey(c))
                {
                    wOriginal.Add(c, 0);
                }

                ++wOriginal[c];
            }            

            Dictionary<char, int> wPossible = new Dictionary<char, int>(wOriginal);

            int left = 0;
            int right = 0;

            int count = 0;

            string S = input[2];

            while (right < S.Length)
            {
                char c = S[right];

                if (right - left < g)
                {
                    if (!wOriginal.ContainsKey(c))
                    {
                        ++right;
                        left = right;

                        wPossible = new Dictionary<char, int>(wOriginal);
                        continue;
                    }

                    if (wPossible[c] == 0)
                    {
                        while (wPossible[c] == 0)
                        {
                            ++wPossible[S[left]];
                            ++left;
                        }

                        continue;
                    }

                    --wPossible[c];
                    ++right;

                    if (right - left == g)
                    {
                        ++count;
                        ++wPossible[S[left]];
                        ++left;
                    }

                    continue;
                }
            }

            return count.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}