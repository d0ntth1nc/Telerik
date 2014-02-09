namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var collectionElement in this.items)
            {
                if (item.CompareTo(collectionElement) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            int startElementIndex = 0;
            int endElementIndex = this.items.Count - 1;
            bool isFound = false;
            while (startElementIndex <= endElementIndex)
            {
                int middleIndex = (startElementIndex + endElementIndex) / 2;
                if (item.CompareTo(this.items[middleIndex]) > 0)
                {
                    startElementIndex = middleIndex + 1;
                }
                else if (item.CompareTo(this.items[middleIndex]) < 0)
                {
                    endElementIndex = middleIndex - 1;
                }
                else
                {
                    isFound = true;
                    continue;
                }
            }
            return isFound;
        }

        //Complexity is O(n), because the 'for' loop runs 'n' times
        public void Shuffle()
        {
            Random randomNumberGenerator = new Random();
            for (int i = this.items.Count - 1; i >= 0; i--)
            {
                int randomIndex = randomNumberGenerator.Next(0, i);
                T valueToSwap = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = valueToSwap;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
