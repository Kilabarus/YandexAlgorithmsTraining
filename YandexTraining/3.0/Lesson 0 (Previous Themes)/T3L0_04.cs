using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_04
    {
        static string[] GetInput()
        {
            return new string[] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
        }

        static string GetAnswer(int numOfStudents, int numOfVars, int pRow, int pPlace)
        {
            int pPlaceAdj = 2 * (pRow - 1) + pPlace;

            if (pPlaceAdj > numOfStudents)
            {
                return "-1";
            }

            int pVar = (pPlaceAdj - 1) % numOfVars + 1;

            int vRow, vPlace;

            if (pPlaceAdj + numOfVars <= numOfStudents && pPlaceAdj - numOfVars > 0)
            {
                int possibleVRow1 = (pPlaceAdj + numOfVars + 1) / 2;
                int possibleVRow2 = (pPlaceAdj - numOfVars + 1) / 2;

                if (possibleVRow1 - pRow <= pRow - possibleVRow2)
                {
                    vRow = (pPlaceAdj + numOfVars + 1) / 2;
                    vPlace = (pPlaceAdj + numOfVars - 1) % 2 + 1;

                    return $"{vRow} {vPlace}";
                }

                vRow = (pPlaceAdj - numOfVars + 1) / 2;
                vPlace = (pPlaceAdj - numOfVars - 1) % 2 + 1;

                return $"{vRow} {vPlace}";
            }

            if (pPlaceAdj + numOfVars <= numOfStudents)
            {
                vRow = (pPlaceAdj + numOfVars + 1) / 2;
                vPlace = (pPlaceAdj + numOfVars - 1) % 2 + 1;

                return $"{vRow} {vPlace}";
            }

            if (pPlaceAdj - numOfVars > 0)
            {
                vRow = (pPlaceAdj - numOfVars + 1) / 2;
                vPlace = (pPlaceAdj - numOfVars - 1) % 2 + 1;

                return $"{vRow} {vPlace}";
            }

            return "-1";
        }

        static void Solution()
        {
            string[] input = GetInput();

            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);
            int row = int.Parse(input[2]);
            int place = int.Parse(input[3]);

            //Console.WriteLine(GetAnswer(N, K, row, place));
            Console.WriteLine(GetAnswer(N, K, row, place));
        }
    }
}
