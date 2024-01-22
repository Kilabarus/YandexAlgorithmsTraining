using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_4
{
    internal class T3L4_26
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static int[][] dp;
        static int[][] m;
        static int currWeight;

        static string GetAnswer(int[][] matrix)
        {
            m = matrix;
            dp = new int[matrix.Length][];
            currWeight = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[0].Length];

                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = -1;
                }
            }

            BFS(0, 0);

            return dp[matrix.Length - 1][matrix[0].Length - 1].ToString();
        }

        static void BFS(int i, int j)
        {
            if (i < 0 || i >= m.Length || j < 0 || j >= m[0].Length)
            {
                return;
            }

            currWeight += m[i][j];

            if (dp[i][j] == -1 || currWeight < dp[i][j])
            {
                dp[i][j] = currWeight;
            }

            BFS(i + 1, j);
            BFS(i, j + 1);

            currWeight -= m[i][j];
        }

        static void Solution()
        {
            string[] input = GetInput();

            int N = int.Parse(input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
            int M = int.Parse(input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

            int[][] matrix = new int[N][];

            for (int i = 1; i < input.Length; i++)
            {
                matrix[i - 1] = Array.ConvertAll(input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);
            }

            Console.WriteLine(GetAnswer(matrix));
        }
    }
}
