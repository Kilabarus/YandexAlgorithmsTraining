using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://contest.yandex.ru/contest/27472/problems/B/

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

            List<int> input = new();
            
            while (true)
            {
                int number = ReadInt32();
                
                if (number == -2e9)
                {
                    break;                                        
                }

                input.Add(number);
            }

            return input;
        }

        static void Solve(List<int> input)
        {
            bool hasSameValues = false;
            bool hasAscendingValues = false;
            bool hasDescendingValues = false;

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == input[i - 1])
                {
                    hasSameValues = true;
                    continue;
                }

                if (input[i] > input[i - 1])
                {
                    hasAscendingValues = true;
                    continue;
                }

                hasDescendingValues = true;
            }

            if (hasSameValues && !hasAscendingValues && !hasDescendingValues)
            {
                Console.WriteLine("CONSTANT");
                return;
            }

            if (!hasSameValues && hasAscendingValues && !hasDescendingValues)
            {
                Console.WriteLine("ASCENDING");
                return;
            }

            if (hasSameValues && hasAscendingValues && !hasDescendingValues)
            {
                Console.WriteLine("WEAKLY ASCENDING");
                return;
            }

            if (!hasSameValues && !hasAscendingValues && hasDescendingValues)
            {
                Console.WriteLine("DESCENDING");
                return;
            }

            if (hasSameValues && !hasAscendingValues && hasDescendingValues)
            {
                Console.WriteLine("WEAKLY DESCENDING");
                return;
            }

            Console.WriteLine("RANDOM");
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}