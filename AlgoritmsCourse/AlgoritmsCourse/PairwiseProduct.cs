using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    public static class PairwiseProduct
    {
        public static int[] FastMaxPairwiseIndexes(int[] numbers)
        {
            int n = numbers.Length;
            int indexOfMax1 = -1;
            int indexOfMax2 = -1;

            for (int i = 0; i < n; i++)
            {
                if (indexOfMax1 == -1 || numbers[i] > numbers[indexOfMax1])
                {
                    indexOfMax1 = i;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (j != indexOfMax1 && ((indexOfMax2 == -1) || (numbers[j] > numbers[indexOfMax2])))
                {
                    indexOfMax2 = j;
                }
            }

            var result = ((long)numbers[indexOfMax1] * (long)numbers[indexOfMax2]);

            //Console.WriteLine("Fast Indexes:" + indexOfMax1 + "  " + indexOfMax2);
            //Console.WriteLine("Fast Values:" + numbers[indexOfMax1] + "  " + numbers[indexOfMax2]);
            //Console.WriteLine("Fast Product:" + ((long)numbers[indexOfMax1] * (long)numbers[indexOfMax2]));

            return new int[] { indexOfMax1, indexOfMax2 };
        }

        public static long FastMaxPairwiseProduct(int[] numbers)
        {
            int n = numbers.Length;
            int indexOfMax1 = -1;
            int indexOfMax2 = -1;

            for (int i = 0; i < n; i++)
            {
                if (indexOfMax1 == -1 || numbers[i] > numbers[indexOfMax1])
                {
                    indexOfMax1 = i;
                }
            }

            for (int j = 0; j < n; j++)
            {
                if (j != indexOfMax1 && ((indexOfMax2 == -1) || (numbers[j] > numbers[indexOfMax2])))
                {
                    indexOfMax2 = j;
                }
            }

            var result = ((long)numbers[indexOfMax1] * (long)numbers[indexOfMax2]);

            //Console.WriteLine("Fast Indexes:" + indexOfMax1 + "  " + indexOfMax2);
            //Console.WriteLine("Fast Values:" + numbers[indexOfMax1] + "  " + numbers[indexOfMax2]);
            //Console.WriteLine("Fast Product:" + ((long)numbers[indexOfMax1] * (long)numbers[indexOfMax2]));

            return result;
        }

        public static long MaxPairwiseProduct(int[] numbers)
        {
            long results = 0;
            int n = numbers.Length;
            int i, j, y = 0, z = 0;

            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    var res = ((long)numbers[i] * (long)numbers[j]);
                    if (res > results)
                    {
                        results = res;// (numbers[i] * numbers[j]);
                        y = i;
                        z = j;
                    }
                }
            }

            Console.WriteLine("Reg Indexes:" + y + "  " + z);
            Console.WriteLine("Reg Values:" + numbers[y] + "  " + numbers[z]);
            Console.WriteLine("Reg Product:" + results);

            return results;
        }
    }
}
