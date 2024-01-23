using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://contest.yandex.ru/contest/27472/problems/C/

namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            List<string> input = new List<string>()
            {
                Console.ReadLine(),
                Console.ReadLine(),
                Console.ReadLine(),
            };

            return input;
        }

        static void Solve(List<string> input)
        {
            List<int> ints = input[1].Split().Select(x => Convert.ToInt32(x)).ToList();
            
            int target = Convert.ToInt32(input[2]);
            int closest = ints[0];

            for (int i = 1; i < ints.Count; i++)
            {
                if (Math.Abs(ints[i] - target) < Math.Abs(closest - target))
                {
                    closest = ints[i];
                }
            }

            Console.WriteLine(closest);
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}