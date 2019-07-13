using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    class GreedyAlgorithms
    {

        // The Min Refills Problem
        // There are nStations between your starting point and your destination
        // Starting at refillStation[0], and ending at refillStation[nstations] + 1 (aka Destination)
        // the refillStations array has the distance from the starting point for each refillStation
        public int MinimumRefills(int[] refillStations, int nStations, int lengthCanTravelOnFullTank)
        {
            var numRefills = 0;
            var currentRefill = 0; // Assume starting with full tank

            while(currentRefill <= nStations) // while there are still stations between where you are and your destination
            {
                var lastRefill = currentRefill;

                // Find the farthest station you can reach on a tank of gas
                while(currentRefill <= nStations && // there are still stations you could hit
                    // and the distance between where you are and the next station is within the length you can travel
                    (refillStations[currentRefill + 1] - refillStations[lastRefill]) <= lengthCanTravelOnFullTank)
                {
                    currentRefill = currentRefill + 1; // increment until we find the farthest reachable station
                }

                if(currentRefill == lastRefill) // Means we can't reach any station from here (we didn't increment in the last step)
                {
                    throw new IndexOutOfRangeException(); 
                }

                if(currentRefill <= nStations) // confirm that the station isn't the destination ( because that's not a refill!)
                {
                    numRefills = numRefills + 1;
                }
            }

            return numRefills;
        }

        // A move is called safe if there is an optimal solution consistent with this first move -- will be important for homework
        // Not all first moves are safe, often greedy moves are not safe
        // For instance, going to the first station available isn't a safe move; going to the farthest is.

        // Problem solving template
        // Make a greedy choice
        // Prove that it is a safe move
        // Reduce to a subproblem
        // Solve the subproblem


        // Organize a group of children into the minimum possible
        // number of groups such that the age of any two children 
        // in the same group differ by at most one year
        public void GroupPartyChildrenNaive(int[] childAges)
        {
            // give me the youngest,
            // then the second youngest that's not more than a year older than the youngest
            // repeat until there are none within a year of the first child

            // now give me the youngest, ungrouped child
            // then match that one with the next youngest within a year
            // repeating until there are none within a year of the anchor child

            // repeat this until all the children are grouped

            // let n be the number of groups
            var n = childAges.Length; // n is initialized to be equal to the Number of Children to be grouped

            var good = true; // assume at first that the groups are already good



        }

        // Assuming the input is a sorted array of points
        public int[] PointsCoverSorted(int[] x)
        {            
            int[] result = { };
            var i = 1;

            while (i <= x.Length) // covering each element in the input array
            {
                // line segment begins at x[i], goes to x[i] + 1
                // or, the leftmost point(value) in a line segment, 
                // and the rightmost point(value) of that segment (of length 1)
                int[,] s = { { x[i] } , { x[i] + 1} };

                //result{i] = s;  // somehow add that info to a collection

                // increment i here
                i++;

                // record that value of the rightmost point 
                var r = x[i] + 1;

                // while we still have array elements left,
                // and the value of the next i is still no greater 
                //  than the value at element i 
                while (i <= x.Length && x[i] <= r) 
                {
                    // increment i as we consume points within the length of the line segment
                }

            }

            return result;
        }

        // Ad Placement Problem
        // distribute the adds
        // so that the slots with the highest estimated # of clicks per day
        //  have the ad with the highest Value per click

        // given two sequences representing profit-per-click and average clicks-per-day
        // partition them into pairs such that the sum of their products is maximized
        public long MaximizeAddRevenue(int n, int[,] profitPerClick, int[,] clicksPerDay)
        {
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

                        if (profitPerClick[p, 0] < 0 && profitPerClick[p, 0] < maxNegProfitValue)
                        {
                            maxNegProfitIndex = p;
                            maxNegProfitValue = profitPerClick[maxNegProfitIndex, 0];
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
                        // largest positive
                        if (clicksPerDay[c, 0] >= maxClicksValue
                            || (maxClicksValue == -1)) // this fucks me when the value I need here is -1
                            ///*&& clicksPerDay[c, 0] < 0*/)) // this will replace my 0 with a negative value fucking me over
                        {
                            maxClicksIndex = c;
                            maxClicksValue = clicksPerDay[c, 0];
                        }

                        // also need the smallest negative in a separate loop.
                        // can't fit it into the above or below loops without major problems

                        // largest negative
                        if (clicksPerDay[c, 0] < 0 && clicksPerDay[c, 0] < maxNegClickValue)
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
                if (maxProfitValue < 0 && maxClicksValue < 0)
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
                //Console.WriteLine(maxProfitValue + " * " + maxClicksValue + " = " + maxValue);
                Console.WriteLine(value);
                // reduce values of maxIndexes to 0 so they aren't counted again
                profitPerClick[maxProfitIndex, 1] = 0;
                clicksPerDay[maxClicksIndex, 1] = 0;
            }

            return value;
        }


        //public long MaximizeAddRevenue(int n, int[,] inputs)
        //{
        //    long value = 0;

        //    for (var i = 0; i < n; i++)  // for each n
        //    {
        //        // index of max 1
        //        var maxProfitIndex = 0;
        //        var maxProfit = 0;
        //        for (var p = 0; p < n; p++)
        //        {
        //            if (profitPerClick[p] > maxProfit)
        //            {
        //                maxProfitIndex = p;
        //            }
        //        }
        //        // index of max 2
        //        var maxClicksIndex = 0;
        //        var maxClicks = 0;
        //        for (var c = 0; c < n; c++)
        //        {
        //            if (clicksPerDay[c] > maxClicks)
        //            {
        //                maxClicksIndex = c;
        //            }
        //        }

        //        // sum the value
        //        value += ((long)profitPerClick[maxProfitIndex] * (long)clicksPerDay[maxClicksIndex]);
        //        // reduce values of maxIndexes to 0 so they aren't counted again
        //        profitPerClick[maxProfitIndex] = 0;
        //        clicksPerDay[maxClicksIndex] = 0;
        //    }

        //    return value;
        //}




        // Fractional Knapsack problem  -- Greedy
        // input:
        // Weights w[0], ... , w[n] -- Values v[0], ... , v[n] -- capacity W
        // output:
        // The maximum total value of fractions of items that fit into a bag of capacity W

        // So if you have n number of food items
        // and you know their total weights and energy values

        // The idea here is if you take a whole and divide it into parts
        // you can now work with the value per part, 
        // allowing you to better maximize the value of the final conglomerate

        // A General Approach:
        //

        public double Knapsack(int n, int capacity, double[,] items)
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

        // Money Changing Problem
        // Output the minimum number of coins with denominations 1, 5, 10 that changes input m
        public int MoneyChangeNaive(int m)
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

        public int MoneyChangeFast(int m)
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



    }
}
