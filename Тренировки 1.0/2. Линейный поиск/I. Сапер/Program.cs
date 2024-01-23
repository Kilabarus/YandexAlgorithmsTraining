using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// https://contest.yandex.ru/contest/27472/problems/I/

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
            };

            #region Entries
            int numOfEntries = Convert.ToInt32(input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
            for (int i = 0; i < numOfEntries; i++)
            {
                input.Add(Console.ReadLine());
            }
            #endregion

            return input;
        }

        static void Solve(List<string> input)
        {
            void IncreaseBombCounter(List<List<char>> field, int row, int column)
            {
                if (row < 0 || column < 0 || row >= field.Count || column >= field[0].Count || field[row][column] == '*')
                {
                    return;
                }                

                field[row][column] = (char)(field[row][column] + 1);
            }

            List<int> NMK = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            (int N, int M, int K) = (NMK[0], NMK[1], NMK[2]);

            List<List<char>> field = new List<List<char>>();

            for (int i = 0; i < N; i++)
            {
                field.Add(new List<char>());

                for (int j = 0; j < M; j++)
                {
                    field[i].Add('0');
                }
            }

            for (int i = 1; i < input.Count; i++)
            {
                List<int> coords = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToList();

                (int row, int column) = (coords[0] - 1, coords[1] - 1);

                field[row][column] = '*';

                IncreaseBombCounter(field, row + 1, column);
                IncreaseBombCounter(field, row - 1, column);
                IncreaseBombCounter(field, row,     column + 1);
                IncreaseBombCounter(field, row,     column - 1);
                IncreaseBombCounter(field, row + 1, column + 1);
                IncreaseBombCounter(field, row - 1, column - 1);
                IncreaseBombCounter(field, row + 1, column - 1);
                IncreaseBombCounter(field, row - 1, column + 1);
            }

            foreach (var row in field)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        static void Main(string[] args)
        {
            Solve(GetInput());
        }
    }
}