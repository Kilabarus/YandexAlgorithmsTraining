using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            List<int> list = input.Split().Select(x => Convert.ToInt32(x)).ToList();

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] <= list[i - 1])
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}