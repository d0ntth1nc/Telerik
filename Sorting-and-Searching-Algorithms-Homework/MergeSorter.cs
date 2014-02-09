namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection must not be null");
            }

            if (collection.Count > 1)
            {
                List<T> firstSequenceOfElements = new List<T>();
                List<T> secondSequenceOfElements = new List<T>();
                SplitCollectionElements(collection, firstSequenceOfElements, secondSequenceOfElements);

                Sort(firstSequenceOfElements);
                Sort(secondSequenceOfElements);
                for (int i = collection.Count - 1; i >= 0; i--)
                {
                    if (firstSequenceOfElements.Count == 0)
                    {
                        collection[i] = secondSequenceOfElements.Last();
                        secondSequenceOfElements.Remove(secondSequenceOfElements.Last());
                    }
                    else if (secondSequenceOfElements.Count == 0)
                    {
                        collection[i] = firstSequenceOfElements.Last();
                        firstSequenceOfElements.Remove(firstSequenceOfElements.Last());
                    }
                    else if (firstSequenceOfElements.Last().CompareTo(secondSequenceOfElements.Last()) > 0)
                    {
                        collection[i] = firstSequenceOfElements.Last();
                        firstSequenceOfElements.Remove(firstSequenceOfElements.Last());
                    }
                    else
                    {
                        collection[i] = secondSequenceOfElements.Last();
                        secondSequenceOfElements.Remove(secondSequenceOfElements.Last());
                    }
                }
            }
        }

        private void SplitCollectionElements(IList<T> collection, List<T> firstSequenceOfElements, List<T> secondSequenceOfElements)
        {
            for (int i = 0; i < collection.Count / 2; i++)
            {
                firstSequenceOfElements.Add(collection[i]);
            }
            for (int i = collection.Count / 2; i < collection.Count; i++)
            {
                secondSequenceOfElements.Add(collection[i]);
            }
        }
    }
}
