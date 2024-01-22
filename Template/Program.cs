using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexTraining
{
    internal class Program
    {
        static List<List<string>> GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            List<List<string>> input = new();

            #region Entries
            //int numOfEntries = ReadInt32();
            //for (int i = 0; i < numOfEntries; i++)
            //{
            //    input.Add(Console.ReadLine());
            //}
            #endregion

            #region Groups of Entries
            //int numOfGroups = ReadInt32();

            //for (int i = 0; i < numOfGroups; i++)
            //{
            //    int numOfEntries = ReadInt32();
            //    List<string> entries = new List<string>();

            //    for (int j = 0; j < numOfEntries; j++)
            //    {
            //        entries.Add(Console.ReadLine());
            //    }

            //    input.Add(entries);
            //}
            #endregion

            return input;
        }

        static void Solve(List<List<string>> input)
        {
            
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}