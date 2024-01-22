using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_1
{
    internal class T3L0_01
    {
        static string GetInput()
        {
            return Regex.Replace(File.ReadAllText("input.txt").ReplaceLineEndings(""), @"\s+", "");
        }

        static string GetAnswer(string text)
        {
            SortedDictionary<char, int> chrCnt = new SortedDictionary<char, int>();
            int maxCnt = 1;

            foreach (char c in text)
            {
                if (chrCnt.ContainsKey(c))
                {
                    if (++chrCnt[c] > maxCnt)
                    {
                        maxCnt = chrCnt[c];
                    }

                    continue;
                }

                chrCnt.Add(c, 1);
            }

            StringBuilder sB = new StringBuilder();

            while (maxCnt > 0)
            {
                foreach (var c in chrCnt.Keys)
                {
                    if (chrCnt[c] >= maxCnt)
                    {
                        sB.Append('#');
                        continue;
                    }

                    sB.Append(' ');
                }

                --maxCnt;
                sB.Append(Environment.NewLine);
            }

            foreach (var c in chrCnt.Keys)
            {
                sB.Append(c);
            }

            return sB.ToString();
        }

        static void Solution()
        {
            Console.WriteLine(GetAnswer(GetInput()));
        }
    }
}
