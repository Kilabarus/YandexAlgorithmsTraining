using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L2_19
    {
        static string[][] GetInput()
        {
            int N = int.Parse(Console.ReadLine());
            string[][] cmds = new string[N][];

            for (int i = 0; i < N; i++)
            {
                cmds[i] = Console.ReadLine().Split();
            }

            return cmds;
        }

        static int[] maxHeap;
        static int indexForNewElem;

        static void Insert(int value)
        {
            int newElemIndex = indexForNewElem++;
            int parent = (newElemIndex - 1) / 2;

            maxHeap[newElemIndex] = value;

            while (newElemIndex != 0 && maxHeap[parent] < maxHeap[newElemIndex])
            {
                (maxHeap[parent], maxHeap[newElemIndex]) = (maxHeap[newElemIndex], maxHeap[parent]);
                newElemIndex = parent;
                parent = (newElemIndex - 1) / 2;
            }
        }

        static void MaxHeapify(int i)
        {
            int largest = i;
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;

            if (leftChild < indexForNewElem && maxHeap[leftChild] > maxHeap[largest])
            {
                largest = leftChild;
            }

            if (rightChild < indexForNewElem && maxHeap[rightChild] > maxHeap[largest])
            {
                largest = rightChild;
            }

            if (largest != i)
            {
                (maxHeap[largest], maxHeap[i]) = (maxHeap[i], maxHeap[largest]);
                MaxHeapify(largest);
            }
        }

        static int Extract()
        {
            int result = maxHeap[0];

            maxHeap[0] = maxHeap[--indexForNewElem];
            MaxHeapify(0);

            return result;
        }

        static string GetAnswer(int numOfInserts, (int Cmd, int Arg)[] cmds)
        {
            maxHeap = new int[numOfInserts];

            StringBuilder sB = new();

            foreach (var cmd in cmds)
            {
                if (cmd.Cmd == 0)
                {
                    Insert(cmd.Arg);
                    continue;
                }

                sB.AppendLine(Extract().ToString());
            }

            return sB.ToString();
        }

        static void Solution()
        {
            string[][] input = GetInput();

            (int Cmd, int Arg)[] cmds = new (int Cmd, int Arg)[input.Length];

            int inserts = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i][0] == "0")
                {
                    cmds[i] = (0, int.Parse(input[i][1]));
                    ++inserts;

                    continue;
                }
                cmds[i] = (1, -1);
            }

            Console.WriteLine(GetAnswer(inserts, cmds));
        }
    }
}
