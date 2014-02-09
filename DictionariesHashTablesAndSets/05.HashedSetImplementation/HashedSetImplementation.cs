using System;

namespace _05.HashedSetImplementation
{
    class HashedSetImplementation
    {
        static void Main(string[] args)
        {
            HashedSet<int> hashSet = new HashedSet<int>();
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Executing hashSet.Add({0})", i);
                hashSet.Add(i);
            }

            Console.WriteLine("Executing hashSet.Find(6)");
            int foundElement = hashSet.Find(6);
            Console.WriteLine("Found element: {0}", foundElement);

            Console.WriteLine("Executing hashSet.Remove(5)");
            Console.WriteLine("Executing hashSet.Find(5) -> {0}", hashSet.Find(5));

            Console.WriteLine("Executing hashSet.Count -> {0}", hashSet.Count);

            Console.WriteLine("Executing hashSet.Clear()");
            hashSet.Clear();

            Console.WriteLine("Executing hashSet.Count -> {0}", hashSet.Count);
        }
    }
}
