using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_G
    {
        static string[] GetInput()
        {
            return Console.ReadLine().Split(' ');
        }

        static string GetAnswer(int N, int K, int M)
        {
            int numOfDetails = 0;

            if (M > K)
            {
                return "0";
            }

            while (N >= K)
            {
                numOfDetails += (N / K) * (K / M);
                N = N % K + (N / K) * (K % M);
            }

            return numOfDetails.ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);
            int M = int.Parse(input[2]);

            Console.WriteLine(GetAnswer(N, K, M));
            return;
        }
    }
}
