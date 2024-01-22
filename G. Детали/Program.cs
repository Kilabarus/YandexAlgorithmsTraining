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

            return Console.ReadLine();
        }

        static void Solve(string input)
        {
            string[] args = input.Split();

            int N = Convert.ToInt32(args[0]);
            int K = Convert.ToInt32(args[1]);
            int M = Convert.ToInt32(args[2]);

            int numOfDetails = 0;

            if (M > K)
            {
                Console.WriteLine("0");
                return;
            }

            while (N >= K)
            {
                numOfDetails += (N / K) * (K / M);
                N = N % K + (N / K) * (K % M);
            }

            Console.WriteLine(numOfDetails.ToString());
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}