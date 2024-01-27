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

            if (File.Exists(INPUT_FILE))
            {
                return File.ReadAllLines(INPUT_FILE).ToList();
            }

            List<string> input = new();
            do
            {
                input.Add(Console.ReadLine());
            } while (input[^1] != "");

            return input;
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

            int K = int.Parse(input[0].Split()[1]);

            Dictionary<int, int> treesOccurances = new Dictionary<int, int>();

            for (int i = 1; i <= K; i++)
            {
                treesOccurances.Add(i, 0);
            }

            HashSet<int> foundTrees = new();

            int minLeft = -1;
            int minRight = -1;
            int minLength = int.MaxValue;

            int left = 0;
            int right = 0;
            var trees = ConvertStringToListOfInt32(input[1]);

            while (right < trees.Count)
            {
                while (foundTrees.Count < K && right < trees.Count)
                {
                    foundTrees.Add(trees[right]);
                    ++treesOccurances[trees[right]];
                    ++right;
                }

                if (foundTrees.Count == K)
                {
                    while (treesOccurances[trees[left]] > 1)
                    {
                        --treesOccurances[trees[left]];
                        ++left;
                    }

                    if (right - left < minLength)
                    {
                        minLength = right - left;
                        minLeft = left + 1;
                        minRight = right;
                    }

                    foundTrees.Remove(trees[left]);
                    treesOccurances[trees[left]] = 0;
                    ++left;
                }
            }

            return $"{minLeft} {minRight}";
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}