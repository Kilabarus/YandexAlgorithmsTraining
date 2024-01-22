using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L3_24
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static string GetAnswer(int N, int[] A, int[] B, int[] C)
        {
            int[] dp = new int[N];

            dp[0] = A[0];

            if (N > 1)
            {
                dp[1] = Math.Min(dp[0] + A[1], B[0]);
            }

            if (N > 2)
            {
                dp[2] = Math.Min(Math.Min(dp[1] + A[2], dp[0] + B[1]), C[0]);
            }

            for (int i = 3; i < N; i++)
            {
                dp[i] = Math.Min(Math.Min(dp[i - 1] + A[i], dp[i - 2] + B[i - 1]), dp[i - 3] + C[i - 2]);
            }

            return dp[N - 1].ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            int[] A = new int[input.Length - 1];
            int[] B = new int[input.Length - 1];
            int[] C = new int[input.Length - 1];

            for (int i = 1; i < input.Length; i++)
            {
                string[] ABC = input[i].Split(" ");

                A[i - 1] = int.Parse(ABC[0]);
                B[i - 1] = int.Parse(ABC[1]);
                C[i - 1] = int.Parse(ABC[2]);
            }

            Console.WriteLine(GetAnswer(input.Length - 1, A, B, C));
        }
    }
}
