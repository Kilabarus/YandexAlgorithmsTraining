using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTraining._3._0.Lesson_3
{
    internal class T3L2_20
    {
        static string[] GetInput()
        {
            Console.ReadLine();
            return Console.ReadLine().Split(" ");
        }

        static int[] minHeap;
        static int heapSize;

        static void MinHeapify(int i)
        {
            int smallest = i;
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;

            if (leftChild < heapSize && minHeap[leftChild] < minHeap[smallest])
            {
                smallest = leftChild;
            }

            if (rightChild < heapSize && minHeap[rightChild] < minHeap[smallest])
            {
                smallest = rightChild;
            }

            if (smallest != i)
            {
                (minHeap[smallest], minHeap[i]) = (minHeap[i], minHeap[smallest]);
                MinHeapify(smallest);
            }
        }

        static int Extract()
        {
            int result = minHeap[0];

            minHeap[0] = minHeap[heapSize - 1];
            --heapSize;
            MinHeapify(0);

            return result;
        }

        static string GetAnswer(int[] arr)
        {
            minHeap = arr;
            heapSize = minHeap.Length;

            for (int i = (minHeap.Length - 1) / 2; i >= 0; i--)
            {
                MinHeapify(i);
            }

            StringBuilder sB = new();

            foreach (int i in arr)
            {
                sB.Append($"{Extract()} ");
            }

            return sB.ToString();
        }

        static void Solution()
        {
            string[] input = GetInput();

            Console.WriteLine(GetAnswer(Array.ConvertAll(input, int.Parse)));
        }
    }
}
