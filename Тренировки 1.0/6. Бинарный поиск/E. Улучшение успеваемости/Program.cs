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

        static string Solve(List<string> input)
        {
            BigInteger twos = BigInteger.Parse(input[0]);
            BigInteger threes = BigInteger.Parse(input[1]);
            BigInteger fours = BigInteger.Parse(input[2]);

            BigInteger left = 0;
            BigInteger right = twos + threes + fours;

            while (left < right)
            {
                BigInteger fives = (left + right) / 2;

                if ((2 * twos + 3 * threes + 4 * fours + 5 * fives) * 10 / (twos + threes + fours + fives) >= 35)
                {
                    right = fives;
                    continue;
                }

                left = fives + 1;
            }

            return $"{left}";
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}