using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace _03.BiDictionaryImplementation
{
    public class BiDictionary<K1, K2, V>
    {
        private MultiDictionary<K1, V> dictionaryForFirstKey;
        private MultiDictionary<K2, V> dictionaryForSecondKey;
        private MultiDictionary<int, V> dictionaryForBothKeys;

        public BiDictionary()
        {
            dictionaryForFirstKey = new MultiDictionary<K1, V>(true);
            dictionaryForSecondKey = new MultiDictionary<K2, V>(true);
            dictionaryForBothKeys = new MultiDictionary<int, V>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, V value)
        {
            int hashKey = GetHashKey(firstKey, secondKey);
            dictionaryForBothKeys.Add(hashKey, value);
            dictionaryForFirstKey.Add(firstKey, value);
            dictionaryForSecondKey.Add(secondKey, value);
        }

        public ICollection<V> SearchByFirstKey(K1 firstKey)
        {
            List<V> found = new List<V>();

            found.AddRange(dictionaryForFirstKey[firstKey]);

            return found;
        }

        public ICollection<V> SearchBySecondKey(K2 firstKey)
        {
            List<V> found = new List<V>();

            found.AddRange(dictionaryForSecondKey[firstKey]);

            return found;
        }

        public ICollection<V> SearchByBothKeys(K1 firstKey, K2 secondKey)
        {
            List<V> foundItems = new List<V>();

            foundItems.AddRange(dictionaryForFirstKey[firstKey]);
            foundItems.AddRange(dictionaryForSecondKey[secondKey]);
            foundItems.AddRange(dictionaryForBothKeys[GetHashKey(firstKey, secondKey)]);

            return foundItems;
        }

        private int GetHashKey(K1 firstKey, K2 secondKey)
        {
            int hashKey = firstKey.GetHashCode() + 72;
            hashKey += secondKey.GetHashCode() + 65;
            return hashKey;
        }
    }
}
