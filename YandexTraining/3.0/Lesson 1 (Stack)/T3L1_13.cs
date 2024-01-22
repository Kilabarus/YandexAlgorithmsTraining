using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_2
{
    internal class T3L1_13
    {
        static string[] GetInput()
        {
            return Console.ReadLine().Split(" ");
        }

        static string GetAnswer(string[] input)
        {
            Stack<long> args = new();

            foreach (string s in input)
            {
                switch (s)
                {
                    case "+":
                        args.Push(args.Pop() + args.Pop());
                        break;
                    case "-":
                        args.Push(-args.Pop() + args.Pop());
                        break;
                    case "*":
                        args.Push(args.Pop() * args.Pop());
                        break;
                    default:
                        args.Push(long.Parse(s));
                        break;
                }
            }

            return args.Pop().ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            Console.WriteLine(GetAnswer(input));
        }
    }
}
