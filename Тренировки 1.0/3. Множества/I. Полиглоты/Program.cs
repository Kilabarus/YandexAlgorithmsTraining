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
            StringBuilder output = new StringBuilder();

            HashSet<string> languagesEveryoneKnows = new();
            HashSet<string> languagesAtLeastSomeoneKnows = new();

            int numberOfStudent = int.Parse(input[0]);
            int currentStudent = 1;
            int currentString = 1; 
            
            while (currentStudent <= numberOfStudent)
            {
                int numberOfLanguages = int.Parse(input[currentString++]);

                HashSet<string> currentLanguages = new HashSet<string>(input.Skip(currentString).Take(numberOfLanguages));
                currentString += numberOfLanguages;

                if (currentStudent == 1)
                {
                    languagesEveryoneKnows = currentLanguages;
                    languagesAtLeastSomeoneKnows = new HashSet<string>(currentLanguages);
                    currentStudent++;

                    continue;
                }

                languagesEveryoneKnows = new(languagesEveryoneKnows.Intersect(currentLanguages));
                languagesAtLeastSomeoneKnows = new(languagesAtLeastSomeoneKnows.Union(currentLanguages));
                currentStudent++;
            }

            output.AppendLine(languagesEveryoneKnows.Count().ToString());

            foreach (var language in languagesEveryoneKnows)
            {
                output.AppendLine(language);
            }

            output.AppendLine(languagesAtLeastSomeoneKnows.Count().ToString());

            foreach (var language in languagesAtLeastSomeoneKnows)
            {
                output.AppendLine(language);
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