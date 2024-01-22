using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_2
{
    internal class T1L2_B
    {
        private const string END_OF_INPUT = "-2000000000";

        static string[] GetInput()
        {
            string s = Console.ReadLine();
            List<string> input = new List<string>();

            while (s != END_OF_INPUT)
            {
                input.Add(s);
                s = Console.ReadLine();
            }

            return input.ToArray();
        }

        static string GetAnswer(int[] arr)
        {
            bool isConstant = true;
            bool isWeaklyAscending = true;
            bool isAscending = true;
            bool isWeaklyDescending = true;
            bool isDescending = true;

            for (int i = 1; i < arr.Length; i++)
            {
                if (isConstant && arr[i - 1] != arr[i])
                {
                    isConstant = false;
                }

                if (isWeaklyAscending && arr[i] < arr[i - 1])
                {
                    isWeaklyAscending = false;
                }

                if (isAscending && arr[i] <= arr[i - 1])
                {
                    isAscending = false;
                }

                if (isWeaklyDescending && arr[i] > arr[i - 1])
                {
                    isWeaklyDescending = false;
                }

                if (isDescending && arr[i] >= arr[i - 1])
                {
                    isDescending = false;
                }

                if (!isConstant && !isWeaklyAscending && !isWeaklyDescending)
                {
                    return "RANDOM";
                }
            }

            if (isConstant)
            {
                return "CONSTANT";
            }

            if (isWeaklyAscending)
            {
                if (isAscending)
                {
                    return "ASCENDING";
                }

                return "WEAKLY ASCENDING";
            }

            if (isWeaklyDescending)
            {
                if (isDescending)
                {
                    return "DESCENDING";
                }

                return "WEAKLY DESCENDING";
            }

            return "RANDOM";
        }

        static void Solution()
        {
            string[] inputStr = GetInput();

            int[] input = Array.ConvertAll(inputStr, int.Parse);

            Console.WriteLine(GetAnswer(input));
        }
    }
}
