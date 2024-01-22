using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_4
{
    internal class T3L4_29
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static string GetAnswer(int[] days)
        {
            int[][] dp = new int[days.Length + 1][];
            string[][] prev = new string[days.Length + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[days.Length + 1];
                prev[i] = new string[days.Length + 1];
            }

            dp[0][0] = 0;
            prev[0][0] = "";

            for (int i = 1; i < dp[0].Length; i++)
            {
                dp[0][i] = 10000;
                prev[0][i] = "";
            }

            for (int i = 1; i < dp.Length; i++)
            {
                if (dp[i - 1][0] + days[i - 1] < dp[i - 1][1])
                {
                    dp[i][0] = dp[i - 1][0] + days[i - 1];
                    prev[i][0] = prev[i - 1][0];
                }
                else
                {
                    dp[i][0] = dp[i - 1][1];
                    prev[i][0] = prev[i - 1][1] + $"{i}\n";
                }

                for (int j = 1; j < dp[0].Length - 1; j++)
                {
                    if (days[i - 1] > 100)
                    {
                        if (dp[i - 1][j - 1] + days[i - 1] < dp[i - 1][j + 1])
                        {
                            dp[i][j] = dp[i - 1][j - 1] + days[i - 1];
                            prev[i][j] = prev[i - 1][j - 1];
                        }
                        else
                        {
                            dp[i][j] = dp[i - 1][j + 1];
                            prev[i][j] = prev[i - 1][j + 1] + $"{i}\n";
                        }

                        continue;
                    }

                    if (dp[i - 1][j] + days[i - 1] < dp[i - 1][j + 1])
                    {
                        dp[i][j] = dp[i - 1][j] + days[i - 1];
                        prev[i][j] = prev[i - 1][j];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j + 1];
                        prev[i][j] = prev[i - 1][j + 1] + $"{i}\n";
                    }
                }

                if (days[i - 1] > 100)
                {
                    dp[i][dp[0].Length - 1] = dp[i - 1][dp[0].Length - 1 - 1] + days[i - 1];
                    prev[i][dp[0].Length - 1] = prev[i - 1][dp[0].Length - 1 - 1];
                    continue;
                }

                dp[i][dp[0].Length - 1] = dp[i - 1][dp[0].Length - 1] + days[i - 1];
                prev[i][dp[0].Length - 1] = prev[i - 1][dp[0].Length - 1];
            }

            int couponsLeft = dp[0].Length - 1;

            for (int i = dp[0].Length - 1; i >= 0; i--)
            {
                if (dp[dp.Length - 1][i] < dp[dp.Length - 1][couponsLeft])
                {
                    couponsLeft = i;
                }
            }

            return $"{dp[dp.Length - 1][couponsLeft]}\n{couponsLeft} {prev[dp.Length - 1][couponsLeft].Split("\n", StringSplitOptions.RemoveEmptyEntries).Count()}\n{prev[dp.Length - 1][couponsLeft]}";
        }

        static void Solution()
        {
            string[] input = GetInput();

            int N = int.Parse(input[0]);
            int[] arr = new int[N];

            for (int i = 0; i < N; i++)
            {
                arr[i] = int.Parse(input[i + 1]);
            }

            Console.WriteLine(GetAnswer(arr));
        }
    }
}
