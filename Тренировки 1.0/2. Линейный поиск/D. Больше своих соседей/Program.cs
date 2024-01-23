using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://contest.yandex.ru/contest/27472/problems/D/

namespace YandexTraining
{
    internal class Program
    {
        static string GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            string input = Console.ReadLine();

            return input;
        }

        static void Solve(string input)
        {
            List<int> ints = input.Split().Select(x => Convert.ToInt32(x)).ToList();

            int count = 0;

            for (int i = 1; i < ints.Count - 1; i++)
            {
                if (ints[i] > ints[i - 1] && ints[i] > ints[i + 1])
                {
                    ++count;
                }
            }

            Console.WriteLine(count);
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}