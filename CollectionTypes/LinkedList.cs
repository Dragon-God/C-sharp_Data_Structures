using System.Collections;
using System.Collections.Generic;

using SimpleTypes;
using CollectionTypes.Enumerators;

namespace CollectionTypes
{
    public class LinkedList<TData>: IEnumerable<TData>
    {
        public Node<TData> Head { get; set; }
        public Node<TData> Tail { get; set; }

        public LinkedList()
        {
            Head = Tail = null;
        }

        #region List API
        public void AddHead(TData data)
        {
            Node<TData> newHead = new Node<TData>(data);

            if (Head is null)
                Tail = newHead;
            else
                newHead.Next = Head;
            
            Head = newHead;
        }

        public void AddTail(TData data)
        {
            Node<TData> newTail = new Node<TData>(data);

            if (Tail is null)
                Head = newTail;
            else
                Tail.Next = newTail;

            Tail = newTail;
        }
        #endregion
        
        #region Interface Implementations
        public IEnumerator<TData> GetEnumerator()
        {
            return new LinkedListEnumerator<TData>(Head);
        }

        // Implementing `IEnumerable<T>` requires an implementation of `IEnumerable`
        IEnumerator IEnumerable.GetEnumerator()    // Explicit interface specifications don't have any access specifiers
        {
            return this.GetEnumerator();
        }
        #endregion

        public override string ToString()
        {
            string result = "";

            foreach (TData item in this)
            {
                result += item.ToString() + ", ";
            }

            return result.TrimEnd(new char[]{' ', ','});
        }
    }
}