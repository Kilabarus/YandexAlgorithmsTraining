using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L2_17
    {
        static (string[] A, string[] B) GetInput()
        {
            return (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries), Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }

        static string GetAnswer((int[] A, int[] B) cards)
        {
            Queue<int> playerA = new(cards.A);
            Queue<int> playerB = new(cards.B);
            Queue<int> winner;

            int turns = 0;

            int cardA, cardB;

            while (playerA.Count > 0 && playerB.Count > 0 && turns < 1_000_000)
            {
                cardA = playerA.Dequeue();
                cardB = playerB.Dequeue();

                if (cardA == 0 && cardB == 9)
                {
                    winner = playerA;
                }
                else if (cardB == 0 && cardA == 9)
                {
                    winner = playerB;
                }
                else
                {
                    winner = cardA > cardB ? playerA : playerB;
                }

                winner.Enqueue(cardA);
                winner.Enqueue(cardB);

                ++turns;
            }

            if (turns == 1_000_000)
            {
                return "botva";
            }

            if (playerA.Count > 0)
            {
                return $"first {turns}";
            }

            return $"second {turns}";
        }

        static void Solution()
        {
            (string[] A, string[] B) input = GetInput();
            (int[] A, int[] B) cards = (Array.ConvertAll(input.A, int.Parse), Array.ConvertAll(input.B, int.Parse));

            Console.WriteLine(GetAnswer(cards));
        }
    }
}
