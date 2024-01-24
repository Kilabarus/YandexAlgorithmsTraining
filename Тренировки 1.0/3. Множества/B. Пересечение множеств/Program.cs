using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            const string INPUT_FILE = @"input.txt";

            return File.ReadAllLines(INPUT_FILE).ToList();
        }

        static void WriteOutput(string output)
        {
            const string OUTPUT_FILE = @"output.txt";

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

            HashSet<int> s1 = new HashSet<int>(ConvertStringToListOfInt32(input[0]));
            HashSet<int> s2 = new HashSet<int>(ConvertStringToListOfInt32(input[1]));

            foreach (int i in s1.Intersect(s2).OrderBy(x => x))
            {
                output.Append($"{i} ");                
            }

            return output.ToString().Trim();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}