using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStruct
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyLinkedNode<T> Head { get; set; }
        public DoublyLinkedNode<T> Tail { get; set; }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            var temp = Head;
            Head = node;
            Head.Next = temp;
            
            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedNode<T>(value));
        }

        private void AddLast(DoublyLinkedNode<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;

            Count--;

            if (IsEmpty)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            Count--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            var result = new List<T>();
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}