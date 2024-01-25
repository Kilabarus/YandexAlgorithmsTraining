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

            Dictionary<string, Dictionary<string, BigInteger>> buyers = new();
            foreach (string str in input)
            {
                string[] buyerItemCount = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string buyer = buyerItemCount[0];
                string item = buyerItemCount[1];
                int count = int.Parse(buyerItemCount[2]);

                if (!buyers.ContainsKey(buyer))
                {
                    buyers.Add(buyer, new());
                }

                if (!buyers[buyer].ContainsKey(item))
                {
                    buyers[buyer].Add(item, count);
                    continue;
                }

                buyers[buyer][item] += count;
            }

            List<string> b = buyers.Keys.ToList();
            b.Sort();

            foreach (var buyer in b)
            {
                output.AppendLine($"{buyer}:");
                List<string> i = buyers[buyer].Keys.ToList();
                i.Sort();

                foreach (var item in i)
                {
                    output.AppendLine($"{item} {buyers[buyer][item]}");
                }
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