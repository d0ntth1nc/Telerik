using System;

namespace _03.BiDictionaryImplementation
{
    class Test
    {
        static void Main(string[] args)
        {
            BiDictionary<int, uint, string> biDictionary = new BiDictionary<int, uint, string>();
            biDictionary.Add(11, 50, "aleksandar");
            Console.WriteLine("Executing .Add(11, 50, 'aleksandar')...");
            biDictionary.Add(54, 30, "dictionary");
            Console.WriteLine("Executing .Add(54, 30, 'dictionary')...");
            biDictionary.Add(33, 78, "icollection");
            Console.WriteLine("Executing .Add(33, 78, 'icollection')...");

            Console.Write("Executing .SearchByFirstKey(54) -> ");
            var foundByFirstKey = biDictionary.SearchByFirstKey(54);
            foreach (var item in foundByFirstKey)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Executing .SearchBySecondKey(78) -> ");
            var foundBySecondKey = biDictionary.SearchBySecondKey(78);
            foreach (var item in foundBySecondKey)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Executing .SearchByBothKeys(11, 50) -> ");
            var foundByBothKeys = biDictionary.SearchByBothKeys(11, 50);
            foreach (var item in foundByBothKeys)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Executing .SearchByFirstKey(5) -> ");
            var notFound = biDictionary.SearchByFirstKey(5);
            foreach (var item in notFound)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
