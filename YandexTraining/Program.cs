global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.Numerics;
using System.Text;

namespace YandexTraining
{
    internal class Program
    {
        static (int N, int W, List<(int a, int T)>) GetInput()
        {
            int N = int.Parse(Console.ReadLine());
            int W = int.Parse(Console.ReadLine());

            List<(int a, int T)> tasks = new ();

            string[] t;

            for (int i = 0; i < N; i++)
            {
                t = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                tasks.Add((int.Parse(t[0]), int.Parse(t[1])));
            }

            return (N, W, tasks);
        }

        static string GetAnswer(int N, int W, List<(int a, int T)> tasks)
        {
            PriorityQueue<int, int> heap = new();

            int count = 0;

            foreach (var task in tasks)
            {
                if (heap.Count == 0)
                {
                    if (count == 0)
                    {
                        ++count;
                        heap.Enqueue(0, task.a + task.T);
                    }
                }
            }
        }                

        static void Main()
        {
            (int N, int W, List<(int a, int T)> Tasks) input = GetInput();

            Console.WriteLine(GetAnswer(input.N, input.W, input.Tasks));
        }
    }
}