using System;
using System.Collections;
using System.Collections.Generic;

using SimpleTypes;
using CollectionTypes.Enumerators;

namespace CollectionTypes
{
    public class LinkedList<TData, TNode>: IEnumerable<TNode> where TNode: Node<TData>, new()
    {
        public Node<TData> Head { get; set; }
        public Node<TData> Tail { get; set; }

        public LinkedList()
        {
            Head = Tail = null;
        }

        #region List API
        public void AddHeadNode(TData data)
        {
            Node<TData> newHead = new Node<TData>(data);

            if (Head is null)
                Tail = newHead;
            else
                newHead.Next = Head;
            
            Head = newHead;
        }

        public void AddTailNode(TData data)
        {
            Node<TData> newTail = new Node<TData>(data);

            if (Tail is null)
                Head = newTail;
            else
                Tail.Next = newTail;

            Tail = newTail;
        }

        public void AddNodeAfter(Node<TData> target, TData data)
        {
            Node<TData> newNode = new Node<TData>(data);

            newNode.Next = target.Next;
            target.Next = newNode;
        }

        public void RemoveHeadNode()
        {
            if (Head is null)
                throw new InvalidOperationException("Can't remove from an empty list!");
            
            Head = Head.Next;
        }

        public void RemoveNodeAfter(Node<TData> target)
        {
            if (target is null || target.Next is null)
                return;

            target.Next = target.Next.Next;
        }
        #endregion
        
        #region Interface Implementations
        public IEnumerator<TNode> GetEnumerator()
        {
            return (IEnumerator<TNode>)new LinkedListEnumerator<TData, Node<TData>>(Head);
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