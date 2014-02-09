using System;

namespace _11.ListItemAndLinkedListImplementation
{
    public class LinkedList<T>
    {
        private ListItem<T> mainItem;
        private int count;
 
        public int Count
        {
            get { return this.count; }
        }

        public T this[int index]
        {
            get
            {
                if (index >= this.count)
                {
                    throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
                }
                else
                {
                    ListItem<T> currentElement = this.mainItem;
                    int position = this.count - 1;
                    for (int i = 0; i < this.count - index - 1; i++)
                    {
                        currentElement = currentElement.NextItem;
                    }
                    return currentElement.Value;
                }
            }
        }
 
        public LinkedList()
        {
            this.mainItem = null;
            this.count = 0;
        }

        public LinkedList(ListItem<T> item)
        {
            this.mainItem = item;
            this.count++;
        }

        public LinkedList(T value)
        {
            ListItem<T> newItem = new ListItem<T>(value);
            this.mainItem = newItem;
            this.count++;
        }        

        public void AddItem(T value)
        {
            if (this.mainItem == null)
            {
                this.mainItem = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(value);
                this.mainItem = newItem;
            }
            this.count++;
        }

        public void RemoveLast()
        {
            ListItem<T> nextItem = this.mainItem.NextItem;
            this.mainItem = nextItem;
            this.count--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }
            else
            {
                if (this.count - 1 == index)
                {
                    this.RemoveLast();
                }
                else
                {
                    ListItem<T> main = this.mainItem;
                    for (int i = 0; i < this.count - index - 2; i++)
                    {
                        main = main.NextItem;
                    }
                    main.NextItem = main.NextItem.NextItem;
                    this.count--;
                }
            }
        }

        public void Remove(T value)
        {
            ListItem<T> main = this.mainItem;
            int position = this.count - 1;
            while (main.NextItem != null)
            {
                if (main.Value.Equals(value))
                {
                    this.RemoveAt(position);
                    break;
                }
                else
                {
                    main = main.NextItem;
                    position--;
                }
            } 
        }

        public void Clear()
        {
            this.mainItem = null;
        }

        public bool Contains(T value)
        {
            ListItem<T> currentElement = this.mainItem;
            while (currentElement.NextItem != null)
            {
                if (currentElement.Value.Equals(value))
                {
                    return true;
                }
                currentElement = currentElement.NextItem;
            }
            return false;
        }
    }
}
