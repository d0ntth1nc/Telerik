
namespace _11.ListItemAndLinkedListImplementation
{
    public class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> NextItem { get; set; }

        public ListItem(T value)
        {
            this.Value = value;
        }
    }
}
