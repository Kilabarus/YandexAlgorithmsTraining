using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L3_25
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static string GetAnswer(int[] arr)
        {
            Array.Sort(arr);

            int[] dp = new int[arr.Length];

            dp[1] = arr[1] - arr[0];

            if (arr.Length > 2)
            {
                dp[2] = arr[2] - arr[0];
            }

            for (int i = 3; i < arr.Length; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + arr[i] - arr[i - 1], dp[i - 2] + arr[i] - arr[i - 1]);
            }

            return dp[dp.Length - 1].ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            Console.WriteLine(GetAnswer(Array.ConvertAll(input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse)));
        }
    }
}
