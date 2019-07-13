using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    class DynamicProgramming
    {
        public long RecursiveChange(long money, long[] coins)
        {
            if(money == 0)
            {
                return 0;
            }

            long minNumCoins = long.MaxValue;
            long numCoins = 0;

            for(var i = 0; i < coins.Length; i++)
            {
                if(money >= coins[i])
                {
                    // Each recursive call necessary to change money results in incrementing minNumCoins by 1
                    numCoins = RecursiveChange(money - coins[i], coins);

                    // After each coin gets its chance to be the first in the choice-path
                    //  and it finally comes out of all the recursive calls it takes to change
                    //  all subsequent money remainders, call it numCoins,
                    // It gets a chance to compare its numCoins + 1 (for itself) to the minNumberCoins

                    // At the base case, numCoins will be 0, so minNumCoins gets incremented by 1
                    // At the end of the recursive calls, numCoins will equal the # of recursive calls
                    //  it took to make change out of the remainder of money if this coin was used first 
                    if (numCoins + 1 < minNumCoins)
                    {
                        minNumCoins = numCoins + 1;
                    }
                }
            }

            return minNumCoins;
        }

        public long DynamicChange(long money, long[] coins)
        {
            long[] minNumCoins = new long[money];
            long numCoins;

            for (var m = 0; m < money; m++)
            {
                minNumCoins[m] = long.MaxValue;

                for(var i = 0; i < coins.Length; i++)
                {
                    if (m >= coins[i])
                    {
                        numCoins = minNumCoins[m - coins[i]] + 1;
                        if(numCoins < minNumCoins[m])
                        {
                            minNumCoins[m] = numCoins;
                        }
                    }
                }                
            }

            return minNumCoins[money];
        }

        // Sequence Alignment problems
        // Can remove the 1st symbol from both strings
        //  1 point if symbols match
        //  0 points for unmatched
        // Or remove the 1st symbol from only one of the strings, shifting everything else to the right
        //  0 points

        // Input is a two-row matrix
        // 1st row: symbols of the 1st string in order, interspersed by "-"
        // 2nd row: symbols of the 2nd string in order, interspersed by "-"

        // Maximize the number of alignments using:
        //  Matches (+1) : both rows have same value
        //  Insertions (-1) : insert a "-" in the top row, shifting everything else to the right by 1
        //  Deletions (-1) : insert a "-" in the bottom row, shifting everything else to the right by 1
        //  Mismatches (+0) : both rows have different value

        // AlignmentScore = 1(Matches) + -1(Insertions) + -1(Deletions) + 0(Mismatches)


        // Longest Common Subsequence
        // Maximize the length of a common susequence 
        // corresponds to maximizing the AlignmentScore

        // Edit Distance
        // Minimum number of operations (insert, delete, substitute) to transform one string into another
        //  that it, the minimum number of insertions, deletions and mismatches, out of all possible alignments
        // well, minimizing the edit distance is the same as maximizing the alignment score
        
        public void EditDistance(long[] A, long[] B)
        {

        }

        // Edit Distance Ways
        // There are usually many different paths that use the optimal number of steps

        //ways[i, j] = 0
        //if T[i, j] == T[i - 1, j] + 1:
        //  ways[i, j] += ways[i - 1, j]
        //if T[i, j] == T[i, j - 1] + 1:
        //  ways[i, j] += ways[i, j - 1]
        //if word1[i] == word2[j] and T[i, j] == T[i - 1, j - 1]:
        //  ways[i, j] += ways[i - 1, j - 1]
        //if T[i, j] == T[i - 1, j - 1] + 1:
        //  ways[i, j] += ways[i - 1, j - 1]


        // DiscreteKnapsack
        // Greedy algorith fails when items must be taken whole or not.
        // Taking the item with the highest value ratio is not a safe step 
        // 
        // Inputs: Weights W[], Values V[] of n items, and C capacity
        // Outputs: Maximum value of items whose weight doesn't exceed capacity
        //              Each item can be used any number of times

        // Cut and Paste
        // Consider some subset of items optimalSet[] with combined weight at most C,
        //  whose total value is maximal
        // Now, consider some element i in that optimal set, optimalSet[i]
        //  that we remove from the set
        // What remains is some subset of items whose combined weight
        //  is at most C - W[i]
        // And the total value of what remains must be optimal
        // It must be maximial among all subset of items 
        //  whose total weight is also at most C - w[i]
        // For if there is another such subset, but whose total value is higher,
        //  if we then take the ith item and put it back into this subset
        //  what we get is the solution to our problem, and it contradicts the fact 
        //  that we started with an optimal solution
        //  
        //  This type of solution is one where you break the problem down into smaller subproblems
        //  Here, we must keep taking items out and seeing if what remains is an optimal solution
        //  For each possible total weight from 0 to C, we need to know the optimal combination of items
        //  Let value[w] be the maximum value of a knapsack of weight w.  -- value[] is the set of optimal values for each weight
        //    value[w] = max{ value[w - W[i]] + V[i] }  -- for i: W[i] < w 
        //     this says that to get to the value[w], 
        //     we lookup the optimal value for the weight that is less than w
        //     by the weight of the item being removed, and adding its value
        
        // with repititions
        public long DiscreteKnapsack(long W, long[] weights, long[] values)
        {
            var optimalValues = new Dictionary<long, long>();
            var n = weights.Length;

            // for each possible weight
            for (var w = 0; w < W; w++)
            {
                optimalValues[w] = 0;
                for(var i = 0; i < n; i++)
                { // among items that weigh less than w
                    if(weights[i] <= w)
                    {
                        // see if by changing out the weight/value of the ith element
                        // results in an inceased optimal value for w
                        var val = optimalValues[w - weights[i]] + values[i];

                        if(val > optimalValues[w])
                        {
                            optimalValues[w] = val;
                        }
                    }
                }
            }

            return optimalValues[W];
        }

        // without repititions
        // if an element already exists, we can't add it again
        public long DiscreteKnapsackNoRepeats(int W, int[] weights, int n)
        {
            if (W == 0) return 0;

            // Using the observations that if a knapsack of capacity W 
            //  is filled such that the value of the available items is optimized
            //  then has its nth item removed, the what remains is a knapsack
            //  of size W - weights[n], reducing the total weight
            // Also, for each available item, either it will be used in the knapsack or not
            //  if it doesn't contain the nth element, 
            //  we reduce the problem size by only considering item 1 through n

            // So the subproblem here looks like something that takes in 
            //  an ever decreasing sets of weights and values
            // For any w, from 0 to W, and for any i from 0 to n
            //  let's denote by value of w and i, the maximum value that can be achieved 
            //  by using only items from 1 to i and whose total value is at most w

            // now we can express the solution as a solution to smaller subproblems
            // let value(i, w) be the maximum value achievable 
            //  using a knapsack of weight w and items i
            // values(i, w) = max{ value(i-1, W-weights[i]) + values[i], value(i-1, W) }
            // first case: taking out ith item, reducing weight by weights[i], pushing up values[i]
            // second case: we know that the optimal solution for W doesn't use i            
           
            var optimalValues = new int[W, n+1];

            for (var i = 1; i <= n; i++)
            {
                for (var w = 0; w < W; w++)
                {// for each possible weight, for each item

                    //if(weights[i-1] <= w)
                    //{
                    //    optimalValues[w, i] = Math.Max(
                    //        optimalValues[w,i-1],
                    //        optimalValues[w-weights[i-1],i-1] + weights[i-1]);
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

            return optimalValues[W-1, n];
        }


        // primitive calculator can multiply x by 2 or 3, and can add one to it
        public List<int> PrimitiveCalculator(int n)
        {
            // goal is to go from 1 to n in the least # of operations
            // C(n) is the minimum number of operations required to obtain n from 1
            // How do we express C(n) through C(n/3), C(n/2), C(n - 1)?
            // need to go through each integer from 0 up to n and 
            //

            // What's the min number of operations to get 0:
            // 0, C(0)
            // for 1:
            // 1, C(n + 1)
            // for 2:
            // 2, C(n + 1), C(n + 1) 
            // for 3:
            // 1, 

            // so lets try, starting from 0
            // create a dictionary that will hold C(n) for all pertinent values of n
            // when we want to calculate a C(n) for an n,

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

            for (int i = n; i > 1;)
            {
                sequence.Add(i);
                if (arr[i - 1] == arr[i] - 1)
                    i = i - 1;
                else if (i % 2 == 0 && (arr[i / 2] == arr[i] - 1))
                    i = i / 2;
                else if (i % 3 == 0 && (arr[i / 3] == arr[i] - 1))
                    i = i / 3;
            }
            sequence.Add(1);

            sequence.Reverse();
            return sequence;            
        }       

        public void PlacingParenthesis()
        {

        }
    }
}
