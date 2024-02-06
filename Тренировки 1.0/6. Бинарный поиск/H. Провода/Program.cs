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

            var NK = ConvertStringToListOfInt32(input[0]);
            (BigInteger N, BigInteger K) = (NK[0], NK[1]);

            var L = input.Skip(1).Take(input.Count - 1).Select(int.Parse);

            BigInteger left = 0;
            BigInteger right = K * L.Max();            

            while (left < right)
            {
                BigInteger middle = (left + right + 1) / 2;
                int numOfSections = L.Sum(x => (int)(x / middle));

                if (numOfSections >= K)
                {
                    left = middle;
                    continue;
                }

                right = middle - 1;
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