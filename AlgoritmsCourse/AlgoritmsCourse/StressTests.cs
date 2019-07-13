using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    public class StressTests
    {
        public void MaxRevenueTest()
        {
            while (true)
            {
                var rand = new Random();
                int n = 6;// (rand.Next(1, 10));
                Console.WriteLine(n + " # of Elements");

                var arr1 = new int[n,2];
                var arr2 = new int[n,2];

                for (var i = 0; i < n; i++)
                {
                    arr1[i, 0] = rand.Next(-10, 10);
                    arr1[i, 1] = 1;
                    arr2[i, 0] = rand.Next(-10, 10);
                    arr2[i, 1] = 1;
                }

                Console.WriteLine("arr1:");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(arr1[i,0]);
                }

                Console.WriteLine("arr2:");

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(arr2[i,0]);
                }

                var greedy = new GreedyAlgorithms();
                long result = greedy.MaximizeAddRevenue(n, arr1, arr2);
                Console.WriteLine(result);
                Console.ReadLine();

                //long result2 = FastFiboHugeMod(n, m);

                //if (result1 != result2)
                //{
                //    Console.WriteLine("Wrong Answer! " + result1 + "  " + result2);
                //    break;
                //}
                //else
                //{
                //    Console.WriteLine("OK!");
                //}
                //}
            }
        }

        public void BinarySearchTest()
        {
            var divideConquer = new DivideConquer();
            var inputs = Console.ReadLine().Split(' ');
            var inputs2 = Console.ReadLine().Split(' ');

            var sequence = new long[long.Parse(inputs[0])];
            var keys = new long[long.Parse(inputs2[0])];

            var s = sequence.Length;

            for (var i = 0; i < s; i++)
            {
                sequence[i] = long.Parse(inputs[i + 1]);
            }

            var n = keys.Length;

            for (var i = 0; i < n; i++)
            {
                keys[i] = long.Parse(inputs2[i + 1]);
            }

            for (var i = 0; i < n; i++)
            {
                var index = divideConquer.BinarySearchR(sequence, keys[i], 0, s - 1);
                Console.Write(index + " ");
            }
        }

        public void RecursiveChangeTest()
        {
            var money = int.Parse(Console.ReadLine());
            
            var coinsInput = Console.ReadLine().Split(' ');

            var coins = new long[coinsInput.Length];

            for(var i = 0; i < coins.Length; i++)
            {
                coins[i] = long.Parse(coinsInput[i]);
            }

            var dynamicProgramming = new DynamicProgramming();

            Console.WriteLine(dynamicProgramming.RecursiveChange(money, coins));
        }

        public void DiscreteKnapsackTest()
        {
            var W = 10;
            var weights = new long[] { 6, 3, 4, 2 };
            var values = new long[] { 30, 14, 16, 9 };

            var dynamicProgramming = new DynamicProgramming();
            Console.WriteLine(dynamicProgramming.DiscreteKnapsack(W, weights, values));
        }

        public void PrimitiveCalculatorTest()
        {
            var dynamicProgramming = new DynamicProgramming();
            dynamicProgramming.PrimitiveCalculator(96234);
        }

        public void KnapsackDiscreteNoRepeatTest()
        {
            var W = 10;
            var n = 3;
            var weights = new int[] { 1, 4, 8 };

            var dynamicProgramming = new DynamicProgramming();
            Console.WriteLine(dynamicProgramming.DiscreteKnapsackNoRepeats(W, weights, n));            
        }
    }
}
