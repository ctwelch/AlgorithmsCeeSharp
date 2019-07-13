using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgoritmsCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            #region stuff
            // For reading in a range of space delimited integer inputs
            //int n = int.Parse(Console.ReadLine());
            //int[] numbers = new int[n];
            //var input = Console.ReadLine().Split(' ');

            //for (int i = 0; i < n; i++)
            //{                
            //    numbers[i] = int.Parse(input[i]);
            //}

            // For reading in a single integer value
            //int n = int.Parse(Console.ReadLine());

            // first line of input contains the number n of items and the capacity
            // then each subsequent line has the value then the weight separated by a space
            //var lineInput = Console.ReadLine().Split(' ');

            //var n = int.Parse(Console.ReadLine());
            ////var capacity = int.Parse(lineInput[1]);

            //// with tuples
            ////Tuple<int, int, double> weightsValuesPerWeight;
            ////var items = new Tuple<int, int, double>[n];

            //// with multidimensional arrays  - n rows and 2 columns  -- can't mix double with int of course
            ////double [,] mdItems = new double[n,2];

            //////////////////////////////////////////////////////////////////////////////////////////////
            //var n = int.Parse(Console.ReadLine());
            //// with 2 arrays
            //var arr1 = new int[n,2];
            //var arr2 = new int[n,2];

            //var lineInput1 = Console.ReadLine().Split(' ');
            //var lineInput2 = Console.ReadLine().Split(' ');

            //for (var i = 0; i < n; i++)
            //{
            //    // with 2 arrays
            //    arr1[i,0] = int.Parse(lineInput1[i]);
            //    arr1[i, 1] = 1;
            //    arr2[i,0] = int.Parse(lineInput2[i]);
            //    arr2[i, 1] = 1;
            //    //var lineInput = Console.ReadLine().Split(' ');
            //    //var value = double.Parse(lineInput[0]);
            //    //var weight = double.Parse(lineInput[1]);


            //    // with Tuples
            //    //weightsValuesPerWeight = new Tuple<int, int, double>(value, weight, ((double)value / (double)weight));
            //    //items[i] = weightsValuesPerWeight;

            //    // with multidemensional arrays
            //    //mdItems[i, 0] = value;
            //    //mdItems[i, 1] = weight;
            //}

            //Console.WriteLine(MaximizeAddRevenue(n, arr1, arr2));
            //////////////////////////////////////////////////////////////////////////////////////////////

            //var greedies = new GreedyAlgorithms();

            // Tuples


            // multidimensional arrays
            //Console.WriteLine(Knapsack(n, capacity, mdItems));

            //var n = int.Parse(Console.ReadLine().Split(' '));
            //int[] numbers = new int[n];

            //var input = Console.ReadLine().Split(' ');

            //for (int i = 0; i < n; i++)
            //{
            //    numbers[i] = int.Parse(input[i]);
            //}

            //int n = int.Parse(Console.ReadLine());
            //var greedies = new GreedyAlgorithms();
            //Console.WriteLine(MoneyChangeFast(n));

            //var stressTest = new StressTests();
            //stressTest.MaxRevenueTest();

            //var inputs = Console.ReadLine().Split(' ');
            //var inputs2 = Console.ReadLine().Split(' ');

            //var sequence = new long[long.Parse(inputs[0])];
            //var keys = new long[long.Parse(inputs2[0])];

            //var s = sequence.Length;

            //for (var i = 0; i < s; i++)
            //{
            //    sequence[i] = long.Parse(inputs[i + 1]);
            //}

            //var n = keys.Length;

            //for(var i = 0; i < n; i++)
            //{
            //    keys[i] = long.Parse(inputs2[i + 1]);
            //}

            //for(var i = 0; i < n; i++)
            //{
            //    var index = BinarySearchR(sequence, keys[i], 0, s-1);
            //    Console.Write(index + " ");
            //}     
            #endregion

            //int n = int.Parse(Console.ReadLine());

            //if (n <= 1)
            //{
            //    Console.Write(0);
            //}
            //else
            //{
            //    var result = PrimitiveCalculator(n);
            //    for (var i = 0; i < result.Count(); i++)
            //    {
            //        if(i == 0)
            //        {
            //            Console.WriteLine(result[i]);
            //            continue;
            //        }

            //        Console.Write(result[i] + " ");
            //    }

            //}

            var lineInput = Console.ReadLine().Split(' ');
            var W = int.Parse(lineInput[0]);
            var n = int.Parse(lineInput[1]);

            var weights = new int[n];

            lineInput = Console.ReadLine().Split(' ');

            for (var i = 0; i < n; i++)
            {
                weights[i] = int.Parse(lineInput[i]);
            }

            Console.WriteLine(DiscreteKnapsackNoRepeats(W, weights, n));

            //var result = ContainsMajorityElement(sequence, n) > 0 ? 1 : 0;
            //Console.WriteLine(result);

            //var stressTest = new StressTests();
            //stressTest.RecursiveChangeTest();
            //stressTest.DiscreteKnapsackTest();
            //stressTest.PrimitiveCalculatorTest();
            //stressTest.KnapsackDiscreteNoRepeatTest();



            //Console.ReadLine();

        }

        public static long DiscreteKnapsackNoRepeats(int W, int[] weights, int n)
        {
            if (W == 0) return 0;                    

            var optimalValues = new int[W + 1, n + 1];

            // for each possible weight, of each item
            for (var i = 1; i <= n; i++)
            {
                for (var w = 1; w <= W; w++)
                {
                    //if (weights[i - 1] <= w)
                    //{
                    //    optimalValues[w, i] = Math.Max(
                    //        optimalValues[w, i - 1],
                    //        optimalValues[w - weights[i - 1], i - 1] + weights[i - 1]);
                    //}
                    //else
                    //{
                    //    optimalValues[w, i] = optimalValues[w, i - 1];
                    //}

                    optimalValues[w, i] = optimalValues[w, i - 1];

                    if (weights[i - 1] <= w)
                    {
                        var value = optimalValues[w - weights[i - 1], i - 1] + weights[i - 1];

                        if (optimalValues[w, i] < value)
                            optimalValues[w, i] = value;
                    }
                }
            }

            return optimalValues[W, n];
        }

        public static List<int> PrimitiveCalculator(int n)
        {
            var sequence = new List<int>();

            int[] arr = new int[n + 1];

            for (int i = 1; i < arr.Length; i++)
            {
                // arr at i is one more than the one before
                arr[i] = arr[i - 1] + 1;
                // if i is divisible by 2, 
                // we need to see 
                if (i % 2 == 0) arr[i] = Math.Min(1 + arr[i / 2], arr[i]);

                if (i % 3 == 0) arr[i] = Math.Min(1 + arr[i / 3], arr[i]);
            }

            var j = 0;

            for (int i = n; i > 1;)
            {
                sequence.Add(i);
                if (arr[i - 1] == arr[i] - 1)
                    i = i - 1;
                else if (i % 2 == 0 && (arr[i / 2] == arr[i] - 1))
                    i = i / 2;
                else if (i % 3 == 0 && (arr[i / 3] == arr[i] - 1))
                    i = i / 3;
                j++;
            }
            sequence.Add(1);
            sequence.Add(j);

            sequence.Reverse();
            return sequence;
        }

        public static long ContainsMajorityElement(long[] sequence, int n)
        {
            if (n == 1) return sequence[0];

            // a majority elment appears more than n/2 times
            var majority = n / 2;
            
            // If a sequence of length n contains a majority element,
            // then the same element is also a majority element for one of its halves

            // Split the array A into two arrays B and C 
            // If A has a majority element v, v must also be a majority element
            // of B or C or both 
            // ContraPositive: if v <= half in each, v <= half in the total

            // If one of the parts has a majority element, count the number of 
            // repititions of that element in both parts to see if it is a majority element
            // If both parts have a mojority, then you may need to do this count for each candidate
            // these scans are done in O(n) time
            
            var firstHalfSize = n / 2;
            var secondHalfSize = n - firstHalfSize;

            var firstHalf = new long[firstHalfSize];
            var secondHalf = new long[secondHalfSize];            

            for (var i = 0; i < n; i++)
            {
                if (i < firstHalfSize)
                {
                    firstHalf[i] = sequence[i];
                }
                else
                {
                    secondHalf[i - firstHalfSize] = sequence[i];
                }
            }

            var leftMajority = ContainsMajorityElement(firstHalf, firstHalfSize);
            var rightMajority = ContainsMajorityElement(secondHalf, secondHalfSize);

            if(leftMajority == rightMajority)
            {
                return leftMajority;
            }

            var leftCount = 0;
            for(var i = 0; i < n; i++) // check frequency of leftMajority
            {
                if(sequence[i] == leftMajority)
                {
                    leftCount++;
                }
            }

            var rightCount = 0;
            for(var i = 0; i < n; i++)
            {
                if(sequence[i] == rightMajority)
                {
                    rightCount++;
                }
            }

            if(leftCount > majority)
            {
                return leftMajority;
            }

            if(rightCount > majority)
            {
                return rightMajority;
            }

            return 0; 
        }

        public static long BinarySearchR(long[] sequence, long key, long min, long max)
        {
            if (min > max)
            {
                return - 1;
            }

            //long mid = (long)Math.Floor((decimal)min + ((decimal)(max - min) / (decimal)2)); // not min+max / 2 (?)
            long mid = (min + max) / 2;

            if (key == sequence[mid])
            {
                return mid;
            }
            // now half the elements are ruled out
            else if (key < sequence[mid])
            {
                // consider only the first half of the input when key is below mid
                return BinarySearchR(sequence, key, min, mid - 1);
            }
            else
            {
                // or else it must be in the second half above mid
                return BinarySearchR(sequence, key, mid + 1, max);
            }
        }

        public static long MaximizeAddRevenue(int n, int[,] profitPerClick, int[,] clicksPerDay)
        {
            //if(n == 1)
            //{
            //    return profitPerClick[0] * clicksPerDay[0] > 0 ? profitPerClick[0] * clicksPerDay[0] : 0;
            //}

            long value = 0;
            long maxValue = 0;


            for (var i = 0; i < n; i++)  // for each n
            {
                var maxProfitIndex = -1;
                var maxProfitValue = -1;
                var maxClicksIndex = -1;
                var maxClicksValue = -1;
                //index of max 1                
                //var maxPosProfitValue = 0;
                var maxNegProfitValue = 0;
                //var maxPosProfitIndex = 0;
                var maxNegProfitIndex = 0;
                //var minNegProfitIndex = 0;
                //var minNegProfitValue = 0;

                for (var p = 0; p < n; p++)
                {
                    if (profitPerClick[p, 1] != 0) // element is not exhausted
                    {
                        if (profitPerClick[p, 0] >= maxProfitValue
                            || (maxProfitValue == -1 /*&& profitPerClick[p, 0] < 0*/))
                        {
                            maxProfitIndex = p;
                            maxProfitValue = profitPerClick[p, 0];
                        }

                        if (profitPerClick[p,0] < 0 && profitPerClick[p,0] < maxNegProfitValue)
                        {
                            maxNegProfitIndex = p;
                            maxNegProfitValue = profitPerClick[maxNegProfitIndex,0];
                        }
                    }

                    #region madness
                    //if (profitPerClick[p] > 0 && profitPerClick[p] > maxPosProfitValue)
                    //{
                    //    maxPosProfitIndex = p;
                    //    maxPosProfitValue = profitPerClick[maxPosProfitIndex];
                    //}
                    //if (profitPerClick[p] < 0 && profitPerClick[p] > minNegProfitValue)
                    //{

                    //}

                    //if (profitPerClick[p] < 0 && profitPerClick[p] < maxNegProfitValue)
                    //{
                    //    maxNegProfitIndex = p;
                    //    maxNegProfitValue = profitPerClick[maxNegProfitIndex];
                    //}
                    //// keep track of smallest negative profit in case profit is negative and clicks are positive
                    //if (profitPerClick[p] < 0 && profitPerClick[p] >= maxNegProfitValue
                    //    && (minNegProfitValue == 0 || profitPerClick[p] > minNegProfitValue)) // smallest negative would be greater than another, more negative value
                    //{
                    //    minNegProfitIndex = p;
                    //    minNegProfitValue = profitPerClick[minNegProfitIndex];
                    //}
                    #endregion
                }
                //var maxProfit = maxPosProfitValue > 0 ? maxPosProfitValue : maxNegProfitValue;
                //maxProfitIndex = maxPosProfitValue > 0 ? maxPosProfitIndex : maxNegProfitIndex;

                //var maxPosClickValue = 0;
                var maxNegClickValue = 0;
                //var maxPosClickIndex = 0;
                var maxNegClickIndex = 0;
                //var minNegClicksIndex = 0;
                //var minNegClicksValue = 0;

                // index of max 2                 
                for (var c = 0; c < n; c++)
                {
                    if (clicksPerDay[c, 1] != 0)
                    {
                        if (clicksPerDay[c, 0] >= maxClicksValue
                            || (maxClicksValue == -1 /*&& clicksPerDay[c, 0] < 0*/)) // this will replace my 0 with a negative value fucking me over
                        {
                            maxClicksIndex = c;
                            maxClicksValue = clicksPerDay[c, 0];
                        }

                        if(clicksPerDay[c,0] < 0 && clicksPerDay[c,0] < maxNegClickValue)
                        {
                            maxNegClickIndex = c;
                            maxNegClickValue = clicksPerDay[c, 0];
                        }
                    }
                    #region madness2
                    //if (clicksPerDay[c] > 0 && clicksPerDay[c] > maxPosClickValue)
                    //{
                    //    maxPosClickIndex = c;
                    //    maxPosClickValue = clicksPerDay[maxPosClickIndex];
                    //}

                    //if (clicksPerDay[c] < 0 && clicksPerDay[c] < maxNegClickValue)
                    //{
                    //    maxNegClickIndex = c;
                    //    maxNegClickValue = clicksPerDay[maxNegClickIndex];
                    //}
                    //// keep track of smallest negative clicks in case profit is positive and clicks are negative
                    //if (clicksPerDay[c] < 0 && clicksPerDay[c] >= maxNegClickValue // maxNeg could be the only neg
                    //    && (minNegClicksValue == 0 || clicksPerDay[c] > minNegClicksValue))
                    //{
                    //    minNegClicksIndex = c;
                    //    minNegClicksValue = clicksPerDay[minNegClicksIndex];
                    //}
                    #endregion
                }

                //var maxClicks = maxPosClickValue > 0 ? maxPosClickValue : maxNegClickValue;
                //maxClicksIndex = maxPosClickValue > 0 ? maxPosClickIndex : maxNegClickIndex;

                //// if we are out of positive profts but maxClicks still has some positive values
                //if (maxProfit < 0 && maxClicks > 0 && minNegClicksValue != 0)
                //{
                //    // here, if there are more than one negative value to offer, 
                //    // we should exhaust the smaller ones first. 
                //    // because this result will yield 0 value in the end
                //    maxProfit = minNegProfitValue;  // waste the smallest negative value if all we have are negative profits
                //    maxProfitIndex = minNegProfitIndex; // need the minNegProftIndex
                //}
                //if (maxProfit > 0 && maxClicks < 0 && minNegProfitValue != 0)
                //{
                //    // we need to look for the smallest value of negative # of clicks
                //    maxClicks = minNegClicksValue;
                //    maxClicksIndex = minNegClicksIndex;
                //}              

                // if both profit and clicks are negative 
                // we need the biggest absolute value negative number
                if(maxProfitValue < 0 && maxClicksValue < 0)
                {
                    maxValue = maxNegProfitValue * maxNegClickValue;
                    Console.WriteLine(maxNegProfitValue + " * " + maxNegClickValue + " = " + maxValue);
                }
                else
                {
                    maxValue = maxProfitValue * maxClicksValue;
                    Console.WriteLine(maxProfitValue + " * " + maxClicksValue + " = " + maxValue);
                }

                // sum the value
                //maxValue = maxProfitValue * maxClicksValue;//((long)profitPerClick[maxProfitIndex] * (long)clicksPerDay[maxClicksIndex]);
                value += maxValue > 0 ? maxValue : 0;
                
                Console.WriteLine(value);
                // reduce values of maxIndexes to 0 so they aren't counted again
                profitPerClick[maxProfitIndex, 1] = 0;
                clicksPerDay[maxClicksIndex, 1] = 0;
            }

            return value;
        }

        public static double Knapsack(int n, int capacity, double[,] items)
        {
            var usedCapacity = 0.0;
            var value = 0.0;

            if (capacity == 0) return 0;     

            // while knapsack is not full            
            while (usedCapacity < capacity)
            {

                //  choose item i with maximum v[i]/w[i]
                var highestIndex = 0;
                var valueRatioAtIndex = 0.0;
                //var valueRatio = 0.0; // just to do the division for each i once

                for (var i = 0; i < n; i++)
                {
                    if (items[i, 1] > 0) // only consider items that still have weight left
                    {
                        // valueRatio is the value divided by the weight for each i
                        var valueRatio = items[i, 0] / items[i, 1];

                        if (valueRatio > valueRatioAtIndex)
                        {
                            highestIndex = i;
                            valueRatioAtIndex = valueRatio;
                        }
                    }

                }

                //items[i, 0] is the VALUE
                //items[i, 1] is the WEIGHT

                // if item fits into knapsack, take all of it
                if (items[highestIndex, 1] <= capacity - usedCapacity)
                {
                    usedCapacity += items[highestIndex, 1]; // keep track of used capacity
                    items[highestIndex, 1] = items[highestIndex, 1] - items[highestIndex, 1]; // take entire weight
                    value += items[highestIndex, 0]; // take entire value                    
                }
                // otherwise, divide the item into units of the weight capacity is measured in
                else
                {
                    // take 1 unit of weight at a time while there's still unused capacity
                    while (usedCapacity < capacity) //&& items[highestIndex, 1] > 0  not necessary here
                    {
                        usedCapacity += 1;
                        items[highestIndex, 1] = items[highestIndex, 1] - 1; // reduce weight by one
                        value += valueRatioAtIndex;
                    }
                }
                if (n == 1) return value;
            }
            // return total value taken
            return value;
        }

        public static int MoneyChangeFast(int m)
        {
            int remaining = m;
            int minCoins = 0;

            var x = remaining / 10;
            remaining = remaining - (x * 10);

            minCoins += x;

            x = remaining / 5;
            remaining = remaining - (x * 5);

            minCoins += x;

            x = remaining;
            minCoins += x;

            return minCoins;
        }

        public static int MoneyChangeNaive(int m)
        {
            int remaining = m;
            int minCoins = 0;

            while (remaining > 0)
            {
                while (remaining >= 10)
                {
                    remaining -= 10;
                    minCoins += 1;
                }
                while (remaining >= 5)
                {
                    remaining -= 5;
                    minCoins += 1;
                }
                while (remaining >= 1)
                {
                    remaining -= 1;
                    minCoins += 1;
                }
            }

            return minCoins;
        }

        public static long HugeFiboModM(long n, long m)
        {
            // must avoid looping through all n
            var periodLength = GetPisanoPeriod(m); // max # of loops is m^2

            return FastFiboModM(n % periodLength, m);
        }

        public static long GetPisanoPeriod(long m)
        {
            // For any integer m >= 2, the sequence F(n) % m is periodic
            // This is known as the Pisano period and it always starts with 01

            if (m < 2) return 0;

            long previous = 0; // F(0)
            long current = 1; // F(1)

            // Since we start off with the first two Fibo's i is going to be 2 behind the Fibo we are currently taking
            for (int i = 0; i < (m * m); i++) // period always terminates within m^2
            {
                long tempPrevious = previous;
                previous = current;
                current = (tempPrevious + current) % m;

                if (previous == 0 && current == 1)
                    return i + 1; // here i is the length of the period, but since array is 0-based we need to add one to it
            }

            return 0;
        }

        public static long FastFiboModM(long n, long m)
        {
            if (n <= 1) return n;

            long previous = 0;
            long current = 1;

            for (long i = 0; i < n - 1; ++i)
            {
                long tmp_previous = previous;
                previous = current;
                current = (tmp_previous % m) + (current % m);
            }

            return current % m;
        }

    }
}

