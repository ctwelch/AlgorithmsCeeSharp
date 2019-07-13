using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    public class Fibonacci
    {
        public int NaiveFibonacci(int n)
        {
            if(n <= 1)
            {
                return n;
            }

            return NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);

            // Example: Fib(5)  -- O(2^n-1)   // Recursion needs 16 steps for Fib-5
            //
            //                 NaiveFibonacci(4)             +                  NaiveFibonacci(3)
            //                        3                      +                          2
            //                        |                                                 |
            //                        |                                                 |
            //   NaiveFibonacci(3)    +   NaiveFibonacci(2)           NaiveFibonacci(2) + NaiveFibonacci(1)
            //             2          +           1                              1      +       1
            //             |                      |                              |
            //             |                      |            NaiveFibonacci(1) + NaiveFibonacci(0)
            //             |                      |                     1        +      0
            //             |    NaiveFibonacci(1) + NaiveFibonacci(0)
            //             |            1         +         0
     // NaiveFibonacci(2)  +   NaiveFibonacci(1)
     //              1     +     1
           //              |                      
           //              |
      // NaiveFibonacci(1) + NaiveFibonacci(0)
      //          1        +      0
        }

        public long FastFibonacci(long n)
        {
            if (n <= 1) return n;

            long[] nums = new long[n];
            
            nums[0] = 1;
            nums[1] = 1;

            for (long i = 2; i < n; i++)
            {
                // with array access essentially free, here we do Fib-5 in 3 loops
                nums[i] = nums[i - 1] + nums[i - 2];
            }

            return nums[n-1];
        }

        public bool TestSolution()
        {
            bool pass = true;

            if (FastFibonacci(3) != 2)
            {
                pass = false;
            }

            if (FastFibonacci(10) != 55)
            {
                pass = false;
            }

            for (int i = 0; i < 20; i++)
            {
                if(FastFibonacci(i) != NaiveFibonacci(i))
                {
                    pass = false;
                }
            }

            return pass;
        }

        int NaiveFiboLastDigit(int n)
        {
            if (n <= 1)
                return n;

            int previous = 0;
            int current = 1;

            for (int i = 0; i < n - 1; ++i)
            {
                int tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;
            }

            return current % 10;
        }

        public int FastFiboLastDigit(int n)
        {
            if (n <= 1) return n;

            int previous = 0;
            int current = 1;

            for (int i = 0; i < n - 1; ++i)
            {
                int tmp_previous = previous;
                previous = current;
                current = (tmp_previous % 10) + (current % 10);
            }

            return current % 10;
        }

        public long NaiveFiboHugeMod(long n, long m)
        {
            if (n <= 1)
                return n;

            long previous = 0;
            long current = 1;

            for (long i = 0; i < n - 1; ++i)
            {
                long tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;
            }

            return current % m;
        }

        // For any integer m >= 2, the sequence {F(n) % m} is periodic
        //  the period always starts with 01 -- known as the Pisano period
        public long FastFiboHugeMod(long n, long m)
        {
            if (n <= 1) return n;

            long periodLength = 0;
            long[] sequence = new long[n];

            // for each fibo number i, calculate F(i) % m
            // stop when the sequence is established
            // this is when the first half of the integers is the same as the second half
            for(long i = 0; i < n; i++)
            {
                // say n == 4

                // For each n populate the i index with F(i) % m
                sequence[i] = (FastFibonacci(i) % m);
                // 0: 0 % m
                // 1: 1 % m
                // 2: 1 % m
                // 3: 2 % m

                long indexAtMiddle = ((long)sequence.Count(x => x != 0) / (long)2);
                long middle = indexAtMiddle;

                // If the number of elements are even, 
                // see if the first half is the same as the second half
                for(long x = 0; x < indexAtMiddle; x++)
                { // indexAtMiddle = 2
                  // 0: x = 0, middle = 2
                  // 1: x = 1, middle = 3
                  // 2: x = 2, execution terminates
                    if (sequence[x] == sequence[middle])
                    {                        
                        middle++;
                    }
                    else
                    {
                        break; // go to next iteration of outer for loop
                    }

                    // If we have reached this point we have found the length of the period
                    periodLength = sequence.Count(s => s!= 0);
                }         
            }

            // now, get the n % (sequence.length) 
            var smallFibo = n % (long)periodLength;

            // then, return the fibo of that small result and mod it by m
            return FastFibonacci(smallFibo) % m;
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
