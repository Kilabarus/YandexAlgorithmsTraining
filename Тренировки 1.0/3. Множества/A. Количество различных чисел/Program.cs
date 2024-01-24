using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexTraining
{
    internal class Program
    {
        static string GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            string input = Console.ReadLine();

            return input;
        }

        static void Solve(string input)
        {
            List<int> l = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            HashSet<int> set = new HashSet<int>(l);

            Console.WriteLine(set.Count);
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}