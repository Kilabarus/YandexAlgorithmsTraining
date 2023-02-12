using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    // https://contest.yandex.ru/contest/27393/problems/B/
    internal class T1L1_B
    {
        void Solution()
        {
            int AB = int.Parse(Console.ReadLine());
            int BC = int.Parse(Console.ReadLine());
            int CA = int.Parse(Console.ReadLine());

            if (AB == 0 || BC == 0 || CA == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            if (AB + BC > CA && BC + CA > AB && CA + AB > BC)
            {
                Console.WriteLine("YES");
                return;
            }

            Console.WriteLine("NO");
        }
    }
}
