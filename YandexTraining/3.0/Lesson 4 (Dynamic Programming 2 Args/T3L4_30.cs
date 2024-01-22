using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_4
{
    internal class T3L4_30
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static string GetAnswer(int[] seqL, int[] seqR)
        {
            int[][] dp = new int[seqL.Length + 1][];

            int i, j;

            for (i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[seqR.Length + 1];
            }

            for (i = 1; i < dp.Length; i++)
            {
                for (j = 1; j < dp[0].Length; j++)
                {
                    if (seqL[i - 1] == seqR[j - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1] + 1;
                        continue;
                    }

                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }

            List<int> l = new();

            i = dp.Length - 1;
            j = dp[0].Length - 1;

            while (i > 0 || j > 0)
            {
                if (j > 0 && dp[i][j] == dp[i][j - 1])
                {
                    --j;
                    continue;
                }

                if (i > 0 && dp[i][j] == dp[i - 1][j])
                {
                    --i;
                    continue;
                }

                if (i > 0 && j > 0 && dp[i][j] == dp[i - 1][j - 1] + 1)
                {
                    l.Add(seqL[i - 1]);
                    --i;
                    --j;

                    continue;
                }
            }

            l.Reverse();

            StringBuilder sB = new();

            foreach (var item in l)
            {
                sB.Append($"{item} ");
            }

            return sB.ToString().Trim();
        }

        static void Solution()
        {
            string[] input = GetInput();

            int[] seqL = Array.ConvertAll(input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int[] seqR = Array.ConvertAll(input[3].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

            Console.WriteLine(GetAnswer(seqL, seqR));
            Console.WriteLine();
            //Console.WriteLine(File.ReadAllText("a.txt"));
        }
    }
}
