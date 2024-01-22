using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_2
{
    internal class T3L1_15
    {
        static string[] GetInput()
        {
            Console.ReadLine();
            return Console.ReadLine().Split(" ");
        }

        static string GetAnswer(int[] prices)
        {
            int[] newCities = new int[prices.Length];

            Stack<(int City, int Price)> searchingCities = new();

            for (int i = 0; i < prices.Length; i++)
            {
                while (searchingCities.Count > 0 && searchingCities.Peek().Price > prices[i])
                {
                    newCities[searchingCities.Pop().City] = i;
                }

                searchingCities.Push((i, prices[i]));
            }

            while (searchingCities.Count > 0)
            {
                newCities[searchingCities.Pop().City] = -1;
            }

            StringBuilder sB = new();

            foreach (var city in newCities)
            {
                sB.Append($"{city} ");
            }

            return sB.ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            Console.WriteLine(GetAnswer(Array.ConvertAll(input, int.Parse)));
        }
    }
}
