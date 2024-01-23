using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//https://contest.yandex.ru/contest/27393/problems/J/

namespace YandexTraining
{
    internal class Program
    {
        static List<double> GetInput()
        {
            int ReadInt32()
            {
                return Convert.ToInt32(Console.ReadLine());
            }

            double ReadDouble()
            {
                return Convert.ToDouble(Console.ReadLine());
            }

            List<double> input = new List<double>()
            {
                ReadDouble(),
                ReadDouble(),
                ReadDouble(),
                ReadDouble(),
                ReadDouble(),
                ReadDouble(),
            };

            return input;
        }

        // ax + by = c
        static void SolveEquation(double a, double b, double c)
        {
            if (a == 0 && b == 0)
            {
                if (c == 0)
                {
                    Console.WriteLine("5");
                    return;
                }

                Console.WriteLine("0");
                return;
            }

            if (a == 0)
            {
                double y = c / b;
                Console.WriteLine($"4 {y}");
                return;
            }

            if (b == 0)
            {
                double x = c / a;
                Console.WriteLine($"3 {x}");
                return;
            }

            double B = c / b;
            double K = -a / b;

            Console.WriteLine($"1 {K} {B}");
            return;
        }

        static void Solve(List<double> input)
        {
            double a = input[0];
            double b = input[1];
            double c = input[2];
            double d = input[3];
            double e = input[4];
            double f = input[5];

            if (a == 0 && b == 0)
            {
                if (e != 0)
                {
                    Console.WriteLine("0");
                    return;
                }

                SolveEquation(c, d, f);
                return;
            }

            if (c == 0 && d == 0)
            {
                if (f != 0)
                {
                    Console.WriteLine("0");
                    return;
                }

                SolveEquation(a, b, e);
                return;
            }

            if (a == 0 && c == 0)
            {
                if (e / b == f / d)
                {
                    Console.WriteLine($"4 {e / b}");
                    return;
                }

                Console.WriteLine("0");
                return;
            }

            if (b == 0 && d == 0)
            {
                if (e / a == f / c)
                {
                    Console.WriteLine($"3 {e / a}");
                    return;
                }

                Console.WriteLine("0");
                return;
            }

            if (a == 0 && d == 0)
            {
                Console.WriteLine($"2 {f / c} {e / b}");
                return;
            }

            if (b == 0 && c == 0)
            {
                Console.WriteLine($"2 {e / a} {f / d}");
                return;
            }

            double y;
            double x;

            if (a == 0)
            {
                y = e / b;
                x = (f - d * y) / c;

                Console.WriteLine($"2 {x} {y}");
                return;
            }

            if (b == 0)
            {
                x = e / a;
                y = (f - c * x) / d;

                Console.WriteLine($"2 {x} {y}");
                return;
            }

            if (c == 0)
            {
                y = f / d;
                x = (e - b * y) / a;

                Console.WriteLine($"2 {x} {y}");
                return;
            }

            if (d == 0)
            {
                x = f / c;
                y = (e - a * x) / b;

                Console.WriteLine($"2 {x} {y}");
                return;
            }

            if (a * d - c * b == 0)
            {
                if (f * a - c * e == 0)
                {
                    double K = -a / b;
                    double B = e / b;

                    Console.WriteLine($"1 {K} {B}");
                    return;
                }

                Console.WriteLine("0");
                return;
            }

            y = (f * a - c * e) / (a * d - c * b);
            x = (e - b * y) / a;

            Console.WriteLine($"2 {x} {y}");
            return;
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}