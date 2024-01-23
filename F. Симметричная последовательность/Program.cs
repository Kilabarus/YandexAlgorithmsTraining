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

            Console.ReadLine();
            string input = Console.ReadLine();           

            return input;
        }

        static void Solve(string input)
        {   
            bool IsSymmetrical(List<int> list)
            {
                for (int i = 0; i <= list.Count / 2; i++) 
                {
                    if (list[i] != list[list.Count - 1 - i])
                    {
                        return false;
                    }
                }

                return true;
            }

            List<int> original = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToList();
            List<int> reversed = new(original);
            reversed.Reverse();
            
            for (int i = 0; i < original.Count; i++)
            {
                List<int> possibleSolution = new(original);
                possibleSolution.InsertRange(possibleSolution.Count, reversed.TakeLast(i));

                if (IsSymmetrical(possibleSolution))
                {
                    Console.WriteLine(i);

                    foreach (var elem in reversed.TakeLast(i))
                    {
                        Console.Write(elem);
                        Console.Write(' ');
                    }

                    return;
                }
            }
        }

        static void Main(string[] args)
        {                        
            Solve(GetInput());
        }
    }
}