using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_2
{
    internal class T1L2_A
    {
        static string[] GetInput()
        {
            return Console.ReadLine().Split(' ');
        }

        static string GetAnswer(string[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                if (int.Parse(nums[i]) <= int.Parse(nums[i - 1]))
                {
                    return "NO";
                }
            }

            return "YES";
        }

        static void Solution()
        {
            string[] input = GetInput();

            Console.WriteLine(GetAnswer(input));
        }
    }
}
