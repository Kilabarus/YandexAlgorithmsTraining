using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_I
    {
        static string[] GetInput()
        {
            return new string[5] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
        }

        static bool IsFit(int l1, int w1, int l2, int w2)
        {
            return (l1 <= l2 && w1 <= w2) || (l1 <= w2 && w1 <= l2);
        }

        static string GetAnswer(int cubeA, int cubeB, int cubeC, int rectD, int rectE)
        {
            if (cubeA <= 0 || cubeB <= 0 || cubeC <= 0 || rectD <= 0 || rectE <= 0)
            {
                return "NO";
            }

            if (IsFit(cubeA, cubeB, rectD, rectE) ||
                IsFit(cubeB, cubeC, rectD, rectE) ||
                IsFit(cubeA, cubeC, rectD, rectE))
            {
                return "YES";
            }

            return "NO";
        }

        static void Solution()
        {
            string[] input = GetInput();

            int A = int.Parse(input[0]);
            int B = int.Parse(input[1]);
            int C = int.Parse(input[2]);
            int D = int.Parse(input[3]);
            int E = int.Parse(input[4]);

            Console.WriteLine(GetAnswer(A, B, C, D, E));
        }
    }
}
