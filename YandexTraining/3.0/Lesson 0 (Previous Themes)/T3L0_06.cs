using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_06
    {
        static string[][] GetInput()
        {
            Console.ReadLine();
            string[][] input = new string[int.Parse(Console.ReadLine())][];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadLine().Split(" ");
            }

            return input;
        }

        static bool IsCrossing(int a, int b, int c, int d)
        {
            return a <= d && c <= b;
        }

        static string GetAnswer((int Left, int Right)[] arr)
        {
            (int Left, int Right, bool IsActive)[] disk = new (int Left, int Right, bool IsActive)[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (disk[j].IsActive && IsCrossing(disk[j].Left, disk[j].Right, arr[i].Left, arr[i].Right))
                    {
                        disk[j].IsActive = false;
                    }
                }

                disk[i] = (arr[i].Left, arr[i].Right, true);
            }

            int count = 0;

            foreach ((int Left, int Right, bool IsActive) OS in disk)
            {
                if (OS.IsActive)
                {
                    ++count;
                }
            }

            return count.ToString();
        }

        static void Solution()
        {
            string[][] input = GetInput();

            (int, int)[] intervals = input.Select(x => (int.Parse(x[0]), int.Parse(x[1]))).ToArray();

            Console.WriteLine(GetAnswer(intervals));
        }
    }
}
