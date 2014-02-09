using System;
using System.Collections.Generic;
using System.Linq;

namespace _09
{
    /*
     * We are given the following sequence:
    S1 = N;
    S2 = S1 + 1;
    S3 = 2*S1 + 1;
    S4 = S1 + 2;
    S5 = S2 + 1;
    S6 = 2*S2 + 1;
    S7 = S2 + 2;
    ...
    Using the Queue<T> class write a program to print its first 50 members for given N.
    */
    class Sequence
    {
        static void Main(string[] args)
        {
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int elementIndex = 0;
            do
            {
                queue.Enqueue(queue.ElementAt(elementIndex) + 1);
                queue.Enqueue(2 * queue.ElementAt(elementIndex) + 1);
                queue.Enqueue(queue.ElementAt(elementIndex) + 2);
                elementIndex++;
            }
            while (queue.Count < 50);

            foreach (var item in queue)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}
