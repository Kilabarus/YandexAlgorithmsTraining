using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_4
{
    internal class T3L4_27
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static int[][] dp;
        static char[][] dir;

        static string GetAnswer(int[][] matrix)
        {
            dp = new int[matrix.Length][];
            dir = new char[matrix.Length][];

            int fromUp, fromLeft;
            int i, j;

            for (i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[0].Length];
                dir[i] = new char[matrix[0].Length];

                for (j = 0; j < matrix[0].Length; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            dp[i][j] = matrix[i][j];
                            continue;
                        }

                        dp[i][j] = dp[i][j - 1] + matrix[i][j];
                        dir[i][j] = 'L';
                        continue;
                    }

                    if (j == 0)
                    {
                        dp[i][j] = dp[i - 1][j] + matrix[i][j];
                        dir[i][j] = 'U';
                        continue;
                    }

                    fromUp = dp[i - 1][j];
                    fromLeft = dp[i][j - 1];

                    if (fromUp > fromLeft)
                    {
                        dp[i][j] = fromUp + matrix[i][j];
                        dir[i][j] = 'U';

                        continue;
                    }

                    dp[i][j] = fromLeft + matrix[i][j];
                    dir[i][j] = 'L';
                }
            }

            StringBuilder sB = new();

            i = matrix.Length - 1;
            j = matrix[0].Length - 1;

            while (i > 0 || j > 0)
            {
                if (dir[i][j] == 'U')
                {
                    sB.Append("D ");
                    --i;

                    continue;
                }

                sB.Append("R ");
                --j;
            }

            return $"{dp[matrix.Length - 1][matrix[0].Length - 1]}\n{new string(sB.ToString().Trim().Reverse().ToArray())}";
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
