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

            SortedDictionary<string, int> words = new();            

            input.ForEach(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(word =>
            {
                if (!words.ContainsKey(word))
                {
                    words.Add(word, 1);
                    return;
                }

                ++words[word];
            }));

            int maxFrequency = words.Values.Max();
            string mostFrequentWord = words.First(word => words[word.Key] == maxFrequency).Key;

            return mostFrequentWord;
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}