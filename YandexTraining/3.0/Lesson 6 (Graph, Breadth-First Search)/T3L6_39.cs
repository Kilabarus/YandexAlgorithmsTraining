using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_6__Graph__Breadth_First_Search_
{
    internal class T3L6_39
    {
        static string[][] GetInput()
        {
            int N = int.Parse(Console.ReadLine());
            string[][] result = new string[N][];

            for (int i = 0; i < N; i++)
            {
                Console.ReadLine();

                result[i] = new string[N];

                for (int j = 0; j < N; j++)
                {
                    result[i][j] = Console.ReadLine();
                }
            }

            return result;
        }

        static string GetAnswer(string[][] cave)
        {
            int N = cave.Length;

            BitArray[][] visited = new BitArray[N][];

            (int X, int Y, int Z) S = (-1, -1, -1);
            bool found = false;

            for (int i = 0; i < N; i++)
            {
                visited[i] = new BitArray[N];

                for (int j = 0; j < N; j++)
                {
                    visited[i][j] = new(N);

                    if (!found)
                    {
                        S = (i, j, cave[i][j].IndexOf('S'));

                        if (S.Z != -1)
                        {
                            found = true;
                        }
                    }
                }
            }

            visited[S.X][S.Y][S.Z] = true;

            List<List<(int X, int Y, int Z)>> distance = new();

            distance.Add(new List<(int X, int Y, int Z)>());
            distance[0].Add((S.X, S.Y, S.Z));

            int currDistance = 0;

            int[] dx = new int[] { 0, 0, 0, 0, 1, -1 };
            int[] dy = new int[] { 0, 0, 1, -1, 0, 0 };
            int[] dz = new int[] { 1, -1, 0, 0, 0, 0 };

            int x, y, z;

            while (true)
            {
                distance.Add(new());

                foreach (var cell in distance[currDistance])
                {
                    for (int j = 0; j < dx.Length; j++)
                    {
                        x = cell.X + dx[j];
                        y = cell.Y + dy[j];
                        z = cell.Z + dz[j];

                        if (IsValidXYZ(x, y, z, N) && cave[x][y][z] != '#' && !visited[x][y][z])
                        {
                            if (x == 0)
                            {
                                return (currDistance + 1).ToString();
                            }

                            visited[x][y][z] = true;
                            distance[currDistance + 1].Add((x, y, z));
                        }
                    }
                }

                ++currDistance;
            }

            return "Jokerge";
        }

        static bool IsValidXYZ(int x, int y, int z, int N)
        {
            return x >= 0 && y >= 0 && z >= 0 && x < N && y < N && z < N;
        }

        static void Solution()
        {
            string[][] input = GetInput();

            Console.WriteLine(GetAnswer(input));
        }
    }
}
