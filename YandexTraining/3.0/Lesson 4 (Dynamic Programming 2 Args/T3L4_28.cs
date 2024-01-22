using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_4
{
    internal class T3L4_28
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static int[][] dp;        

        static string GetAnswer(int N, int M)
        {
            dp = new int[N][];

            for (int i = 0; i < N; i++)
            {
                dp[i] = new int[M];
            }

            dp[0][0] = 1;

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < M; j++)
                {
                    if (i - 2 >= 0 && j - 1 >= 0)
                    {
                        dp[i][j] += dp[i - 2][j - 1];
                    }

                    if (i - 1 >= 0 && j - 2 >= 0)
                    {
                        dp[i][j] += dp[i - 1][j - 2];
                    }
                }
            }

            return dp[N - 1][M - 1].ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            int N = int.Parse(input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
            int M = int.Parse(input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

            Console.WriteLine(GetAnswer(N, M));
        }
    }
}
