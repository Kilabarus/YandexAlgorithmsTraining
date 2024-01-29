using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;


namespace YandexTraining
{
    internal class Program
    {
        static List<string> GetInput()
        {
            const string INPUT_FILE = "input.txt";

            if (File.Exists(INPUT_FILE))
            {
                return File.ReadAllLines(INPUT_FILE).ToList();
            }

            List<string> input = new();
            do
            {
                input.Add(Console.ReadLine());
            } while (input[^1] != "");

            return input;
        }

        static void WriteOutput(string output)
        {
            const string OUTPUT_FILE = "output.txt";

            File.WriteAllText(OUTPUT_FILE, output);
        }

        // Кромешный ад
        static string Solve(List<string> input)
        {
            List<int> ConvertStringToListOfInt32(string strWithInts)
            {
                return strWithInts.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToList();
            }

            StringBuilder output = new StringBuilder();

            var NK = ConvertStringToListOfInt32(input[0]);
            BigInteger K = NK[1];

            var numOfCards = new SortedDictionary<int, int>();
            foreach (var card in ConvertStringToListOfInt32(input[1]))
            {
                if (!numOfCards.ContainsKey(card))
                {
                    numOfCards.Add(card, 0);
                }

                ++numOfCards[card];
            }

            var cardValues = numOfCards.Keys.ToList();
            cardValues.Sort();

            Dictionary<int, int> postfixSum = new();
            int postfix = 0;
            var t = numOfCards.Keys.ToList();
            t.Sort();
            t.Reverse();
            foreach (var card in t)
            {
                postfixSum.Add(card, postfix);
                if (numOfCards[card] > 1)
                {
                    ++postfix;
                }
            }

            BigInteger numOfCombos = 0;
                        
            int leftCardIndex = 0;
            int rightCardIndex = 0;                                              

            int numOfCardsInTotal = numOfCards.Keys.Count;            
            while (true)
            {                
                while (rightCardIndex < numOfCardsInTotal 
                    && cardValues[rightCardIndex] <= K * cardValues[leftCardIndex])
                {
                    ++rightCardIndex;                                        
                }
                
                while (leftCardIndex < rightCardIndex 
                    && (rightCardIndex == numOfCardsInTotal || cardValues[rightCardIndex] > K * cardValues[leftCardIndex]))
                {
                    int numOfCurrCards = rightCardIndex - leftCardIndex;

                    // Комбо вида X Y Z, X Z Y, Y X Z, Y Z X, Z X Y, Z Y X
                    if (numOfCurrCards >= 3)
                    {                        
                        numOfCombos += 3 * (BigInteger)(numOfCurrCards - 1) * (BigInteger)(numOfCurrCards - 2);
                    }

                    int numOfLeftValueCards = numOfCards[cardValues[leftCardIndex]];
                    
                    // Комбо вида X X X
                    if (numOfLeftValueCards >= 3)
                    {
                        numOfCombos += 1;
                    }

                    // Комбо вида X X Y, X Y X, Y X X
                    if (numOfLeftValueCards >= 2)
                    {
                        numOfCombos += 3 * (numOfCurrCards - 1);
                    }

                    // Комбо вида X Y Y, Y Y X, Y X Y
                    if (numOfLeftValueCards >= 1)
                    {
                        if (rightCardIndex == numOfCardsInTotal)
                        {                            
                            numOfCombos += 3 * (BigInteger)postfixSum[cardValues[leftCardIndex]];
                        }
                        else
                        {                            
                            numOfCombos += 3 * (BigInteger)(postfixSum[cardValues[leftCardIndex]] - postfixSum[cardValues[rightCardIndex - 1]]);
                        }
                    }

                    ++leftCardIndex;
                }

                if (leftCardIndex == rightCardIndex && rightCardIndex == numOfCardsInTotal)
                {
                    break;
                }
            }

            return numOfCombos.ToString();
        }

        static void Main(string[] args)
        {
            var input = GetInput();
            string output = Solve(input);            

            WriteOutput(output);
            
            Console.WriteLine(output);            
        }
    }
}