namespace DataStruct
{
    public class DoublyLinkedNode<T>
    {
        public DoublyLinkedNode<T> Previous { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
        public T Value { get; set; }

        public DoublyLinkedNode(T value)
        {
            Value = value;
        }
    }
}