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
            int K = int.Parse(input[0]);
            string operations = input[1];
            
            BigInteger count = 0;
            int numOfPrevOperations = 0;
            for (int i = K; i < operations.Length; i++)
            {
                if (operations[i] != operations[i - K])
                {
                    numOfPrevOperations = 0;
                    continue;                    
                }

                ++numOfPrevOperations;
                count += numOfPrevOperations;
            }

            return $"{count}";
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}