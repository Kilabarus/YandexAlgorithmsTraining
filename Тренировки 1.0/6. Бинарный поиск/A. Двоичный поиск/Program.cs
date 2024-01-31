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

        static int BinarySearch(List<int> l, int x)
        {
            int left = 0;
            int right = l.Count - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                
                if (l[middle] == x)
                {
                    return middle;
                }

                if (l[middle] > x)
                {
                    right = middle - 1;
                    continue;
                }

                left = middle + 1;
            }

            return -1;
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
            int N = NK[0];
            int K = NK[1];

            var Ns = ConvertStringToListOfInt32(input[1]);
            var Ks = ConvertStringToListOfInt32(input[2]);

            if (N * Math.Log2(N) + Math.Log2(N) * K < N * K)
            {
                Ns.Sort();
                
                foreach (int i in Ks)
                {
                    if (BinarySearch(Ns, i) != -1)
                    {
                        output.AppendLine("YES");
                        continue;
                    }

                    output.AppendLine("NO");
                }

                return output.ToString();
            }

            foreach (int i in Ks)
            {
                foreach (int n in Ns)
                {
                    if (i == n)
                    {
                        output.AppendLine("YES");
                        break;
                    }
                }

                output.AppendLine("NO");
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