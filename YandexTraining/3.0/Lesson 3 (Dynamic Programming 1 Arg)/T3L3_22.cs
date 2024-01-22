using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L3_22
    {
        static string GetInput()
        {
            return Console.ReadLine();
        }

        static int F(int[] dp, int N, int K)
        {
            int sum = 0;

            for (int i = N - 1; i >= N - K && i >= 0; i--)
            {
                if (dp[i] != -1)
                {
                    sum += dp[i];
                    continue;
                }

                int res = F(dp, i, K);

                dp[i] = res;
                sum += res;
            }

            return sum;
        }

        static string GetAnswer(int N, int K)
        {
            if (N == 1)
            {
                return "1";
            }

            int[] dp = new int[N];

            for (int i = 0; i < N; i++)
            {
                dp[i] = -1;
            }

            dp[1] = 1;
            dp[0] = 1;

            return F(dp, N - 1, K).ToString();
        }

        static void Solution()
        {
            string[] input = GetInput().Split(" ");

            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);

            Console.WriteLine(GetAnswer(N, K));
        }
    }
}
