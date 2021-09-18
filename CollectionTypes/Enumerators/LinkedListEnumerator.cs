using System;
using System.Collections.Generic;
using System.Collections;

using SimpleTypes;

namespace CollectionTypes
{
    public partial class LinkedList<TData, TNode>
    {
        internal class LinkedListEnumerator: IEnumerator<TNode>
        {
            private TNode _current;
            private readonly TNode _start;

            public TNode Current => _current;
            
            // Implementing `IEnumerator<T>` requires an implementation of `IEnumerator`
            object IEnumerator.Current => this.Current;   // Explicit interface specifications don't have any access specifiers

            public LinkedListEnumerator(TNode head)
            {
                _current = _start = new TNode() { Data = default(TData) };
                _start.Next = _current.Next = head;
            }

            public bool MoveNext()
            {
                bool keepGoing = true;

                if (_current.Next is null)
                    keepGoing = false;

                _current = (TNode)_current.Next;
                
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