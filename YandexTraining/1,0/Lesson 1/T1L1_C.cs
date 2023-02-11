using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_C
    {
        static (int code, int number) GetCodeAndNumber(string phoneNumber)
        {
            long phoneNumberInt = 0;
            int phoneNumberLength = 0;

            foreach (char c in phoneNumber)
            {
                if (c >= '0' && c <= '9')
                {
                    phoneNumberInt = phoneNumberInt * 10 + c - '0';
                    ++phoneNumberLength;
                }
            }

            return phoneNumberLength == 7
                ? (495, (int)(phoneNumberInt % 10_000_000))
                : ((int)(phoneNumberInt / 10_000_000 % 1000), (int)(phoneNumberInt % 10_000_000));
        }

        void Solution()
        {
            string newPhoneNumber = Console.ReadLine();
            string[] existingPhoneNumbers = new string[3] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };

            (int code, int number) codeAndNumber = GetCodeAndNumber(newPhoneNumber);

            foreach (string phoneNumber in existingPhoneNumbers)
            {
                if (codeAndNumber == GetCodeAndNumber(phoneNumber))
                {
                    Console.WriteLine("YES");
                    continue;
                }

                Console.WriteLine("NO");
            }
        }
    }
}
