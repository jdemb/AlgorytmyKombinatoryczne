using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorytm9
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            List<int> sequenceOfNumbers = new List<int>() { 1, 2, 3};
            program.createPermutations(sequenceOfNumbers);
        }

        private void createPermutations(List<int> sequenceOfNumbers)
        {
            Queue<List<int>> queue = initilizeQueue(sequenceOfNumbers);
            for(int i = sequenceOfNumbers.Count - 3; i >= 0; i--)
            {
                int currentValue = sequenceOfNumbers[i];
                int iterations = queue.Count;
                for(int j = 0; j < iterations; j++)
                {
                    List<int> currentList = queue.Dequeue();
                    queue = insertNumber(currentList, currentValue, queue);
                }
                if(i == 0)
                    printValues(queue);
            }
        }

        private Queue<List<int>> insertNumber(List<int> currentList, int number, Queue<List<int>> originalQueue)
        {
            Queue<List<int>> queue = originalQueue;
            for (int i = 0; i < currentList.Count + 1; i++)
            {
                List<int> permutation = new List<int>(currentList);
                permutation.Insert(i, number);
                queue.Enqueue(permutation);
            }
            return queue;
        }

        private Queue<List<int>> initilizeQueue(List<int> sequenceOfNumbers)
        {
            Queue<List<int>> queue = new Queue<List<int>>();
            int n = sequenceOfNumbers.Count;
            queue.Enqueue(new List<int>() { sequenceOfNumbers[n - 2], sequenceOfNumbers[n - 1] });
            queue.Enqueue(new List<int>() { sequenceOfNumbers[n - 1], sequenceOfNumbers[n - 2] });
            return queue;
        }

        private void printValues(Queue<List<int>> queue)
        {
            List<int>[] collection = queue.ToArray();
            for(int j = 0; j < collection.Length; j++)
            {
                for (int i = 0; i < collection[j].Count; i++)
                {
                    Console.Write("{0}, ", collection[j][i]);
                }
                Console.WriteLine();
            }
        }
    }
}
