using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    public class DivideConquer
    {
        private int firstHalf;

        public long BinarySearchR(long[] sequence, long key, long min, long max)
        {
            if (min > max)
            {
                return -1;
            }

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

        public long ContainsMajorityElement(long[] sequence, int n)
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

            if (leftMajority == rightMajority)
            {
                return leftMajority;
            }

            var leftCount = 0;
            for (var i = 0; i < n; i++) // check frequency of leftMajority
            {
                if (sequence[i] == leftMajority)
                {
                    leftCount++;
                }
            }

            var rightCount = 0;
            for (var i = 0; i < n; i++)
            {
                if (sequence[i] == rightMajority)
                {
                    rightCount++;
                }
            }

            if (leftCount > majority)
            {
                return leftMajority;
            }

            if (rightCount > majority)
            {
                return rightMajority;
            }

            return 0;
        }

        // Quick Sort
        // Take the first element m in the given array, A and arrange all the other elements such that
        // m is in its final position (put all smaller elements before it, all larger after it) in one scan
        // 
        // QuickSort(A, l, r)
        // {
        // if l > r:    // if left is greater than right
        //      return
        //
        // m = Partition(A, l, r)  // All elements to the left that are no greater than, all greater are to the right
        //  -- A[m] is in the final position -- 
        // Repeat recursively for the leftSide and the rightSide of m -- each recursion puts an element in its place.
        // QuickSort(A, l, m - 1)
        // QuickSort(A, m + 1, r)
        // }

        // pivot is the element by which we will partition our sub-array
        // call it:
        // x = A[l]
        //
        // Then iterate from l + 1 to r maintining he invariant:
        // A[k] <= x for all l + 1 <= k <= j
        // A[k] > x for all j + 1 <= k <= i

        // Use j to track the last index of elements less than m.
        // take each element
        // if it is greater than m, mark the element as belonging to the right of m (do nothing)

        // if it is less than m, we must move it to the leftSide of m by 
        // swapping it with the first element of the rightSide (j + 1)

        // x = A[l]; // the pivot, the first element
        // j = l;

        // for(var i = l + 1; i <= r; i ++) // from the second element to the end (on the first pass)
        // {
        //    if(A[i] <= x)
        //      { 
        //          j = j + 1; // increment j because the size of leftSide has just grown
        //          swap A[j] and A[i]
        //      }
        // }
        // -- now A[l + 1, ... , j] <= x and A[j + 1, ..., i] > x --
        // swap  A[l] and A[j]
        // return j;




    }
}
