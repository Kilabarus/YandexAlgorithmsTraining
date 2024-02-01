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

            StringBuilder output = new StringBuilder();

            var WHN = ConvertStringToListOfInt32(input[0]);
            int W = WHN[0];
            int H = WHN[1];
            int N = WHN[2];

            BigInteger bigSide = W > H ? W : H;

            BigInteger left = 0;
            BigInteger right = bigSide * N;
            BigInteger squareSide = 0;
            
            while (left < right)
            {
                squareSide = left + (right - left) / 2;

                BigInteger dsInRow = (long)Math.Floor((decimal)squareSide / W);
                BigInteger dsInColumn = (long)Math.Floor((decimal)squareSide / H);
                if (dsInRow * dsInColumn >= N)
                {
                    right = squareSide;
                    continue;
                }

                left = squareSide + 1;
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