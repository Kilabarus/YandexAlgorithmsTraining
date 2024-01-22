using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Sprint
{
    internal class A
    {
        static List<(int op, object arg1, string arg2)> GetInput()
        {
            int N = int.Parse(Console.ReadLine());

            List<(int op, object arg1, string arg2)> ops = new();

            string[] t;

            for (int i = 0; i < N; i++)
            {
                t = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (t[0] == "add")
                {
                    ops.Add((1, int.Parse(t[1]), t[2]));
                    continue;
                }

                if (t[0] == "delete")
                {
                    ops.Add((2, int.Parse(t[1]), ""));
                    continue;
                }

                ops.Add((3, t[1], ""));
            }

            return ops;
        }

        static string GetAnswer(List<(int op, object arg1, string arg2)> ops)
        {
            List<(BigInteger num, int product)> train = new();

            Dictionary<string, int> replacement = new();

            int lastRepl = 0;

            StringBuilder sB = new();

            foreach (var op in ops)
            {
                if (op.op == 1)
                {
                    int repl;

                    if (!replacement.ContainsKey(op.arg2))
                    {
                        replacement.Add(op.arg2, lastRepl);
                        repl = lastRepl;
                        lastRepl++;
                    }
                    else
                    {
                        repl = replacement[op.arg2];
                    }

                    if (train.Count > 0 && train.Last().product == repl)
                    {
                        (BigInteger, int) lastCabin = train.Last();
                        lastCabin.Item1 += (int)op.arg1;

                        train.RemoveAt(train.Count - 1);
                        train.Add(lastCabin);
                    }
                    else
                    {
                        train.Add(((int)op.arg1, repl));
                    }

                    continue;
                }
                if (op.op == 2)
                {
                    BigInteger needToDelete = (int)op.arg1;
                    BigInteger lastNum;

                    while (needToDelete > 0)
                    {
                        lastNum = train.Last().num;

                        if (needToDelete >= lastNum)
                        {
                            train.RemoveAt(train.Count - 1);
                            needToDelete -= lastNum;
                            continue;
                        }

                        lastNum -= needToDelete;
                        (BigInteger, int) lastCabin = train.Last();
                        lastCabin.Item1 = lastNum;
                        train.RemoveAt(train.Count - 1);
                        train.Add(lastCabin);
                        break;
                    }

                    continue;
                }

                BigInteger sum = 0;

                foreach (var item in train)
                {
                    if (!replacement.ContainsKey((string)op.arg1))
                    {
                        break;
                    }

                    int repl = replacement[(string)op.arg1];

                    if (item.product == repl)
                    {
                        sum += item.num;
                    }
                }

                sB.AppendLine(sum.ToString());
            }

            return sB.ToString();
        }

        static void S()
        {
            List<(int op, object arg1, string arg2)> input = GetInput();

            Console.WriteLine(GetAnswer(input));
        }
    }
}
