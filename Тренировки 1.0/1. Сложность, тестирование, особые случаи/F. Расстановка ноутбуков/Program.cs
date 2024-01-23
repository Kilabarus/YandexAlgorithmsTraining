using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://contest.yandex.ru/contest/27393/problems/F/

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

            return Console.ReadLine();
        }

        static void Solve(string input)
        {
            string[] args = input.Split();

            int a1 = Convert.ToInt32(args[0]);
            int a2 = Convert.ToInt32(args[1]);
            int b1 = Convert.ToInt32(args[2]);
            int b2 = Convert.ToInt32(args[3]);

            int minArea = 2000 * 2000;            

            minArea = Math.Min(minArea,
                      Math.Min((a1 + b1) * Math.Max(a2, b2),
                      Math.Min((a1 + b2) * Math.Max(a2, b1),
                      Math.Min((a2 + b2) * Math.Max(a1, b1),
                               (a2 + b1) * Math.Max(a1, b2)))));

            if (minArea / (a1 + b1) == Math.Max(a2, b2))
            {
                Console.WriteLine($"{a1 + b1} {Math.Max(a2, b2)}");
            } 
            else if (minArea / (a1 + b2) == Math.Max(a2, b1))
            {
                Console.WriteLine($"{a1 + b2} {Math.Max(a2, b1)}");
            } 
            else if (minArea / (a2 + b2) == Math.Max(a1, b1))
            {
                Console.WriteLine($"{a2 + b2} {Math.Max(a1, b1)}");
            } 
            else 
            {
                Console.WriteLine($"{a2 + b1} {Math.Max(a1, b2)}");
            }
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}