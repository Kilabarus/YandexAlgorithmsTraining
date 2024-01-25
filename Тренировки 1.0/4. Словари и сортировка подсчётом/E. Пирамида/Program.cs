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

            var highestBlocks = new Dictionary<int, int>();
            
            int numberOfBlocks = int.Parse(input[0]);
            foreach (var block in input.Skip(1).Take(numberOfBlocks))
            {
                var widthHeight = ConvertStringToListOfInt32(block);

                int width = widthHeight[0];
                int height = widthHeight[1];

                if (highestBlocks.ContainsKey(width))
                {
                    if (highestBlocks[width] < height)
                    {
                        highestBlocks[width] = height;
                    }

                    continue;
                }

                highestBlocks.Add(width, height);
            };

            BigInteger sumHeight = 0;
            foreach (var width in highestBlocks.Keys)
            {
                sumHeight += highestBlocks[width];
            }

            return sumHeight.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}