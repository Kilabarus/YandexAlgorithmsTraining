using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_6__Graph__Breadth_First_Search_
{
    internal class T3L6_37
    {
        static (int N, Dictionary<int, HashSet<int>> AdjList, int Start, int End) GetInput()
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<int, HashSet<int>> result = new();

            string t;

            for (int i = 1; i < N + 1; i++)
            {
                t = Console.ReadLine();

                for (int j = i - 1; 2 * j < t.Length; j++)
                {
                    if (t[2 * j] == '1')
                    {
                        if (!result.ContainsKey(i))
                        {
                            result.Add(i, new());
                        }

                        result[i].Add(j + 1);

                        if (!result.ContainsKey(j + 1))
                        {
                            result.Add(j + 1, new());
                        }

                        result[j + 1].Add(i);
                    }
                }
            }

            string[] t1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return (N, result, int.Parse(t1[0]), int.Parse(t1[1]));
        }

        static string GetAnswer(int vertices, Dictionary<int, HashSet<int>> adjList, int start, int end)
        {
            if (start == end)
            {
                return "0";
            }

            List<List<int>> distanceFromStart = new();

            distanceFromStart.Add(new());
            distanceFromStart[0].Add(start);

            int[] visited = new int[vertices + 1];
            int[] prev = new int[vertices + 1];

            int i = 0;

            bool found = false;

            while (distanceFromStart[i].Count > 0 && !found)
            {
                foreach (int vertex in distanceFromStart[i])
                {
                    if (vertex == end)
                    {
                        found = true;
                    }

                    distanceFromStart.Add(new());

                    if (adjList.ContainsKey(vertex))
                    {
                        foreach (int newVertex in adjList[vertex])
                        {
                            if (visited[newVertex] == 0)
                            {
                                prev[newVertex] = vertex;
                                visited[newVertex] = 1;
                                distanceFromStart[i + 1].Add(newVertex);
                            }
                        }
                    }
                }

                ++i;
            }

            if (found)
            {
                List<int> path = new();
                int vertex = end;

                while (vertex != start)
                {
                    path.Add(vertex);
                    vertex = prev[vertex];
                }

                path.Add(start);

                path.Reverse();

                StringBuilder sB = new();

                foreach (int v in path)
                {
                    sB.Append($"{v} ");
                }

                return $"{path.Count - 1}\n{sB}";
            }

            return "-1";
        }

        static void Solution()
        {
            (int N, Dictionary<int, HashSet<int>> AdjList, int Start, int End) input = GetInput();

            Console.WriteLine(GetAnswer(input.N, input.AdjList, input.Start, input.End));
        }
    }
}
