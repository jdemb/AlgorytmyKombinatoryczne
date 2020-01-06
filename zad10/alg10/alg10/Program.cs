using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg10
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = 0;
            Int32.TryParse(Console.ReadLine(), out range);
            List<int> set = new List<int>();
            Program program = new Program();
            set = program.initSieves(set, range);
            program.printSet(set);
        }

        public void printSet(List<int> set)
        {
            foreach(int number in set)
            {
                Console.Write(number.ToString() + " ");
            }
        }

        public List<int> initSieves (List<int> set, int range)
        {
            for (int i = 0; i < range + 1; i++)
                set.Add(i);
            for (int i = 3; i < set.Count; i++)
            {
                if (sieve1(set, i))
                    set.RemoveAt(i--);
                else if(sieve2(set, i))
                    set.RemoveAt(i--);
            }
            return set;
        }

        public bool sieve1 (List<int> set, int index)
        {
            List<int> setFraction = set.GetRange(1, index - 1);
            bool result = hasSetTwoCandidates(setFraction, set[index]).result;
            return !result;
        }

        public bool sieve2 (List<int> set, int index)
        {
            List<int> setFraction = set.GetRange(1, index - 1);
            Result firstResult = hasSetTwoCandidates(setFraction, set[index]);
            if (firstResult.result)
            {
                int number1 = setFraction[firstResult.leftIndex];
                int number2 = setFraction[firstResult.rightIndex];
                setFraction.Remove(number1);
                setFraction.Remove(number2);
            }
            else
                return true;
            Result secondResult = hasSetTwoCandidates(setFraction, set[index]);
            return secondResult.result;
        }

        static Result hasSetTwoCandidates(List<int> setFraction, int sum)
        {
            int l, r;

            l = 0;
            r = setFraction.Count - 1;
            while (l < r)
            {
                if (setFraction[l] + setFraction[r] == sum)
                    return new Result() { result = true, leftIndex = l, rightIndex = r };
                else if (setFraction[l] + setFraction[r] < sum)
                    l++;
                else 
                    r--;
            }
            return new Result() { result = false, leftIndex = -1, rightIndex = -1 }; ;
        }
    }

    public class Result
    {
        public bool result;
        public int leftIndex;
        public int rightIndex;
    }

}
