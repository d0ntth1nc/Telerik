namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection must not be null");
            }

            if (collection.Count > 1)
            {
                IList<T> middleCollectionElement = new List<T>();
                middleCollectionElement.Add(collection[collection.Count / 2]);
                IList<T> smallerCollectionElements = new List<T>();
                IList<T> largerCollectionElements = new List<T>();

                SplitCollectionElements(collection, middleCollectionElement, smallerCollectionElements, largerCollectionElements);

                Sort(smallerCollectionElements);
                Sort(largerCollectionElements);

                List<T> concatedElements = smallerCollectionElements.Concat(middleCollectionElement).Concat(largerCollectionElements).ToList();
                for (int i = 0; i < concatedElements.Count; i++)
                {
                    collection[i] = concatedElements[i];
                }
            }
        }

        private void SplitCollectionElements(IList<T> collection, IList<T> middleCollectionElement, IList<T> smallerCollectionElements, IList<T> largerCollectionElements)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (i != collection.Count / 2)
                {
                    if (collection[i].CompareTo(middleCollectionElement[0]) < 0)
                    {
                        smallerCollectionElements.Add(collection[i]);
                    }
                    else
                    {
                        largerCollectionElements.Add(collection[i]);
                    }
                }
            }
        }
    }
}
