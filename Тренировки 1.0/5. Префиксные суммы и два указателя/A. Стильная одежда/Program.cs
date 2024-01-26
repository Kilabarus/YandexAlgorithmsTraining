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

            var shirts = ConvertStringToListOfInt32(input[1]);
            var trousers = ConvertStringToListOfInt32(input[3]);

            int currentShirt = 0;
            int currentTrousers = 0;

            int minDifference = Math.Abs(shirts[0] - trousers[0]);
            int bestShirt = 0;
            int bestTrousers = 0;

            while (currentShirt < shirts.Count && currentTrousers < trousers.Count)
            {
                int currentDifference = Math.Abs(shirts[currentShirt] - trousers[currentTrousers]);

                if (currentDifference < minDifference)
                {
                    bestShirt = currentShirt;
                    bestTrousers = currentTrousers;

                    minDifference = currentDifference;
                }

                if (shirts[currentShirt] < trousers[currentTrousers])
                {
                    ++currentShirt;
                    continue;
                }

                ++currentTrousers;
            }

            while (currentShirt < shirts.Count)
            {
                int currentDifference = Math.Abs(shirts[currentShirt] - trousers[currentTrousers - 1]);

                if (currentDifference < minDifference)
                {
                    bestShirt = currentShirt;
                    bestTrousers = currentTrousers - 1;

                    minDifference = currentDifference;
                }

                ++currentShirt;
            }

            while (currentTrousers < trousers.Count)
            {
                int currentDifference = Math.Abs(shirts[currentShirt - 1] - trousers[currentTrousers]);

                if (currentDifference < minDifference)
                {
                    bestShirt = currentShirt - 1;
                    bestTrousers = currentTrousers;

                    minDifference = currentDifference;
                }

                ++currentTrousers;
            }

            return $"{shirts[bestShirt]} {trousers[bestTrousers]}";
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}