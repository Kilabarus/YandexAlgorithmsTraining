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
            int AB = input[0];
            int BC = input[1];
            int CA = input[2];

            if (AB == 0 || BC == 0 || CA == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            if (AB + BC > CA && BC + CA > AB && CA + AB > BC)
            {
                Console.WriteLine("YES");
                return;
            }

            Console.WriteLine("NO");
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}