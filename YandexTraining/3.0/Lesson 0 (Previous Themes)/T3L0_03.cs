using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_03
    {
        static string[][] GetInput()
        {
            return new string[][] { new string[] { Console.ReadLine() }, Console.ReadLine().Split(' '), new string[] { Console.ReadLine() }, Console.ReadLine().Split(' ') };
        }

        static string GetAnswer(int N, int[] diegoStickers, int K, int[] othersStickers)
        {
            diegoStickers = diegoStickers.Distinct().ToArray();
            Array.Sort(diegoStickers);

            StringBuilder sB = new();
            int left, middle, right;

            foreach (int otherSticker in othersStickers)
            {
                left = 0;
                right = diegoStickers.Length - 1;

                while (left < right)
                {
                    middle = left + (right - left) / 2;

                    if (otherSticker <= diegoStickers[middle])
                    {
                        right = middle;
                        continue;
                    }

                    left = middle + 1;
                }

                if (diegoStickers[right] < otherSticker)
                {
                    ++right;
                }

                sB.Append($"{right}\n");
            }

            return sB.ToString();
        }

        static void Solution()
        {
            string[][] input = GetInput();

            int N = int.Parse(input[0][0]);
            int[] diegoStickers = Array.ConvertAll(input[1], int.Parse);
            int K = int.Parse(input[2][0]);
            int[] othersStickers = Array.ConvertAll(input[3], int.Parse);

            Console.WriteLine(GetAnswer(N, diegoStickers, K, othersStickers));
        }
    }
}
