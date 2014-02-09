using System.Collections.Generic;

namespace TreesAndTraversals
{
    class Node<T>
    {
        public T Value { set; get; }
        public List<Node<T>> Children { set; get; }

        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public Node(T value) : this()
        {
            this.Value = value;
        }
    }
}
