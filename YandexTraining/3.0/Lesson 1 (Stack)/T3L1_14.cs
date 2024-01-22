using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_2
{
    internal class T3L1_14
    {
        static string[] GetInput()
        {
            Console.ReadLine();
            return Console.ReadLine().Split(" ");
        }

        static string GetAnswer(int[] cars)
        {
            Stack<long> parkedCars = new();
            int neededNumber = 1;

            foreach (int carNumber in cars)
            {
                if (carNumber == neededNumber)
                {
                    ++neededNumber;

                    while (parkedCars.Count > 0 && neededNumber == parkedCars.Peek())
                    {
                        parkedCars.Pop();
                        ++neededNumber;
                    }

                    continue;
                }

                if (parkedCars.Count > 0 && parkedCars.Peek() < carNumber)
                {
                    return "NO";
                }

                parkedCars.Push(carNumber);
            }

            if (parkedCars.Count > 0)
            {
                return "NO";
            }

            return "YES";
        }

        static void Solution()
        {
            string[] input = GetInput();

            Console.WriteLine(GetAnswer(Array.ConvertAll(input, int.Parse)));
        }
    }
}
