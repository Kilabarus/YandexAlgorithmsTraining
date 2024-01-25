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
            string[] NCD = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int N = int.Parse(NCD[0]);
            bool C = NCD[1] == "yes" ? true : false;
            bool D = NCD[2] == "yes" ? true : false;

            HashSet<string> keywords = new();
            foreach (string keyword in input.Skip(1).Take(N))
            {
                if (C)
                {
                    keywords.Add(keyword);
                    continue;
                }

                keywords.Add(keyword.ToLower());
            }

            bool IsAsciiLetter(char c)
            {
                return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
            }

            bool IsAsciiDigit(char c)
            {
                return c >= '0' && c <= '9';
            }

            Dictionary<string, (int numberOfOccurences, int placeInProgramm)> identificators = new();
            StringBuilder currentWord = new(50);
            int identificatorsFound = 0;
            string code = string.Join(' ', input.Skip(1 + N).Take(input.Count - (1 + N)).ToArray());

            foreach (char c in code)
            {
                if (IsAsciiLetter(c) || IsAsciiDigit(c) || c == '_')
                {
                    currentWord.Append(c);
                    continue;
                }

                string word = currentWord.ToString();
                currentWord.Clear();

                if (word == "")
                {
                    continue;
                }

                bool hasNonDigit = word.ToList().FindIndex(c => IsAsciiLetter(c) || c == '_') != -1;
                bool isKeyword = (C && keywords.Contains(word)) || (!C && keywords.Contains(word.ToLower()));
                bool isIdentificator = hasNonDigit && !isKeyword && (D || (!D && !IsAsciiDigit(word[0])));

                if (isIdentificator)
                {
                    if (!C)
                    {
                        word = word.ToLower();
                    }

                    if (!identificators.ContainsKey(word))
                    {
                        identificators.Add(word, (0, ++identificatorsFound));
                    }

                    identificators[word]
                        = (identificators[word].numberOfOccurences + 1, identificators[word].placeInProgramm);
                }
            }

            string mostFrequentIdentificator = null;
            foreach (var key in identificators.Keys)
            {
                if (mostFrequentIdentificator == null)
                {
                    mostFrequentIdentificator = key;
                    continue;
                }

                if (identificators[mostFrequentIdentificator].numberOfOccurences < identificators[key].numberOfOccurences)
                {
                    mostFrequentIdentificator = key;
                }

                if (identificators[mostFrequentIdentificator].numberOfOccurences == identificators[key].numberOfOccurences)
                {
                    if (identificators[mostFrequentIdentificator].placeInProgramm > identificators[key].placeInProgramm)
                    {
                        mostFrequentIdentificator = key;
                        continue;
                    }
                }
            }

            return mostFrequentIdentificator;
        }

        static void Main(string[] args)
        {
            string output = Solve(GetInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}