
namespace _13.LinkedQueue
{
    public class QueueItem<T>
    {
        public QueueItem<T> NextItem { get; set; }
        public T Data { get; set; }

        public QueueItem(T data)
        {
            this.Data = data;
        }
    }
}
