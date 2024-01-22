global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
using System.Collections;
using System.Text;

namespace YandexTraining
{
    internal class Program1
    {
        static (int N, Dictionary<int, HashSet<int>> AdjList) GetInput()
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

            return (N, result);
        }

        static string GetAnswer(int vertices, Dictionary<int, HashSet<int>> adjList)
        {
            int[] visited = new int[vertices + 1];

            for (int i = 1; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                {
                    if (!DFS(adjList, visited, i, 0))
                    {
                        return $"YES\n{_count}\n{_verticesInCycle}";
                    }
                }
            }

            return "NO";
        }

        static int _firstCycleVertex;

        static StringBuilder _verticesInCycle = new();
        static bool _flag = true;
        static int _count = 0;

        static bool DFS(Dictionary<int, HashSet<int>> adjList, int[] visited, int currVertex, int prevVertex)
        {
            visited[currVertex] = 1;

            if (adjList.ContainsKey(currVertex))
            {
                foreach (int vertex in adjList[currVertex])
                {
                    if (visited[vertex] == 1 && prevVertex != vertex)
                    {
                        _verticesInCycle.Append($"{currVertex} ");
                        _firstCycleVertex = vertex;
                        ++_count;
                        return false;
                    }

                    if (visited[vertex] == 0)
                    {
                        if (!DFS(adjList, visited, vertex, currVertex))
                        {
                            if (_flag)
                            {
                                _verticesInCycle.Append($"{currVertex} ");
                                ++_count;
                                if (currVertex == _firstCycleVertex)
                                {
                                    _flag = false;
                                }
                            }
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        static void Solution()
        {
            (int N, Dictionary<int, HashSet<int>> AdjList) input = GetInput();

            Console.WriteLine(GetAnswer(input.N, input.AdjList));
        }
    }
}