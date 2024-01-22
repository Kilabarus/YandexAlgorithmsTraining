using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_6__Graph__Breadth_First_Search_
{
    internal class T3L6_38
    {
        static (int N, int M, int S, int T, int Q, List<(int Row, int Column)> Fleas) GetInput()
        {
            string[] t = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int N = int.Parse(t[0]);
            int M = int.Parse(t[1]);

            int S = int.Parse(t[2]);
            int T = int.Parse(t[3]);

            int Q = int.Parse(t[4]);

            List<(int Row, int Column)> fleas = new();

            for (int i = 0; i < Q; i++)
            {
                t = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                fleas.Add((int.Parse(t[0]), int.Parse(t[1])));
            }

            return (N, M, S, T, Q, fleas);
        }

        static string GetAnswer(int rows, int columns, int feederRow, int feederColumn, List<(int Row, int Column)> fleas)
        {
            int[][] m = new int[rows + 1][];

            for (int i = 1; i < m.Length; i++)
            {
                m[i] = new int[columns + 1];

                for (int j = 0; j < m[1].Length; j++)
                {
                    m[i][j] = -1;
                }
            }

            m[feederRow][feederColumn] = 0;


            List<List<(int Row, int Column)>> distanceToPoints = new();
            distanceToPoints.Add(new());
            distanceToPoints[0].Add((feederRow, feederColumn));

            int[] dx = new int[] { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] dy = new int[] { -1, 1, -2, 2, -2, 2, -1, 1 };

            int x, y;

            int currDistance = 0;
            while (distanceToPoints[currDistance].Count > 0)
            {
                distanceToPoints.Add(new());

                foreach (var point in distanceToPoints[currDistance])
                {
                    for (int j = 0; j < dx.Length; j++)
                    {
                        x = point.Row + dx[j];
                        y = point.Column + dy[j];

                        if (IsValidXY(x, y, m.Length, m[1].Length) && m[x][y] == -1)
                        {
                            m[x][y] = currDistance + 1;
                            distanceToPoints[currDistance + 1].Add((x, y));
                        }
                    }
                }

                ++currDistance;
            }


            int sumDistance = 0;

            foreach (var flea in fleas)
            {
                if (m[flea.Row][flea.Column] == -1)
                {
                    return "-1";
                }

                sumDistance += m[flea.Row][flea.Column];
            }

            return sumDistance.ToString();
        }

        static bool IsValidXY(int x, int y, int N, int M)
        {
            return x >= 1 && y >= 1 && x < N && y < M;
        }

        static void Solution()
        {
            (int N, int M, int S, int T, int Q, List<(int Row, int Column)> Fleas) input = GetInput();

            Console.WriteLine(GetAnswer(input.N, input.M, input.S, input.T, input.Fleas));
        }
    }
}
