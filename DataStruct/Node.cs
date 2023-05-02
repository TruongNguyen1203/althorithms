using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataStruct
{
    public class Node<T> 
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}