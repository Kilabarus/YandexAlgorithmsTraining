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

            var NK = ConvertStringToListOfInt32(input[0]);
            BigInteger N = NK[0];
            BigInteger K = NK[1];

            var numbers = ConvertStringToListOfInt32(input[1]);

            int left = 0;
            int right = 0;
            BigInteger sumBetween = 0;
            
            int count = 0;
            while (right < numbers.Count)
            {
                sumBetween += numbers[right];
                ++right;
                
                while (sumBetween > K)
                {
                    sumBetween -= numbers[left];
                    ++left;
                }                
                
                if (sumBetween == K)
                {
                    ++count;

                    sumBetween -= numbers[left];
                    ++left;
                }                
            }

            while (sumBetween > K)
            {
                sumBetween -= numbers[left];
                ++left;
            }

            if (sumBetween == K)
            {
                ++count;
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