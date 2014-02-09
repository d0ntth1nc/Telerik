using System;

namespace _13.LinkedQueue
{
    public class LinkedQueue<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;
        private int count = 0;

        public LinkedQueue()
        {

        }

        public void Enqueue(T data)
        {
            QueueItem<T> newItem = new QueueItem<T>(data);
            if (head == null)
            {
                head = newItem;
                tail = head;
            }
            else
            {
                tail.NextItem = newItem;
                tail = newItem;
            }
            count++;
        }

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            T result = head.Data;
            head = head.NextItem;
            count--;
            return result;
        }

        public int Count
        {
            get { return this.count; }
        }
    }
}
