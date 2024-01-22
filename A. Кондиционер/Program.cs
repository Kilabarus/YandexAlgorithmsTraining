using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://contest.yandex.ru/contest/27393/problems/A/

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
                Console.ReadLine()
            };

            return input;
        }

        static void Solve(List<string> input)
        {
            int currentTemperature = Convert.ToInt32(input[0].Split()[0]);
            int neededTemperature = Convert.ToInt32(input[0].Split()[1]);

            string mode = input[1];

            int resultTemperature = mode switch
            {
                "freeze" => neededTemperature < currentTemperature
                                ? neededTemperature
                                : currentTemperature,
                "heat"   => neededTemperature > currentTemperature
                                ? neededTemperature
                                : currentTemperature,
                "auto"   => neededTemperature,
                _        => currentTemperature
            };

            Console.WriteLine(resultTemperature);
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}