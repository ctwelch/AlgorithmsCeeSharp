using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsCourse
{
    public class GreatestCommonDivisor
    {
        // The greatest common divisor Gcd(a,b) of two non-negative integers a and b, both not equal to 0
        //  is the greatest integer d that divides both a and b.

        // Lemma:
        // Let a' be the remainder when a is divided by b, then
        //  gcd(a,b) == gcd(a',b) == gcd(b,a')
        //
        // Proof:
        // a = a' + bq for some q
        // d divides a and b if and only if it divides a' and b

        // Example:
        // gcd(357, 234) == (357 % 234, 234) == (234, 357 % 234) == (234, 123)
        //               == (234 % 123, 123) == (123, 234 % 123) == (123, 111)
        //               == (123 % 111, 111) == (111, 123 % 111) == (111, 12)
        //               == (111 % 12, 12) == (12, 111 % 12) == (12, 3)
        //               == (12 % 3, 3) == (3, 12 % 3) == (3, 0) == GCD

        // works well because each step reduces the size of numbers by about a factor of 2
        // takes about log(ab) steps to compute
        // GCDs of 100 digit numbers takes about 600 steps
        // each step is just a single division

        public int EuclidGcd(int a, int b)
        {
            if (b == 0) return a; // Can't get an a' here. But everything is divisible by 0, so we just return a.

            var aPrime = a % b;

            return EuclidGcd(b, aPrime);
        }

        public int NaiveGcd(int a, int b)
        {
            int currentGcd = 1;

            for(int d = 2; d<= a && d <= b; d++) // go through all the possible divisors
            {
                if(a % d == 0 && b % d ==0) // if we have a candidate divisor
                {
                    if( d > currentGcd) // and that candidate is greater than our current value
                    {
                        currentGcd = d; // replace with the candidate
                    }
                }
            }

            return currentGcd;
        }

        // The least common multiple of two positive integers a and b is the least positive
        //  integer m that is divisible by both a and b
        public long NaiveLcm(int a, int b)
        {
            for (long m = 1; m <= (long)a * (long)b; m++) // Go through each integer
            {
                if(m % a == 0 && m % b == 0) // until you find the first one that is divisible by both a and b
                {
                    return m;
                }
            }

            return (long)a * (long)b;
        }

        // Realizing that Lcm(a,b) * Gcd(a,b) = a * b for any two positive integers a and b
        // so, Lcm(a,b) = (a * b) / Gcd(a,b)
        public int FastLcm(int a, int b)
        {            
            return (a * b) / EuclidGcd(a,b);
           // return ((long)a * (long)b) / EuclidGcd(a, b);
        }

    }
}
