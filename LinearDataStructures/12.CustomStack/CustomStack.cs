using System;

namespace _12.CustomStack
{
    class CustomStack<T>
    {
        private T[] customStackDataArray = new T[10];
        
        public int Count { get; private set; }

        public CustomStack()
        {
            this.customStackDataArray = new T[1];
            this.Count = 0;
        }

        public void Push(T value)
        {
            if (this.Count==this.customStackDataArray.Length)
            {
                AddMoreSpace();   
            }

            this.customStackDataArray[this.Count] = value;
            this.Count += 1;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("The stack is empty");
            }
            T value = this.customStackDataArray[this.Count - 1];
            this.customStackDataArray[this.Count - 1] = default(T);
            this.Count -= 1;
            return value;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentNullException("The stack is empty");
            }
            T value = this.customStackDataArray[this.Count-1];
            return value;
        }

        public void Clear()
        {
            this.customStackDataArray = new T[1];
            this.Count = 0;
        }

        public bool Contains(T value)
        {
            bool contains = false;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.customStackDataArray[i].Equals(value))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        public void TrimExcess()
        {
            T[] newDataArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newDataArray[i] = this.customStackDataArray[i];
            }
            this.customStackDataArray = newDataArray;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.customStackDataArray[i];
            }
            return array;
        }

        private void AddMoreSpace()
        {
            T[] newStackDataArray = new T[this.customStackDataArray.Length * 2];
            for (int i = 0; i < this.customStackDataArray.Length; i++)
            {
                newStackDataArray[i] = this.customStackDataArray[i];
            }
            this.customStackDataArray = newStackDataArray;
        }
    }
}
