using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_A
    {
        void Solution()
        {
            string[] temperatures = Console.ReadLine().Split(' ');
            string mode = Console.ReadLine();

            int tRoom = int.Parse(temperatures[0]);
            int tCond = int.Parse(temperatures[1]);
            int tFinal;

            switch (mode)
            {
                case "freeze":
                    tFinal = tRoom <= tCond ? tRoom : tCond;
                    break;
                case "heat":
                    tFinal = tRoom >= tCond ? tRoom : tCond;
                    break;
                case "auto":
                    tFinal = tCond;
                    break;
                default:
                    tFinal = tRoom;
                    break;
            }

            Console.WriteLine(tFinal);
        }
    }
}
