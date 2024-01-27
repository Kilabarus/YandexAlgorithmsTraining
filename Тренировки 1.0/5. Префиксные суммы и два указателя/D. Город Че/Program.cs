using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;


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

            StringBuilder output = new StringBuilder();

            int R = int.Parse(input[0].Split()[1]);

            var monuments = ConvertStringToListOfInt32(input[1]);

            int left = 0;
            int right = 0;
            
            BigInteger sumBetween = 0;
            BigInteger count = 0;
            while (right < monuments.Count)
            {
                count += left;
                sumBetween = monuments[right] - monuments[left];

                while (sumBetween > R)
                {
                    ++left;
                    sumBetween = monuments[right] - monuments[left];
                    ++count;
                }

                ++right;
            }

            while (sumBetween > R)
            {
                ++left;
                sumBetween = monuments[right] - monuments[left];
                ++count;
            }

            return $"{count}";
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}