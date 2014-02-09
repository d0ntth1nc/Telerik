using System;

namespace _15.Find_prime_numbers
{
    //Write a program that finds all prime numbers in the range [1...10 000 000].
    //Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
    class PrimeNumbersFinder
    {
        static void Main(string[] args)
        {
            bool[] notPrime = new bool[1000000];
            for (int i = 2; i < notPrime.Length; i++)
            {
                if (!notPrime[i])
                {
                    for (long k = 2; (k * i) < notPrime.Length; k++)
                    {
                        notPrime[k * i] = true;
                    }
                }
            }

            for (int i = 0; i < 20 - 1; i++)
            {
                if (!notPrime[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
