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

            StringBuilder output = new StringBuilder();

            List<int> keys = new List<int>();
            keys.Add(0);
            keys.InsertRange(1, ConvertStringToListOfInt32(input[1]));

            ConvertStringToListOfInt32(input[3]).ForEach(key => --keys[key]);

            foreach (var key in keys.Skip(1).Take(int.Parse(input[0])))
            {
                if (key < 0)
                {
                    output.AppendLine("YES");
                    continue;
                }

                output.AppendLine("NO");
            }

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}