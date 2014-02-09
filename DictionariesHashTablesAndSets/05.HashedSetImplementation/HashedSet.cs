using _04.HashTableImplementation;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _05.HashedSetImplementation
{
    class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, int> hashTable;

        public Int32 Count { get { return this.hashTable.Count; } }

        public HashedSet()
        {
            this.hashTable = new HashTable<T,int>();
        }

        public void Add(T value)
        {
            this.hashTable.Add(value, 0);
        }

        public Int32 Find(T value)
        {
            return this.hashTable.Find(value);
        }
     
        public void Remove(T value)
        {
            this.hashTable.Remove(value);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var value in this.hashTable.Keys)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
