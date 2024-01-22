using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_5__Graph__Depth_First_Search_
{
    internal class T3L5_31
    {
        static string[] GetInput()
        {
            return File.ReadAllLines("input.txt");
        }

        static string GetAnswer(int vertices, int edges, (int L, int R)[] graph)
        {
            Dictionary<int, List<int>> adjList = new();

            foreach (var connection in graph)
            {
                if (!adjList.ContainsKey(connection.L))
                {
                    adjList.Add(connection.L, new());
                }

                adjList[connection.L].Add(connection.R);

                if (!adjList.ContainsKey(connection.R))
                {
                    adjList.Add(connection.R, new());
                }

                adjList[connection.R].Add(connection.L);
            }

            BitArray visited = new(vertices + 1);
            visited[1] = true;

            if (adjList.ContainsKey(1))
            {
                DFS(adjList, visited, 1);
            }

            StringBuilder sB = new();
            int count = 0;

            for (int i = 1; i < visited.Length; i++)
            {
                if (visited[i])
                {
                    ++count;
                    sB.Append($"{i} ");
                }
            }

            return $"{count}\n{sB}";
        }

        static void DFS(Dictionary<int, List<int>> adjList, BitArray visited, int currVertex)
        {
            visited[currVertex] = true;

            foreach (int vertex in adjList[currVertex])
            {
                if (!visited[vertex])
                {
                    DFS(adjList, visited, vertex);
                }
            }
        }

        static void Solution()
        {
            string[] input = GetInput();

            int N = int.Parse(input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]);
            int M = int.Parse(input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

            (int L, int R)[] graph = new (int L, int R)[M];

            for (int i = 1; i <= M; i++)
            {
                graph[i - 1] = (int.Parse(input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[0]),
                    int.Parse(input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]));
            }

            Console.WriteLine(GetAnswer(N, M, graph));
        }
    }
}
