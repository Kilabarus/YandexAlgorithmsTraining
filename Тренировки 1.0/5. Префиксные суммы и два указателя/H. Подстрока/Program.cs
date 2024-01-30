using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace YandexTraining
{
    internal class Program
    {
        const string LOCAL_INPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\input.txt";
        const string SERVER_INPUT_FILE = "input.txt";

        const string LOCAL_OUTPUT_FILE = @"C:\Users\Admin\Desktop\Programming\.NET\Programs\YandexTraining\output.txt";
        const string SERVER_OUTPUT_FILE = "output.txt";

        static List<string> ReadInput() => File.Exists(LOCAL_INPUT_FILE) 
            ? File.ReadAllLines(LOCAL_INPUT_FILE).ToList() 
            : File.ReadAllLines(SERVER_INPUT_FILE).ToList();

        static void WriteOutput(string output)        
        {
            string outputFile = File.Exists(LOCAL_OUTPUT_FILE)
                ? LOCAL_OUTPUT_FILE
                : SERVER_OUTPUT_FILE;

            File.WriteAllText(outputFile, output);            
        }

        static string Solve(List<string> input)
        {
            List<int> ConvertStringToListOfInt32(string ints)
            {
                return ints.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            int K = ConvertStringToListOfInt32(input[0])[1];
            string s = input[1];

            int left = 0;
            int right = 0;
            var metChars = new Dictionary<char, int>();

            int maxSubstrStart = 0;
            int maxSubstrLen = 0;
            while (right < s.Length)
            {
                if (!metChars.ContainsKey(s[right]))
                {
                    metChars.Add(s[right], 1);
                    ++right;
                    continue;
                }
                
                if (metChars[s[right]] == K)
                {
                    if (right - left > maxSubstrLen)
                    {
                        maxSubstrLen = right - left;
                        maxSubstrStart = left;
                    }

                    while (metChars[s[right]] == K)
                    {
                        --metChars[s[left]];
                        ++left;
                    }

                    ++metChars[s[right]];
                    ++right;
                    continue;
                }

                ++metChars[s[right]];
                ++right;
            }

            if (right - left > maxSubstrLen)
            {
                maxSubstrLen = right - left;
                maxSubstrStart = left;
            }

            int newLeft = left - 1;
            while (newLeft >= 0)
            {
                if (metChars[s[newLeft]] == K)
                {
                    break;
                }

                ++metChars[s[newLeft]];
                --newLeft;
            }

            if (right - (newLeft + 1) > maxSubstrLen)
            {
                maxSubstrLen = right - (newLeft + 1);
                maxSubstrStart = newLeft + 1;
            }

            return $"{maxSubstrLen} {maxSubstrStart + 1}";
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}