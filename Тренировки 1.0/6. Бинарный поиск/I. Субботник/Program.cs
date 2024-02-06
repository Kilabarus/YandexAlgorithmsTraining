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
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            var NRC = ConvertStringToListOfInt32(input[0]);
            (BigInteger N, BigInteger R, BigInteger C) = (NRC[0], NRC[1], NRC[2]);

            var stHeights = input.Skip(1).Take((int)N).Select(BigInteger.Parse).ToList();
            stHeights.Sort();
            
            BigInteger left = 0;
            BigInteger right = stHeights[^1];
            while (left < right)
            {
                BigInteger middle = (left + right) / 2;

                int leftWindow = 0;
                int rightWindow = (int)C - 1;
                int numOfGroups = 0;
                while (rightWindow < stHeights.Count && numOfGroups < R)
                {
                    if (stHeights[rightWindow] - stHeights[leftWindow] > middle)
                    {
                        ++leftWindow;
                        ++rightWindow;

                        continue;
                    }

                    ++numOfGroups;
                    leftWindow = rightWindow + 1;
                    rightWindow = leftWindow + (int)C - 1;
                }

                if (numOfGroups >= R)
                {
                    right = middle;
                    continue;
                }

                left = middle + 1;
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