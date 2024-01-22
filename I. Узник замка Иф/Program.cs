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
                ReadInt32(),
                ReadInt32(),
            };

            return input;
        }

        static void Solve(List<int> input)
        {
            bool IsFit(int l1, int w1, int l2, int w2)
            {
                return (l1 <= l2 && w1 <= w2) || (l1 <= w2 && w1 <= l2);
            }

            int cubeA = input[0];
            int cubeB = input[1];
            int cubeC = input[2];

            int rectD = input[3];
            int rectE = input[4];

            if (cubeA <= 0 || cubeB <= 0 || cubeC <= 0 || rectD <= 0 || rectE <= 0)
            {
                Console.WriteLine("NO");
                return;
            }

            if (IsFit(cubeA, cubeB, rectD, rectE) ||
                IsFit(cubeB, cubeC, rectD, rectE) ||
                IsFit(cubeA, cubeC, rectD, rectE))
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