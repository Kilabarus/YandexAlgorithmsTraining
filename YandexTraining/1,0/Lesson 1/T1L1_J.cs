using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._1_0.Lesson_1
{
    internal class T1L1_J
    {
        static string[] GetInput()
        {
            return new string[6] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
        }

        // ax + by = c
        static string SolveEquation(double a, double b, double c)
        {
            if (a == 0 && b == 0)
            {
                if (c == 0)
                {
                    return "5";
                }

                return "0";
            }

            if (a == 0)
            {
                double y = c / b;
                return $"4 {y}";
            }

            if (b == 0)
            {
                double x = c / a;
                return $"3 {x}";
            }

            double B = c / b;
            double K = -a / b;

            return $"1 {K} {B}";
        }

        static string GetAnswer(double a, double b, double c, double d, double e, double f)
        {
            if (a == 0 && b == 0)
            {
                if (e != 0)
                {
                    return "0";
                }

                return SolveEquation(c, d, f);
            }

            if (c == 0 && d == 0)
            {
                if (f != 0)
                {
                    return "0";
                }

                return SolveEquation(a, b, e);
            }

            if (a == 0 && c == 0)
            {
                if (e / b == f / d)
                {
                    return $"4 {e / b}";
                }

                return "0";
            }

            if (b == 0 && d == 0)
            {
                if (e / a == f / c)
                {
                    return $"3 {e / a}";
                }

                return "0";
            }

            if (a == 0 && d == 0)
            {
                return $"2 {f / c} {e / b}";
            }

            if (b == 0 && c == 0)
            {
                return $"2 {e / a} {f / d}";
            }

            double y;
            double x;

            if (a == 0)
            {
                y = e / b;
                x = (f - d * y) / c;

                return $"2 {x} {y}";
            }

            if (b == 0)
            {
                x = e / a;
                y = (f - c * x) / d;

                return $"2 {x} {y}";
            }

            if (c == 0)
            {
                y = f / d;
                x = (e - b * y) / a;

                return $"2 {x} {y}";
            }

            if (d == 0)
            {
                x = f / c;
                y = (e - a * x) / b;

                return $"2 {x} {y}";
            }

            if (a * d - c * b == 0)
            {
                if (f * a - c * e == 0)
                {
                    double K = -a / b;
                    double B = e / b;

                    return $"1 {K} {B}";
                }

                return "0";
            }

            y = (f * a - c * e) / (a * d - c * b);
            x = (e - b * y) / a;

            return $"2 {x} {y}";
        }

        static void Solution()
        {
            string[] input = GetInput();

            double a = double.Parse(input[0]);
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);
            double d = double.Parse(input[3]);
            double e = double.Parse(input[4]);
            double f = double.Parse(input[5]);

            Console.WriteLine(GetAnswer(a, b, c, d, e, f));
        }
    }
}
