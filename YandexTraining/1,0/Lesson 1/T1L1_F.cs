using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_F
    {
        static string[] GetInput()
        {
            return Console.ReadLine().Split(' ');
        }

        static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        static string GetAnswer(int l1, int w1, int l2, int w2)
        {
            if (l1 < w1)
            {
                Swap(ref l1, ref w1);
            }

            if (l2 < w2)
            {
                Swap(ref l2, ref w2);
            }

            if (l1 < l2)
            {
                Swap(ref l1, ref l2);
                Swap(ref w1, ref w2);
            }

            int prevMinS = l1 * (w1 + w2);
            string answer = $"{l1} {w1 + w2}";

            if (l2 <= w1 && (l1 + w2) * w1 < prevMinS)
            {
                prevMinS = (l1 + w2) * w1;
                answer = $"{l1 + w2} {w1}";
            }

            if (l2 > w1 && (l1 + w2) * l2 < prevMinS)
            {
                prevMinS = (l1 + w2) * l2;
                answer = $"{l1 + w2} {l2}";
            }

            if (w2 <= w1 && w1 * (l1 + l2) < prevMinS)
            {
                prevMinS = w1 * (l1 + l2);
                answer = $"{w1} {l1 + l2}";
            }

            if (w2 > w1 && w2 * (l1 + l2) < prevMinS)
            {
                prevMinS = w2 * (l1 + l2);
                answer = $"{w2} {l1 + l2}";
            }

            return answer;
        }

        static void Solution(string[] args)
        {
            string[] input = GetInput();

            int l1 = int.Parse(input[0]);
            int w1 = int.Parse(input[1]);
            int l2 = int.Parse(input[2]);
            int w2 = int.Parse(input[3]);

            Console.WriteLine(GetAnswer(l1, w1, l2, w2));
            return;
        }
    }
}
