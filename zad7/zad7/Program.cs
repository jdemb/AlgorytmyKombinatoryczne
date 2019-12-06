using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad7
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.printAllSubsets(4,2);
        }

        public void printAllSubsets(int n, int k)
        {
            int[] set = new int[k];
            for (int i = 0; i < k; i++)
                set[i] = i + 1;
            printArray(set);
            int index = higherNumberCanBeInserted(set, n);
            while (index != -1)
            {
                set[index]++;
                for (int j = 0; j < index; j++)
                    set[j] = j + 1;
                printArray(set);
                index = higherNumberCanBeInserted(set, n);
            }
        }

        private void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

        private int higherNumberCanBeInserted(int[] array, int n)
        {
            for (int i = 0; i < array.Length; i++)
                if (!array.Contains(array[i] + 1) && (array[i] + 1) <= n)
                    return i;
            return -1;
        }
    }
}
