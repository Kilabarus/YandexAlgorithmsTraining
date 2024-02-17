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

        static List<string> GetListOfStringArgs(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        static List<int> GetListOfInt32Args(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
        }

        static (int arg1, int arg2, int arg3, int arg4, int arg5, int arg6, int arg7, int arg8) GetTupleOfInt32Args(string input)
        {
            var args = GetListOfInt32Args(input);

            return args.Count switch
            {
                8 => (args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]),
                7 => (args[0], args[1], args[2], args[3], args[4], args[5], args[6], 0),
                6 => (args[0], args[1], args[2], args[3], args[4], args[5], 0, 0),
                5 => (args[0], args[1], args[2], args[3], args[4], 0, 0, 0),
                4 => (args[0], args[1], args[2], args[3], 0, 0, 0, 0),
                3 => (args[0], args[1], args[2], 0, 0, 0, 0, 0),
                2 => (args[0], args[1], 0, 0, 0, 0, 0, 0),
                _ => (args[0], 0, 0, 0, 0, 0, 0, 0),
            };
        }

        static StringBuilder AnswerBuilder = new();

        static string Solve(List<string> input)
        {
            (int taskEndCode, int interactorVerdict, int checkerVerdict)
                = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));

            return interactorVerdict switch
            {
                0 => taskEndCode != 0 ? "3" : $"{checkerVerdict}",
                1 => $"{checkerVerdict}",
                4 => taskEndCode != 0 ? "3" : $"4",
                6 => "0",
                7 => "1",
                _ => $"{interactorVerdict}"
            };
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}