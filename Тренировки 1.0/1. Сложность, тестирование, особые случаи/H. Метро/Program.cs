using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexTraining
{
    internal class Program
    {
        static List<int> GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            List<int> input = new List<int>()
            {
                ReadInt32(),
                ReadInt32(),
                ReadInt32(),
                ReadInt32(),
            };

            return input;
        }

        static void Solve(List<int> input)
        {
            int intervalLeft = input[0];
            int intervalRight = input[1];
            int countLeft = input[2];
            int countRight = input[3];

            int timeMinLeft = countLeft + (countLeft - 1) * intervalLeft;
            int timeMinRight = countRight + (countRight - 1) * intervalRight;
            int timeMin = timeMinLeft > timeMinRight 
                ? timeMinLeft 
                : timeMinRight;

            int timeMaxLeft = countLeft + (countLeft + 1) * intervalLeft;
            int timeMaxRight = countRight + (countRight + 1) * intervalRight;
            int timeMax = timeMaxLeft < timeMaxRight 
                ? timeMaxLeft 
                : timeMaxRight;

            if (timeMin > timeMax)
            {
                Console.WriteLine("-1");
                return;
            }

            Console.WriteLine($"{timeMin} {timeMax}");            
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}