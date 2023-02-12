using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    // https://contest.yandex.ru/contest/27393/problems/D/
    internal class T1L1_D
    {
        void Solution()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (c < 0)
            {
                Console.WriteLine("NO SOLUTION");
                return;
            }

            if (a == 0)
            {
                if (b == c * c)
                {
                    Console.WriteLine("MANY SOLUTIONS");
                    return;
                }

                Console.WriteLine("NO SOLUTION");
                return;
            }

            if ((c * c - b) % a > 0)
            {
                Console.WriteLine("NO SOLUTION");
                return;
            }

            int x = (c * c - b) / a;

            if (a * x + b >= 0)
            {
                Console.WriteLine(x);
                return;
            }

            Console.WriteLine("NO SOLUTION");
            return;
        }
    }
}
