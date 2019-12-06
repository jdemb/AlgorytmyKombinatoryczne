using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad6
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int n = 7;
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = 1;
            for(int i = 2; i <= n; i++)
                program.findAndPrintNumberFactors(0, i, array);
        }

        public void findAndPrintNumberFactors(int startIndex, int transfer, int[] array)
        {
            if(transfer == 1)
                return;
            int[] newArray = (int[])array.Clone();
            int p = startIndex;
            for (int i = startIndex; i+transfer <= array.Length; i+=transfer)
            {
                int sum = 0;
                int j;
                for(j = i; j < i+transfer; j++)
                {
                    sum += array[j];
                }
                newArray[j-1] = sum;
                for (int k = p; k < j - 1; k++)
                    newArray[k] = 0;
                p = j;
                for (int l = j; l < array.Length; l++)
                    newArray[l] = 1;
                printArray(newArray);
                for(int m = 2; m <= transfer - 1; m++)
                    findAndPrintNumberFactors(j, m, newArray);
            }
        }

        public void printArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if(array[i] != 0)
                    Console.Write(array[i] + " ");
            Console.WriteLine();
        }
    }
}
