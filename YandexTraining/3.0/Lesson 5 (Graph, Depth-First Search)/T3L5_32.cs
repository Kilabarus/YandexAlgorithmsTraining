using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_5__Graph__Depth_First_Search_
{
    internal class T3L5_32
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

            int[] visited = new int[vertices + 1];

            for (int i = 1; i < visited.Length; i++)
            {
                if (visited[i] == 0)
                {
                    DFS(adjList, visited, i, i);
                }
            }            

            Dictionary<int, List<int>> components = new();

            for (int i = 1; i < visited.Length; i++)
            {
                if (!components.ContainsKey(visited[i]))
                {
                    components.Add(visited[i], new());
                }

                components[visited[i]].Add(i);
            }

            StringBuilder result = new();
            result.AppendLine($"{components.Count()}");

            foreach (var component in components.Keys)
            {
                result.AppendLine(components[component].Count().ToString());

                foreach (int edge in components[component])
                {
                    result.Append($"{edge} ");
                }

                result.Append("\n");
            }

            return result.ToString();
        }

        static void DFS(Dictionary<int, List<int>> adjList, int[] visited, int currVertex, int componentNumber)
        {
            visited[currVertex] = componentNumber;

            if (adjList.ContainsKey(currVertex))
            {
                foreach (int vertex in adjList[currVertex])
                {
                    if (visited[vertex] == 0)
                    {
                        DFS(adjList, visited, vertex, componentNumber);
                    }
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
