using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexTraining
{
    internal class Program
    {
        static List<int> GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            List<int> input = new List<int>()
            {
                ReadInt32(),
                ReadInt32(),
                ReadInt32(),
            };

            return input;
        }

        static void Solve(List<int> input)
        {
            int a = input[0];
            int b = input[1];
            int c = input[2];

            if (c < 0)
            {
                Console.WriteLine("NO SOLUTION");
                return;
            }

            if (a == 0)
            {
                if (b == c * c)
                {
                    Console.WriteLine("MANY SOLUTIONS");
                    return;
                }

                Console.WriteLine("NO SOLUTION");
                return;
            }

            if ((c * c - b) % a > 0)
            {
                Console.WriteLine("NO SOLUTION");
                return;
            }

            int x = (c * c - b) / a;

            if (a * x + b >= 0)
            {
                Console.WriteLine(x);
                return;
            }

            Console.WriteLine("NO SOLUTION");
            return;
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}