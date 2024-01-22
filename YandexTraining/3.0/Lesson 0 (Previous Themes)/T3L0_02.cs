using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_02
    {
        static string[] GetInput()
        {
            return new string[2] { Console.ReadLine(), Console.ReadLine() };
        }
  

        static string GetAnswer(int k, string str)
        {
            int maxLength = 1;
            int replaced;
            int left, right;

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                left = right = 0;
                replaced = 0;

                while (right < str.Length)
                {
                    if (str[right] != ch)
                    {
                        replaced++;
                    }

                    while (replaced > k)
                    {
                        if (str[left] != ch)
                        {
                            replaced--;
                        }

                        left++;
                    }

                    maxLength = Math.Max(maxLength, right - left + 1);
                    right++;
                }
            }

            return maxLength.ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            int k = int.Parse(input[0]);
            string str = input[1];

            Console.WriteLine(GetAnswer(k, str));
        }
    }
}
