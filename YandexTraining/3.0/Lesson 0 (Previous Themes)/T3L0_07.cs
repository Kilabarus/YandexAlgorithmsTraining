using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_07
    {
        static string[] GetInput()
        {
            string[] input = new string[3];

            input[0] = Console.ReadLine();
            input[1] = Console.ReadLine();
            input[2] = Console.ReadLine();

            return input;
        }

        static string GetAnswer((int h, int m, int s) A, (int h, int m, int s) B, (int h, int m, int s) C)
        {
            const int SECONDS_IN_MINUTE = 60;
            const int SECONDS_IN_HOUR = 60 * 60;
            const int SECONDS_IN_DAY = 60 * 60 * 24;

            int AinSeconds, BinSeconds, CinSeconds;

            AinSeconds = A.h * SECONDS_IN_HOUR + A.m * SECONDS_IN_MINUTE + A.s;
            BinSeconds = B.h * SECONDS_IN_HOUR + B.m * SECONDS_IN_MINUTE + B.s;
            CinSeconds = C.h * SECONDS_IN_HOUR + C.m * SECONDS_IN_MINUTE + C.s;

            if (AinSeconds <= CinSeconds)
            {
                BinSeconds += (int)Math.Round((CinSeconds - AinSeconds) / 2.0, 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                BinSeconds += (int)Math.Round((CinSeconds + (SECONDS_IN_DAY - AinSeconds)) / 2.0, 0, MidpointRounding.AwayFromZero);
            }

            if (BinSeconds > SECONDS_IN_DAY)
            {
                BinSeconds -= SECONDS_IN_DAY;
            }

            return $"{BinSeconds / SECONDS_IN_HOUR,2:D2}:{BinSeconds % SECONDS_IN_HOUR / SECONDS_IN_MINUTE,2:D2}:{BinSeconds % SECONDS_IN_HOUR % SECONDS_IN_MINUTE,2:D2}";
        }

        static void Solution()
        {
            string[] input = GetInput();

            string[] As = input[0].Split(":");
            string[] Bs = input[1].Split(":");
            string[] Cs = input[2].Split(":");

            (int h, int m, int s) A = (int.Parse(As[0]), int.Parse(As[1]), int.Parse(As[2]));
            (int h, int m, int s) B = (int.Parse(Bs[0]), int.Parse(Bs[1]), int.Parse(Bs[2]));
            (int h, int m, int s) C = (int.Parse(Cs[0]), int.Parse(Cs[1]), int.Parse(Cs[2]));

            Console.WriteLine(GetAnswer(A, B, C));
        }
    }
}
