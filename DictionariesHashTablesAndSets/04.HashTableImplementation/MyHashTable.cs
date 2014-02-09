using System;
using System.Collections;
using System.Collections.Generic;

namespace _04.HashTableImplementation
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private LinkedList<KeyValuePair<K, T>>[] dataContainer = new LinkedList<KeyValuePair<K, T>>[16];
        private List<K> usedKeys = new List<K>();
        public Int32 Capacity { private set; get; }
        public Int32 Count { set; get; }

        public List<K> Keys
        {
            set { }
            get { return GetListOfKeys(); }
        }

        public T this[K key]
        {
            set { SetKeyInDictionary(key, value); }
            get { return Find(key); }
        }

        public HashTable()
        {
            this.Capacity = 0;
            this.Count = 0;
        }

        private List<K> GetListOfKeys()
        {
            List<K> keys = new List<K>();
            for (int i = 0; i < this.dataContainer.Length; i++)
            {
                if (this.dataContainer[i] != null)
                {
                    var nextValues = this.dataContainer[i].First;
                    while (nextValues != null)
                    {
                        keys.Add(nextValues.Value.Key);
                        nextValues = nextValues.Next;
                    }
                }
            }
            return keys;
        }

        private void SetKeyInDictionary(K key, T value)
        {
            int hashCode = Math.Abs(key.GetHashCode() % this.dataContainer.Length);
            if (this.dataContainer[hashCode] == null)
            {
                Console.WriteLine("There is no element with such key");
            }
            else
            {
                bool isFound = false;
                var nextValues = this.dataContainer[hashCode].First;
                while (nextValues != null)
                {
                    if (nextValues.Value.Key.Equals(key))
                    {
                        LinkedListNode<KeyValuePair<K, T>> node =
                            new LinkedListNode<KeyValuePair<K, T>>(new KeyValuePair<K, T>(key, value));
                        this.dataContainer[hashCode].AddAfter(nextValues, node);
                        this.dataContainer[hashCode].Remove(nextValues);
                        isFound = true;
                        break;
                    }
                    nextValues = nextValues.Next;
                }
                if (isFound == false)
                {
                    Console.WriteLine("There is no element with such key");
                }
            }
        }

        private void ResizeContainer()
        {
            int newLength = this.dataContainer.Length * 2;
            LinkedList<KeyValuePair<K, T>>[] newContainer = new LinkedList<KeyValuePair<K, T>>[newLength];
            foreach (var key in usedKeys)
            {
                int oldHashCode = Math.Abs(key.GetHashCode() % this.dataContainer.Length);
                int newHashCode = Math.Abs(key.GetHashCode() % newContainer.Length);
                newContainer[newHashCode] = this.dataContainer[oldHashCode];
            }

            this.dataContainer = newContainer;
        }

        public void Add(K key, T value)
        {
            if (this.Capacity >= this.dataContainer.Length * 0.75)
            {
                ResizeContainer();
            }

            int hashCode = Math.Abs(key.GetHashCode() % this.dataContainer.Length);
            if (this.dataContainer[hashCode] == null)
            {
                this.Capacity++;
                this.usedKeys.Add(key);
                this.dataContainer[hashCode] = new LinkedList<KeyValuePair<K, T>>();
            }

            var nextValues = this.dataContainer[hashCode].First;
            while (nextValues != null)
            {
                if (nextValues.Value.Key.Equals(key))
                {
                    Console.WriteLine("There is such key already");
                }
                nextValues = nextValues.Next;
            }
            this.dataContainer[hashCode].AddLast(new KeyValuePair<K, T>(key, value));
            this.Count++;
        }

        public T Find(K key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % this.dataContainer.Length);
            if (this.dataContainer[hashCode] == null)
            {
                Console.WriteLine("There is no element with such key");
                return default(T);
            }
            else
            {
                var nextValues = this.dataContainer[hashCode].First;
                while (nextValues != null)
                {
                    if (nextValues.Value.Key.Equals(key))
                    {
                        return nextValues.Value.Value;
                    }
                    nextValues = nextValues.Next;
                }
                Console.WriteLine("There is no element with such key");
                return default(T);
            }
        }

        public bool Contain(K key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % this.dataContainer.Length);
            bool isFound = false;
            if (this.dataContainer[hashCode] != null)
            {
                var nextValues = this.dataContainer[hashCode].First;
                while (nextValues != null)
                {
                    if (nextValues.Value.Key.Equals(key))
                    {
                        isFound = true;
                        break;
                    }
                    nextValues = nextValues.Next;
                }
            }
            return isFound;
        }

        public void Remove(K key)
        {
            int hashCode = Math.Abs(key.GetHashCode() % this.dataContainer.Length);
            if (this.dataContainer[hashCode] == null)
            {
                Console.WriteLine("There is no element with such key");
            }
            else
            {
                bool isFound = false;
                var nextValues = this.dataContainer[hashCode].First;
                while (nextValues != null)
                {

                    if (nextValues.Value.Key.Equals(key))
                    {
                        this.dataContainer[hashCode].Remove(nextValues);
                        isFound = true;
                        this.Count--;
                    }
                    nextValues = nextValues.Next;
                }
                if (this.dataContainer[hashCode].First == null)
                {
                    this.Capacity--;
                    this.usedKeys.Remove(key);
                }
                if (isFound == false)
                {
                    Console.WriteLine("There is no element with such key");
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < dataContainer.Length; i++)
            {
                dataContainer[i] = null;
            }
            usedKeys.Clear();
            Capacity = 0;
            Count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.dataContainer.Length; i++)
            {
                if (this.dataContainer[i] != null)
                {
                    var nextValues = this.dataContainer[i].First;
                    while (nextValues != null)
                    {
                        yield return nextValues.Value;
                        nextValues = nextValues.Next;
                    }
                }
            }
        }
    }
}