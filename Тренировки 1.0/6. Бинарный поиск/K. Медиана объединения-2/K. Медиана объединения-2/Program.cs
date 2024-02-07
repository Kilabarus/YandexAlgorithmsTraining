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

            StringBuilder output = new StringBuilder();

            int BinCountOfSmallerElements(List<int> l, int elem)
            {
                if (l[0] >= elem)
                {
                    return 0;
                }

                if (l[^1] < elem)
                {
                    return l.Count;
                }

                int left = 0;
                int right = l.Count - 1;

                while (left < right)
                {
                    int middle = (left + right + 1) / 2;

                    if (l[middle] < elem)
                    {
                        left = middle;
                        continue;
                    }

                    right = middle - 1;
                }

                return left + 1;
            }

            int BinCountOfBiggerElements(List<int> l, int elem)
            {
                if (l[^1] <= elem)
                {
                    return 0;
                }

                if (l[0] > elem)
                {
                    return l.Count;
                }

                int left = 0;
                int right = l.Count - 1;

                while (left < right)
                {
                    int middle = (left + right) / 2;

                    if (l[middle] > elem)
                    {
                        right = middle;
                        continue;
                    }

                    left = middle + 1;
                }

                return l.Count - left;
            }

            List<int> GenerateSequence(int x, int d, int a, int c, int m, int L)
            {
                List<int> result = new()
                {
                    x
                };

                List<int> dList = new()
                {
                    d
                };

                for (int i = 1; i < L; i++)
                {
                    result.Add(result[i - 1] + dList[i - 1]);
                    dList.Add((a * dList[i - 1] + c) % m);
                }

                return result;
            }

            var NL = ConvertStringToListOfInt32(input[0]);
            (int N, int L) = (NL[0], NL[1]);

            List<List<int>> lists = new();
            for (int i = 0; i < N; i++)
            {
                var XDACM = ConvertStringToListOfInt32(input[i + 1]);
                lists.Add(GenerateSequence(XDACM[0], XDACM[1], XDACM[2], XDACM[3], XDACM[4], L));
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    int left = 0;
                    int right = L - 1;
                    int middle = 0;
                    bool found = false;

                    int smallerElems;
                    int biggerElems;

                    while (left < right)
                    {
                        middle = (left + right) / 2;

                        smallerElems = BinCountOfSmallerElements(lists[i], lists[i][middle])
                            + BinCountOfSmallerElements(lists[j], lists[i][middle]);
                        biggerElems = BinCountOfBiggerElements(lists[i], lists[i][middle])
                            + BinCountOfBiggerElements(lists[j], lists[i][middle]);

                        if (smallerElems < L && biggerElems <= L)
                        {
                            found = true;
                            break;
                        }

                        if (smallerElems >= L)
                        {
                            right = middle - 1;
                            continue;
                        }

                        left = middle + 1;
                    }

                    if (found)
                    {
                        output.AppendLine($"{lists[i][middle]}");
                        continue;
                    }
                    else
                    {
                        smallerElems = BinCountOfSmallerElements(lists[i], lists[i][left])
                            + BinCountOfSmallerElements(lists[j], lists[i][left]);
                        biggerElems = BinCountOfBiggerElements(lists[i], lists[i][left])
                            + BinCountOfBiggerElements(lists[j], lists[i][left]);

                        if (smallerElems < L && biggerElems <= L)
                        {
                            output.AppendLine($"{lists[i][left]}");
                            continue;
                        }
                    }

                    left = 0;
                    right = L - 1;
                    found = false;

                    while (left < right)
                    {
                        middle = (left + right) / 2;

                        smallerElems = BinCountOfSmallerElements(lists[j], lists[j][middle])
                            + BinCountOfSmallerElements(lists[i], lists[j][middle]);
                        biggerElems = BinCountOfBiggerElements(lists[j], lists[j][middle])
                            + BinCountOfBiggerElements(lists[i], lists[j][middle]);

                        if (smallerElems < L && biggerElems <= L)
                        {
                            found = true;
                            break;
                        }

                        if (smallerElems >= L)
                        {
                            right = middle - 1;
                            continue;
                        }

                        left = middle + 1;
                    }

                    if (found)
                    {
                        output.AppendLine($"{lists[j][middle]}");
                        continue;
                    }
                    else
                    {
                        smallerElems = BinCountOfSmallerElements(lists[j], lists[j][left])
                            + BinCountOfSmallerElements(lists[i], lists[j][left]);
                        biggerElems = BinCountOfBiggerElements(lists[j], lists[j][left])
                            + BinCountOfBiggerElements(lists[i], lists[j][left]);

                        if (smallerElems < L && biggerElems <= L)
                        {
                            output.AppendLine($"{lists[j][left]}");
                            continue;
                        }
                    }
                }
            }

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