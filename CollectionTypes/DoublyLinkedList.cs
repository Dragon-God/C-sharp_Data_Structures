using System;

using SimpleTypes;

namespace CollectionTypes
{
    public class DoublyLinkedList<TData>: LinkedList<TData, DoubleNode<TData>>
    {
        public DoublyLinkedList(): base() {}

        public void RemoveTailNode()
        {
            if (Tail is null)
                throw new InvalidOperationException("Can't remove from an empty list!");
            
            Tail = Tail.Previous;
            Tail.Next = null;
        }
    }
}