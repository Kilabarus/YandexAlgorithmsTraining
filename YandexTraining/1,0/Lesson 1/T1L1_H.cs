using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_H
    {
        static string[] GetInput()
        {
            return new string[4] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
        }

        static string GetAnswer(int intervalLeft, int intervalRight, int CountLeft, int CountRight)
        {
            int timeMinLeft = CountLeft + (CountLeft - 1) * intervalLeft;
            int timeMinRight = CountRight + (CountRight - 1) * intervalRight;
            int timeMin = timeMinLeft > timeMinRight ? timeMinLeft : timeMinRight;

            int timeMaxLeft = CountLeft + (CountLeft + 1) * intervalLeft;
            int timeMaxRight = CountRight + (CountRight + 1) * intervalRight;
            int timeMax = timeMaxLeft < timeMaxRight ? timeMaxLeft : timeMaxRight;

            if (timeMin > timeMax)
            {
                return "-1";
            }

            return $"{timeMin} {timeMax}";
        }

        static void Solution()
        {
            string[] input = GetInput();

            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int n = int.Parse(input[2]);
            int m = int.Parse(input[3]);

            Console.WriteLine(GetAnswer(a, b, n, m));
            return;
        }
    }
}
