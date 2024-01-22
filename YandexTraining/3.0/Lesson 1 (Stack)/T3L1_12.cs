using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_2
{
    internal class T3L1_12
    {
        static string GetInput()
        {
            return Console.ReadLine();
        }

        static string GetAnswer(string input)
        {
            Stack<char> openedPs = new();
            Dictionary<char, char> pairs = new() { { ')', '(' }, { ']', '[' }, { '}', '{' } };

            foreach (char p in input)
            {
                if (pairs.ContainsKey(p))
                {
                    if (openedPs.Count == 0 || pairs[p] != openedPs.Pop())
                    {
                        return "no";
                    }

                    continue;
                }

                openedPs.Push(p);
            }

            if (openedPs.Count > 0)
            {
                return "no";
            }

            return "yes";
        }

        static void Solution()
        {
            string input = GetInput();

            Console.WriteLine(GetAnswer(input));
        }
    }
}
