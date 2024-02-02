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
            List<long> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(long.Parse)
                           .ToList();
            }
            
            var NABWH = ConvertStringToListOfInt32(input[0]);

            (long N, long A, long B, long W, long H) = (NABWH[0], NABWH[1], NABWH[2], NABWH[3], NABWH[4]);

            BigInteger left = 0;
            BigInteger right = W < H ? W : H;

            while (left < right)
            {
                BigInteger middle = (left + right + 1) / 2;

                BigInteger houseWidth = A + 2 * middle;
                BigInteger houseLength = B + 2 * middle;

                BigInteger maxNumOfHousesInRow = W / houseWidth;
                BigInteger maxNumOfHousesInColumn = H / houseLength;

                if (maxNumOfHousesInColumn * maxNumOfHousesInRow >= N)
                {
                    left = middle;
                    continue;
                }

                maxNumOfHousesInRow = W / houseLength;
                maxNumOfHousesInColumn = H / houseWidth;

                if (maxNumOfHousesInColumn * maxNumOfHousesInRow >= N)
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