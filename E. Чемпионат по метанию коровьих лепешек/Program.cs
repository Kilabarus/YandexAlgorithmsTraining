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

            Console.ReadLine();
            string input = Console.ReadLine();

            return input;
        }

        static void Solve(string input)
        {
            List<int> distances = input.Split().Select(x =>  Convert.ToInt32(x)).ToList();

            int maxDistance = distances.Max();
            int maxDistanceFirstIndex = distances.IndexOf(maxDistance);

            int maxVasiliyDistance = -1;

            for (int i = 1; i < distances.Count - 1; i++)
            {
                if (distances[i] % 10 == 5 
                    && i > maxDistanceFirstIndex 
                    && distances[i + 1] < distances[i] 
                    && distances[i] > maxVasiliyDistance)
                {
                    maxVasiliyDistance = distances[i];
                }
            }

            if (maxVasiliyDistance == -1)
            {
                Console.WriteLine(0);
                return;
            }

            int vasiliyPlace = 1;

            foreach (var distance in distances.OrderByDescending(x => x))
            {
                if (distance == maxVasiliyDistance)
                {
                    Console.WriteLine(vasiliyPlace);
                    return;
                }

                ++vasiliyPlace;
            }            
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}