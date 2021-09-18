using System;
using System.Collections.Generic;
using System.Collections;

using SimpleTypes;

namespace CollectionTypes
{
    public partial class LinkedList<TData>
    {
        internal class LinkedListEnumerator: IEnumerator<Node<TData>>
        {
            private Node<TData> _current;
            private readonly Node<TData> _start;

            public Node<TData> Current => _current;
            
            // Implementing `IEnumerator<T>` requires an implementation of `IEnumerator`
            object IEnumerator.Current => this.Current;   // Explicit interface specifications don't have any access specifiers

            public LinkedListEnumerator(Node<TData> head)
            {
                _current = _start = new Node<TData>(default(TData));
                _start.Next = _current.Next = head;
            }

            public bool MoveNext()
            {
                bool keepGoing = true;

                if (_current.Next is null)
                    keepGoing = false;

                _current = _current.Next;
                
                return keepGoing;
            }

            public void Reset()
            {
                _current = _start;
            }

            void IDisposable.Dispose(){}
        }
    }
}