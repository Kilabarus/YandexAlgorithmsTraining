using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


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

        static int BinaryClosestSearch(List<long> l, long x)
        {
            int left = 0;
            int right = l.Count - 1;
            
            while (left < right - 1)
            {
                int middle = left + (right - left) / 2;

                if (l[middle] == x)
                {
                    return middle;
                }

                if (l[middle] > x)
                {
                    right = middle;
                    continue;
                }

                left = middle;
            }

            return Math.Abs(x - l[left]) <= Math.Abs(x - l[right]) 
                ? left 
                : right;
        }

        static string Solve(List<string> input)
        {
            List<long> ConvertStringToListOfInt32(string longs)
            {
                return longs.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(long.Parse)
                           .ToList();
            }

            StringBuilder output = new StringBuilder();

            var Ns = ConvertStringToListOfInt32(input[1]);
            var Ks = ConvertStringToListOfInt32(input[2]);

            foreach (var k in Ks)
            {
                output.AppendLine($"{Ns[BinaryClosestSearch(Ns, k)]}");
            }

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}