using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_08
    {
        static string[][] GetInput()
        {
            int K = int.Parse(Console.ReadLine());
            string[][] input = new string[K][];

            for (int i = 0; i < K; i++)
            {
                input[i] = Console.ReadLine().Split(" ");
            }

            return input;
        }

        static string GetAnswer((int X, int Y)[] coords)
        {
            int xMin = coords[0].X, xMax = coords[0].X, yMin = coords[0].Y, yMax = coords[0].Y;

            for (int i = 1; i < coords.Length; i++)
            {
                if (coords[i].X < xMin)
                {
                    xMin = coords[i].X;
                }

                if (coords[i].X > xMax)
                {
                    xMax = coords[i].X;
                }

                if (coords[i].Y < yMin)
                {
                    yMin = coords[i].Y;
                }

                if (coords[i].Y > yMax)
                {
                    yMax = coords[i].Y;
                }
            }

            return $"{xMin} {yMin} {xMax} {yMax}";
        }

        static void Solution()
        {
            string[][] input = GetInput();

            (int X, int Y)[] coords = new (int, int)[input.Length];

            for (int i = 0; i < coords.Length; i++)
            {
                coords[i] = (int.Parse(input[i][0]), int.Parse(input[i][1]));
            }

            Console.WriteLine(GetAnswer(coords));
        }
    }
}
