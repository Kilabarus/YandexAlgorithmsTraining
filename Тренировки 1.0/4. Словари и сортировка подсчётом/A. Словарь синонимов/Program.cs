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
            int numberOfWords = int.Parse(input[0]);
            Dictionary<string, string> synonyms = new();

            foreach (var pairOfWords in input.Skip(1).Take(numberOfWords))
            {
                string[] words = pairOfWords.Split();

                if (!synonyms.ContainsKey(words[0]) )
                {
                    synonyms.Add(words[0], words[1]);
                }

                if (!synonyms.ContainsKey(words[1]))
                {
                    synonyms.Add(words[1], words[0]);
                }                    
            }

            return synonyms[input[1 + numberOfWords]];
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}