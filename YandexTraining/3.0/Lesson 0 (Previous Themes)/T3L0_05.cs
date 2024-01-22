using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_05
    {
        static string[] GetInput()
        {
            string[] input = new string[int.Parse(Console.ReadLine())];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadLine();
            }

            return input;
        }

        static string GetAnswer(int[] arr)
        {
            int left = 0, right = 0;
            int min;
            BigInteger result = 0;

            bool flag = false;

            while (true)
            {
                min = arr[left];

                while (right < arr.Length && arr[right] != 0)
                {
                    if (arr[right] < min)
                    {
                        min = arr[right];
                    }

                    ++right;
                }

                for (int i = left; i < right; i++)
                {
                    arr[i] -= min;
                }

                if (right - left > 1)
                {
                    flag = true;

                    result += min * ((BigInteger)(right - left - 1));
                }

                while (right < arr.Length && arr[right] == 0)
                {
                    ++right;
                }

                if (right == arr.Length)
                {
                    if (!flag)
                    {
                        return result.ToString();
                    }

                    flag = false;

                    left = 0;
                    right = 0;

                    continue;
                }

                left = right;
            }

            //return "0";
        }

        static void Soluitoon()
        {
            string[] input = GetInput();

            int[] numsOfsymbols = input.Select(x => int.Parse(x)).ToArray();

            Console.WriteLine(GetAnswer(numsOfsymbols));
        }
    }
}
