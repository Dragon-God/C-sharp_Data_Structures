using System.Collections.Generic;
using System.Collections;

using SimpleTypes;

namespace CollectionTypes.Enumerators
{
    internal class LinkedListEnumerator<TData>: IEnumerator<TData>
    {
        private Node<TData> _current;
        private readonly Node<TData> _start;
        private bool _isDisposed;

        public TData Current { get => _current.Data; set { _current.Data = value; } }
        
        // Implementing `IEnumerator<T>` requires an implementation of `IEnumerator`
        object IEnumerator.Current { get => this.Current; }    // Explicit interface specifications don't have any access specifiers

        public LinkedListEnumerator(Node<TData> head)
        {
            _current = _start = new Node<TData>(default(TData));
            _start.Next = _current.Next = head;
            _isDisposed = false;
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

        public void Dispose()
        {
            // Dispose of unmanaged resources
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;
            
            if (disposing)
            {
                // Dispose of managed resources
            }

            _current = null;
            _isDisposed = true;
        }

        ~LinkedListEnumerator()
        {
            Dispose(false);
        }
    }
}