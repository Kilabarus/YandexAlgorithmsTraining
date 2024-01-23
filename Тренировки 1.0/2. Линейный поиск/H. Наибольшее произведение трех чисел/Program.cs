using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

// https://contest.yandex.ru/contest/27472/problems/H/

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

            // -min1 +min1 +min2 - возможно только в наборе из 3 чисел
            if (l.Count == 3)
            {
                Console.WriteLine($"{l[0]} {l[1]} {l[2]}");
                return;
            }

            BigInteger positiveMax1 = 0, positiveMax2 = 0, positiveMax3 = 0;
            BigInteger negativeMax1 = 0, negativeMax2 = 0;

            // -max1 -max2 +max1 - возможно если в наборе 1 или 2 положительных числа
            int numberOfPositiveNumbers = l.Count(x => x > 0);
            if (numberOfPositiveNumbers > 0 && numberOfPositiveNumbers <= 2) 
            {                
                positiveMax1 = l.Max();

                foreach (var number in l)
                {
                    if (number < negativeMax2)
                    {
                        if (number < negativeMax1)
                        {
                            (negativeMax1, negativeMax2) = (number, negativeMax1);                            
                            continue;
                        }

                        negativeMax2 = number;                        
                    }
                }

                Console.WriteLine($"{negativeMax2} {negativeMax1} {positiveMax1}");
                return;
            }

            // -min1 -min2 -min3 - возможно если в наборе только отрицательные элементы
            if (numberOfPositiveNumbers == 0)
            {
                BigInteger negativeMin1 = int.MinValue;
                BigInteger negativeMin2 = int.MinValue;
                BigInteger negativeMin3 = int.MinValue;

                foreach (var number in l)
                {
                    if (number > negativeMin3)
                    {
                        if (number > negativeMin2)
                        {
                            if (number > negativeMin1)
                            {
                                (negativeMin1, negativeMin2, negativeMin3) = (number, negativeMin1, negativeMin2);                                
                                continue;
                            }

                            (negativeMin2, negativeMin3) = (number, negativeMin2);                            
                            continue;
                        }

                        negativeMin3 = number;
                    }
                }

                Console.WriteLine($"{negativeMin3} {negativeMin2} {negativeMin1}");
                return;
            }

            // +max1 +max2 +max3 - во всех других случаях
            // -max1 -max2 +max1 - во всех других случаях            
            foreach (var number in l)
            {
                if (number > 0)
                {
                    if (number > positiveMax3)
                    {
                        if (number > positiveMax2)
                        {
                            if (number > positiveMax1)
                            {
                                (positiveMax1, positiveMax2, positiveMax3) = (number, positiveMax1, positiveMax2);
                                continue;
                            }

                            (positiveMax2, positiveMax3) = (number, positiveMax2);
                            continue;
                        }

                        positiveMax3 = number;
                    }

                    continue;
                }

                if (number < negativeMax2)
                {
                    if (number < negativeMax1)
                    {
                        (negativeMax1, negativeMax2) = (number, negativeMax1);
                        continue;
                    }

                    negativeMax2 = number;
                }
            }

            if (positiveMax1 * positiveMax2 * positiveMax3 > positiveMax1 * negativeMax1 * negativeMax2)
            {
                Console.WriteLine($"{positiveMax1} {positiveMax2} {positiveMax3}");
                return;
            }

            Console.WriteLine($"{positiveMax1} {negativeMax2} {negativeMax1}");
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}
