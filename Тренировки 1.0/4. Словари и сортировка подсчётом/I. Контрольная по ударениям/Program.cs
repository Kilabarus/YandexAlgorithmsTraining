using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;


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
            Dictionary<string, BitArray> stresses = new();

            int numberOfWordsInDictionary = int.Parse(input[0]);

            foreach (string word in input.Skip(1).Take(numberOfWordsInDictionary))
            {
                string wordLower = word.ToLower();

                if (!stresses.ContainsKey(wordLower))
                {
                    stresses.Add(wordLower, new BitArray(word.Length));
                }

                for (int i = 0; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        stresses[wordLower][i] = true;
                        break;
                    }
                }
            }

            int numberOfMistakes = 0;

            foreach (string word in input[1 + numberOfWordsInDictionary].Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (word.Count(char.IsUpper) != 1)
                {
                    ++numberOfMistakes;
                    continue;
                }

                string wordLower = word.ToLower();

                if (stresses.ContainsKey(wordLower))
                {
                    int stressIndex = word.ToList().FindIndex(char.IsUpper);

                    if (!stresses[wordLower][stressIndex]) 
                    {
                        ++numberOfMistakes;
                    }                    
                }
            }            

            return numberOfMistakes.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}