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

            if (File.Exists(INPUT_FILE))
            {
                return File.ReadAllLines(INPUT_FILE).ToList();
            }

            List<string> input = new();
            do
            {
                input.Add(Console.ReadLine());
            } while (input[^1] != "");

            return input;
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

            int[] wattsPrice = new int[1001];
            Array.Fill(wattsPrice, int.MaxValue);

            int numOfOffers = int.Parse(input[2]);
            foreach (var offer in input.Skip(3).Take(numOfOffers))
            {
                var wattPriceList = ConvertStringToListOfInt32(offer);
                wattsPrice[wattPriceList[0]] = wattsPrice[wattPriceList[0]] < wattPriceList[1]
                    ? wattsPrice[wattPriceList[0]]
                    : wattPriceList[1];
            }

            int minPrice = int.MaxValue;
            for (int i = 1000; i > 0; i--)
            {
                if (wattsPrice[i] < minPrice)
                {
                    minPrice = wattsPrice[i];
                }

                wattsPrice[i] = minPrice;
            }

            int sum = 0;
            foreach (var minWatts in ConvertStringToListOfInt32(input[1]))
            {
                sum += wattsPrice[minWatts];
            }

            return $"{sum}";
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}