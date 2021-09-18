using System;
using System.Collections;
using System.Collections.Generic;

using SimpleTypes;

namespace CollectionTypes
{
    public partial class LinkedList<TData, TNode>: IEnumerable<TNode> where TNode: Node<TData>, new()
    {
        public TNode Head { get; internal set; }
        public TNode Tail { get; internal set; }

        public LinkedList()
        {
            Head = Tail = null;
        }

        #region List API
        public void AddHeadNode(TData data)
        {
            TNode newHead = new TNode() { Data = data };

            if (Head is null)
                Tail = newHead;
            else
                newHead.Next = Head;
            
            Head = newHead;
        }

        public void AddTailNode(TData data)
        {
            TNode newTail = new TNode() { Data = data };

            if (Tail is null)
                Head = newTail;
            else
                Tail.Next = newTail;

            Tail = newTail;
        }

        public void AddNodeAfter(TNode target, TData data)
        {
            TNode newTNode = new TNode() { Data = data };

            newTNode.Next = target.Next;
            target.Next = newTNode;
        }

        public void RemoveHeadNode()
        {
            if (Head is null)
                throw new InvalidOperationException("Can't remove from an empty list!");
            
            Head = (TNode)Head.Next;
        }

        public void RemoveNodeAfter(TNode target)
        {
            if (target is null || target.Next is null)
                return;

            target.Next = target.Next.Next;
        }
        #endregion
        
        #region Interface Implementations
        public IEnumerator<TNode> GetEnumerator()
        {
            return new LinkedListEnumerator(Head);
        }

        // Implementing `IEnumerable<T>` requires an implementation of `IEnumerable`
        IEnumerator IEnumerable.GetEnumerator()    // Explicit interface specifications don't have any access specifiers
        {
            return this.GetEnumerator();
        }
        #endregion

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}