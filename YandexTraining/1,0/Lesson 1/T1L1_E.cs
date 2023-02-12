using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    // https://contest.yandex.ru/contest/27393/problems/E/
    internal class T1L1_E
    {
        static bool IsInteger(double number)
        {
            return Math.Abs(number % 1) <= (Double.Epsilon * 100);
        }

        static void Solution(string[] args)
        {
            // K1 M K2 P2 N2
            string[] input = Console.ReadLine().Split(' ');

            int K1 = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int K2 = int.Parse(input[2]);
            int P2 = int.Parse(input[3]);
            int N2 = int.Parse(input[4]);

            // Этаж не может быть больше кол-ва этажей в доме
            if (N2 > M)
            {
                Console.WriteLine("-1 -1");
                return;
            }

            // Номер этажа, если бы подъезды ставились друг на друга (N2S от N2Stacked)
            int N2S = M * (P2 - 1) + N2;

            // Номер квартиры не может быть меньше номера этажа, потому что на каждом этаже как минимум 1 квартира
            if (K2 < N2S)
            {
                Console.WriteLine("-1 -1");
                return;
            }

            // 1-ая квартира всегда будет на 1-ом этаже 1-го подъезда
            if (K1 == 1)
            {
                Console.WriteLine("1 1");
                return;
            }

            // Если предыдущая квартира (K2) находится на 1-ом этаже 1-го подъезда
            //      и при этом номер новой квартиры (K1) меньше, то она тоже будет находиться на 1-ом этаже 1-го подъезда
            if (P2 == 1 && N2 == 1 && K1 < K2)
            {
                Console.WriteLine("1 1");
                return;
            }

            // Если предыдущая квартира (K2) находилась на 1-м этаже, то зачастую сказать что-то будет сложно, но
            if (N2S == 1)
            {
                // Если кол-во этажей в доме больше, чем номер новой квартиры, то она точно в 1-ом подъезде
                if (M >= K1)
                {
                    Console.WriteLine("1 0");
                    return;
                }

                // Иначе, если этажей всего 1, то квартира будет находится на 1-ом
                if (M == 1)
                {
                    Console.WriteLine("0 1");
                    return;
                }

                // Иначе ничего сказать нельзя
                Console.WriteLine("0 0");
                return;
            }

            // APF (Apartments Per Floor) - кол-во квартир на этаже
            // Далее формулы, выведенные из фактов, что
            //      a) квартир на всех предыдущих этажах до этажа K2 должно быть строго меньше K2,
            //      б) квартир на всех этажах, включая этаж с K2 должно быть больше или равно K2
            int APFMax = IsInteger(K2 * 1.0 / (N2S - 1)) ? K2 / (N2S - 1) - 1 : (int)Math.Floor(K2 * 1.0 / (N2S - 1));
            int APFMin = IsInteger(K2 * 1.0 / N2S) ? K2 / N2S : (int)Math.Ceiling(K2 * 1.0 / N2S);

            // Проверка на противоречие (например, 41-ая квартира никогда не может находится на 10-м этаже 1-го подъезда)
            if (APFMax < APFMin)
            {
                Console.WriteLine("-1 -1");
                return;
            }

            // Если противоречий нет, то проверка на дурака
            if (K1 == K2)
            {
                Console.WriteLine($"{P2} {N2}");
                return;
            }

            // Продолжение тех же формул, только теперь неизвестная переменная - стакнутый этаж квартиры K1
            int N1SMin = IsInteger(K1 * 1.0 / APFMax) ? K1 / APFMax : (int)Math.Ceiling(K1 * 1.0 / APFMax);
            int P1Min = IsInteger(N1SMin * 1.0 / M) ? N1SMin / M : (int)Math.Ceiling(N1SMin * 1.0 / M);
            int N1RealMin = N1SMin % M == 0 ? M : N1SMin % M;

            int N1SMax = IsInteger(K1 * 1.0 / APFMin) ? K1 / APFMin : (int)Math.Ceiling(K1 * 1.0 / APFMin);
            int P1Max = IsInteger(N1SMax * 1.0 / M) ? N1SMax / M : (int)Math.Ceiling(N1SMax * 1.0 / M);
            int N1RealMax = N1SMax % M == 0 ? M : N1SMax % M;


            if (P1Min == P1Max)
            {
                Console.Write($"{P1Min} ");
            }
            else
            {
                Console.Write($"0 ");
            }

            if (N1RealMin == N1RealMax)
            {
                Console.Write($"{N1RealMin}");
            }
            else
            {
                Console.Write($"0");
            }
        }
    }
}
