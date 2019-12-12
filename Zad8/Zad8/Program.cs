using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad8
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int n;
            Int32.TryParse(Console.ReadLine(), out n);
            int m;
            Int32.TryParse(Console.ReadLine(), out m);
            program.printMaxScope(n, m);
        }

        public void printMaxScope(int n, int m)
        {
            Console.WriteLine(handleTreeList(null, n, m));
        }

        private int handleTreeList(List<int> values, int n, int m)
        {
            int maxScopeFromValues = 0;
            int lastIncrementedElement;
            int currentScopeFromValues = 0;
            if (values == null)
            {
                values = new List<int>() { 1 };
            }
            if(values.Count < n && n != 1)
            {
                lastIncrementedElement = values.Last() + 1;
                values.Add(lastIncrementedElement);
                currentScopeFromValues = handleTreeList(new List<int>(values), n, m);
            }
            else
            {
                return maxScopeFromGivenNumbers(values, m);
            }
            while(maxScopeFromValues < currentScopeFromValues)
            {
                maxScopeFromValues = currentScopeFromValues;
                lastIncrementedElement = lastIncrementedElement + 1;
                values.Remove(values.Last());
                values.Add(lastIncrementedElement);
                currentScopeFromValues = handleTreeList(new List<int>(values), n, m);
            }
            return maxScopeFromValues;
        }

        private int maxScopeFromGivenNumbers(List<int> values, int m)
        {
            bool[] numberCanBeBuilt = fillArray(null, new List<int>(values), null, m);
            int scope = 0;
            for(int i = 1; i < numberCanBeBuilt.Length; i++)
            {
                if (numberCanBeBuilt[i])
                    scope++;
                else
                    break;
            }
            return scope;
        }

        private bool[] fillArray(bool[] array, List<int> values, List<int> sumSet, int m)
        {
            if(sumSet == null)
            {
                values.Insert(0, 0);
                sumSet = new List<int>();
                array = new bool[values.Max() * m + 1];
                for (int i = 0; i < values.Count; i++)
                {
                    sumSet.Add(values[i]);
                    fillArray(array, values, new List<int>(sumSet), m);
                    sumSet.Remove(sumSet.Last());
                }
                return array;
            }
            if(sumSet.Count == m)
            {
                int sum = 0;
                for (int i = 0; i < sumSet.Count; i++)
                    sum += sumSet[i];
                array[sum] = true;
                return array;
            }
            else
            {
                for (int i = 0; i < values.Count; i++)
                {
                    sumSet.Add(values[i]);
                    fillArray(array, values, new List<int>(sumSet), m);
                    sumSet.Remove(sumSet.Last());
                }
                return array;
            }
        }
    }
}
