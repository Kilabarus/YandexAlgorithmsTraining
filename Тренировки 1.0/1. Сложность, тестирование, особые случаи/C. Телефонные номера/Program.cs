using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            List<string> input = new List<string>()
            {
                Console.ReadLine(),
                Console.ReadLine(),
                Console.ReadLine(),
                Console.ReadLine(),
            };
            return input;
        }

        static void Solve(List<string> input)
        {
            string GetFormattedPhoneNumber(string phoneNumber)
            {
                string formattedPhoneNumber = phoneNumber
                    .Replace("-", "")
                    .Replace("+", "")
                    .Replace("(", "")
                    .Replace(")", "");

                return formattedPhoneNumber.Length == 7
                    ? "495" + formattedPhoneNumber
                    : formattedPhoneNumber.Substring(1);
            }

            string newPhoneNumber = GetFormattedPhoneNumber(input[0]);

            for (int i = 1; i < input.Count; i++)
            {
                if (newPhoneNumber == GetFormattedPhoneNumber(input[i]))
                {
                    Console.WriteLine("YES");
                    continue;
                }

                Console.WriteLine("NO");
            }
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}