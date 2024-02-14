using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Reflection;


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

        static List<int> IsEnoughTime(List<(int T, int Z, int Y)> people, int M, int numOfMinutes)
        {
            int sum = 0;
            bool done = false;
            List<int> numOfBalloonsPerPerson = new();
            foreach (var (T, Z, Y) in people)
            {
                if (done)
                {
                    numOfBalloonsPerPerson.Add(0);
                    continue;
                }

                int numOfFullCycles = numOfMinutes / (T * Z + Y);                                
                int tForLastCycle = numOfMinutes - numOfFullCycles * (T * Z + Y);

                int numOfBalloonsOnLastCycle = tForLastCycle < T * Z
                    ? tForLastCycle / T
                    : Z;

                int numOfBalloons = numOfFullCycles * Z + numOfBalloonsOnLastCycle;

                if (sum + numOfBalloons <= M)
                {
                    numOfBalloonsPerPerson.Add(numOfBalloons);
                    sum += numOfBalloons;

                    if (sum == M)
                    {
                        done = true;
                    }

                    continue;
                }

                numOfBalloons -= sum + numOfBalloons - M;
                sum = M;
                numOfBalloonsPerPerson.Add(numOfBalloons);
                done = true;
            }

            return sum == M
                ? numOfBalloonsPerPerson
                : null;
        }

        static int BinSearch(List<(int T, int Z, int Y)> people, int M)
        {
            int left = 0;
            int right = 200 * M;

            while (left < right)
            {
                int middle = (left + right) / 2;

                var numOfBalloonsPerPerson = IsEnoughTime(people, M, middle);
                if (numOfBalloonsPerPerson != null)
                {
                    right = middle;
                    continue;
                }

                left = middle + 1;
            }

            return left;
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

            var MN = ConvertStringToListOfInt32(input[0]);
            (int M, int N) = (MN[0], MN[1]);

            List<(int T, int Z, int Y)> people = new();
            foreach (var personStr in input.Skip(1).Take(N))
            {
                var TZY = ConvertStringToListOfInt32(personStr);                
                people.Add((TZY[0], TZY[1], TZY[2]));
            }

            int neededTime = BinSearch(people, M);
            var numOfBalloonsPerPerson = IsEnoughTime(people, M, neededTime);

            output.AppendLine($"{neededTime}");
            numOfBalloonsPerPerson.ForEach(x => output.Append($"{x} "));

            return output.ToString();
        }

        static void Main(string[] args)
        {
            string output = Solve(ReadInput());

            WriteOutput(output);
            Console.WriteLine(output);
        }
    }
}