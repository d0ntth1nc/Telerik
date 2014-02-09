using System;

namespace _04.HashTableImplementation
{
    class HashTableImplementation
    {
        static void Main(string[] args)
        {
            HashTable<int, int> hassTable = new HashTable<int,int>();
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine("Executing HashTable.Add({0}, {1})", i, i * 2);
                hassTable.Add(i, i * 2);
            }
            Console.WriteLine();
            Console.WriteLine("Capacity: {0}", hassTable.Capacity);
            Console.WriteLine("Count: {0}", hassTable.Count);

            Console.WriteLine("Executing HashTable[6] = 333");
            hassTable[6] = 333;
            Console.WriteLine("Getting HashTable[6]-> {0}", hassTable[6]);

            Console.WriteLine("Executing HashTable.Remove(6)");
            hassTable.Remove(6);
            Console.WriteLine("HashTable[6] = {0}", hassTable[6]);

            Console.WriteLine("Executing .Find(3)");
            int foundItem = hassTable.Find(3);
            Console.WriteLine("Result: {0}", foundItem);

            var valuesList = hassTable.Keys;
            Console.WriteLine("Get keys as list - valuesList.Count -> {0}", valuesList.Count);

            //hassTable.Clear();
            Console.WriteLine("Printing the values");
            foreach (var item in hassTable)
            {
                Console.WriteLine("Key: {0} -> Value: {1}", item.Key, item.Value);
            } 
        }
    }
}
