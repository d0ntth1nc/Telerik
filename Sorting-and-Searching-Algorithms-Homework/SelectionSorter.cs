namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection must not be null");
            }

            if (collection.Count > 1)
            {
                for (int i = 0; i < collection.Count - 1; i++)
                {
                    int minIndex = i;
                    for (int k = i + 1; k < collection.Count; k++)
                    {
                        if (collection[k].CompareTo(collection[minIndex]) < 0)
                        {
                            minIndex = k;
                        }
                    }
                    if (minIndex != i)
                    {
                        T valueToSwap = collection[i];
                        collection[i] = collection[minIndex];
                        collection[minIndex] = valueToSwap;
                    }
                }
            }
        }
    }
}
