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

            List<string> input = new();

            #region Entries
            int numOfEntries = ReadInt32();
            for (int i = 0; i < numOfEntries; i++)
            {
                input.Add(Console.ReadLine());
            }
            #endregion

            return input;
        }

        static void Solve(List<string> input)
        {
            double low = 30;
            double high = 4000;            

            double previousFrequency = Convert.ToDouble(input[0]);

            for (int i = 1; i < input.Count; i++)
            {
                string[] t = input[i].Split(' ');
                (double currentFrequency, string description) = (Convert.ToDouble(t[0]), t[1]);                

                if (currentFrequency > previousFrequency)
                {
                    if (description == "closer")
                    {
                        low = Math.Max(low, previousFrequency + (currentFrequency - previousFrequency) / 2);
                        previousFrequency = currentFrequency;
                        continue;
                    }

                    high = Math.Min(high, currentFrequency - (currentFrequency - previousFrequency) / 2);
                    previousFrequency = currentFrequency;
                    continue;
                }

                if (description == "closer")
                {
                    high = Math.Min(high, previousFrequency - (previousFrequency - currentFrequency) / 2);
                    previousFrequency = currentFrequency;
                    continue;
                }

                low = Math.Max(low, currentFrequency + (previousFrequency - currentFrequency) / 2);
                previousFrequency = currentFrequency;
            }

            Console.WriteLine($"{low} {high}");
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}