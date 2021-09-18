using System.Collections.Generic;
using System.Collections;

using SimpleTypes;

namespace CollectionTypes.Enumerators
{
    internal class LinkedListEnumerator<TData, TNode>: IEnumerator<TNode> where TNode: Node<TData>, new()
    {
        private TNode _current;
        private readonly TNode _start;

        public TNode Current { get => _current; }
        
        // Implementing `IEnumerator<T>` requires an implementation of `IEnumerator`
        object IEnumerator.Current { get => this.Current; }    // Explicit interface specifications don't have any access specifiers

        public LinkedListEnumerator(Node<TData> head)
        {
            _current = _start = (TNode)new Node<TData>(default(TData));
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