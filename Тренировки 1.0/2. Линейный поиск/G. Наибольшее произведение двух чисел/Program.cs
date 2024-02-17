using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            List<int> l = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            if (l.Count == 2)
            {
                if (l[0] > l[1])
                {
                    Console.WriteLine($"{l[1]} {l[0]}");
                    return;
                }

                Console.WriteLine($"{l[0]} {l[1]}");
                return;
            }

            BigInteger maxPositive = 0;
            BigInteger nextToMaxPositive = 0;
            BigInteger maxNegative = 0;
            BigInteger nextToMaxNegative = 0;

            foreach (var number in l)
            {
                if (number > 0)
                {
                    if (number > nextToMaxPositive)
                    {
                        if (number > maxPositive)
                        {
                            nextToMaxPositive = maxPositive;
                            maxPositive = number;

                            continue;
                        }

                        nextToMaxPositive = number;                        
                    }

                    continue;
                }

                if (number < nextToMaxNegative)
                {
                    if (number < maxNegative)
                    {
                        nextToMaxNegative = maxNegative;
                        maxNegative = number;

                        continue;
                    }

                    nextToMaxNegative = number;
                }
            }

            if (nextToMaxPositive * maxPositive > nextToMaxNegative * maxNegative)
            {
                Console.WriteLine($"{nextToMaxPositive} {maxPositive}");
                return;
            }

            Console.WriteLine($"{maxNegative} {nextToMaxNegative}");
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}