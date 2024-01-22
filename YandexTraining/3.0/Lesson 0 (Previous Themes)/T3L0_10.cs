using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_10
    {
        static string GetInput()
        {
            return Console.ReadLine();
        }

        static string GetAnswer(string str)
        {
            Dictionary<char, BigInteger> d = new();

            for (int i = 0; i < str.Length; i++)
            {
                if (!d.ContainsKey(str[i]))
                {
                    d.Add(str[i], (i + 1) * ((BigInteger)(str.Length - i)));
                    continue;
                }

                d[str[i]] += (i + 1) * ((BigInteger)(str.Length - i));
            }

            StringBuilder sB = new();

            foreach (var ch in d.ToImmutableSortedDictionary())
            {
                sB.Append($"{ch.Key}: {ch.Value}\n");
            }

            return sB.ToString();
        }

        static void Solution()
        {
            string input = GetInput();

            Console.WriteLine(GetAnswer(input));
        }
    }
}
