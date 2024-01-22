using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L3_23
    {
        static string GetInput()
        {
            return Console.ReadLine();
        }

        static string GetAnswer(int goal)
        {
            int[] dp = new int[goal + 1];

            for (int i = 0; i < goal + 1; i++)
            {
                dp[i] = i - 1;
            }

            for (int i = 2; i < goal + 1; i++)
            {
                if (i % 3 == 0 && dp[i / 3] + 1 < dp[i])
                {
                    dp[i] = dp[i / 3] + 1;
                }

                if (i % 2 == 0 && dp[i / 2] + 1 < dp[i])
                {
                    dp[i] = dp[i / 2] + 1;
                }

                if (dp[i - 1] + 1 < dp[i])
                {
                    dp[i] = dp[i - 1] + 1;
                }
            }

            List<int> resSeq = new(20);

            while (goal != 1)
            {
                resSeq.Add(goal);

                if (goal % 3 == 0 && dp[goal] == dp[goal / 3] + 1)
                {
                    goal = goal / 3;
                    continue;
                }

                if (goal % 2 == 0 && dp[goal] == dp[goal / 2] + 1)
                {
                    goal = goal / 2;
                    continue;
                }

                --goal;
            }

            resSeq.Add(1);

            StringBuilder sB = new();

            resSeq.Reverse();

            foreach (int i in resSeq)
            {
                sB.Append($"{i} ");
            }

            return $"{dp[dp.Length - 1]}\n{sB}";
        }

        static void Solution()
        {
            string input = GetInput();

            int N = int.Parse(input);

            Console.WriteLine(GetAnswer(N));
        }
    }
}
