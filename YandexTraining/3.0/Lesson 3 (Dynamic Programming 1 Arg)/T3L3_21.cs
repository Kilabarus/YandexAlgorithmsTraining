using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L3_21
    {
        static string GetInput()
        {
            return Console.ReadLine();
        }

        static int F(int N, int onesBefore)
        {
            switch (N)
            {
                case 1:
                    switch (onesBefore)
                    {
                        case 0:
                        case 1:
                            return 2;
                        default:
                            return 1;
                    }
                case 2:
                    switch (onesBefore)
                    {
                        case 0:
                            return 4;
                        case 1:
                            return 3;
                        default:
                            return 2;
                    }                    
                default:
                    switch (onesBefore)
                    {
                        case 0:
                            return 2 * F(N - 2, 0) + F(N - 2, 1) + F(N - 2, 2);
                        case 1:
                            return 2 * F(N - 2, 0) + F(N - 2, 1);
                        default:
                            return F(N - 2, 0) + F(N - 2, 1);
                    }
            }

        }

        static string GetAnswer(int N)
        {
            return F(N, 0).ToString();
        }

        static void Solution()
        {
            string input = GetInput();

            Console.WriteLine(GetAnswer(int.Parse(input)));
        }
    }
}
