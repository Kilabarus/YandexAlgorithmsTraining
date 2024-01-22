using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_09
    {
        static (int N, int M, int K, string[][] Matrix, string[][] Queues) GetInput()
        {
            string[] input = Console.ReadLine().Split(" ");

            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int K = int.Parse(input[2]);

            string[][] matrix = new string[N][];

            for (int i = 0; i < N; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ");
            }

            string[][] queues = new string[K][];

            for (int i = 0; i < K; i++)
            {
                queues[i] = Console.ReadLine().Split(" ");
            }

            return (N, M, K, matrix, queues);
        }

        static string GetAnswer(int N, int M, int K, int[][] matrix, (int x1, int y1, int x2, int y2)[] queues)
        {
            int sum;

            for (int i = 0; i < N; i++)
            {
                sum = 0;

                for (int j = 0; j < M; j++)
                {
                    sum += matrix[i][j];

                    if (i == 0)
                    {
                        matrix[i][j] = sum;
                        continue;
                    }

                    matrix[i][j] = matrix[i - 1][j] + sum;
                }
            }

            StringBuilder sB = new();

            int i11, i12, i21, i22;

            foreach (var q in queues)
            {
                i22 = matrix[q.x2 - 1][q.y2 - 1];
                i12 = q.x1 == 1 ? 0 : matrix[q.x1 - 2][q.y2 - 1];
                i21 = q.y1 == 1 ? 0 : matrix[q.x2 - 1][q.y1 - 2];
                i11 = q.x1 == 1 || q.y1 == 1 ? 0 : matrix[q.x1 - 2][q.y1 - 2];

                sB.Append($"{i22 - i12 - i21 + i11}\n");
            }

            return sB.ToString();
        }

        static void Solution()
        {
            (int N, int M, int K, string[][] MatrixStr, string[][] QueuesStr) input = GetInput();

            int[][] matrix = new int[input.N][];

            for (int i = 0; i < input.N; i++)
            {
                matrix[i] = new int[input.M];

                for (int j = 0; j < input.M; j++)
                {
                    matrix[i][j] = int.Parse(input.MatrixStr[i][j]);
                }
            }

            (int x1, int y1, int x2, int y2)[] queues = new (int x1, int y1, int x2, int y2)[input.K];

            for (int i = 0; i < input.K; i++)
            {
                queues[i] = (int.Parse(input.QueuesStr[i][0]), int.Parse(input.QueuesStr[i][1]), int.Parse(input.QueuesStr[i][2]), int.Parse(input.QueuesStr[i][3]));
            }

            Console.WriteLine(GetAnswer(input.N, input.M, input.K, matrix, queues));
        }
    }
}
