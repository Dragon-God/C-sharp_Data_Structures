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

        #region Linked List API
        // Non virtual interface pattern: https://en.wikipedia.org/wiki/Non-virtual_interface_pattern
        // See also: https://en.wikipedia.org/wiki/Template_method_pattern
        // We define `protected virtual` methods that contain the variant implementations of the linked list API.
        // The invariant processing necessary for the API is implemented in our `public` methods.
        // The variant processing necessary to implement the API can be implemented by the derived classes in the hook methods.

        protected virtual void VariantAddHeadNode(TNode newHead) { }
        public void AddHeadNode(TNode newHead)
        {
            if (Head is null)
                Tail = newHead;
            else
            {
                VariantAddHeadNode(newHead);
                newHead.Next = Head;
            }
            
            Head = newHead;
        }

        protected virtual void VariantAddTailNode(TNode newTail) { }
        public void AddTailNode(TNode newTail)
        {
            if (Tail is null)
                Head = newTail;
            else
            {
                VariantAddTailNode(newTail);
                Tail.Next = newTail;
            }

            Tail = newTail;
        }
        
        protected virtual void VariantAddNodeAfter(TNode target, TNode newNode) { }
        public void AddNodeAfter(TNode target, TNode newNode)
        {
            VariantAddNodeAfter(target, newNode);

            newNode.Next = target.Next;
            target.Next = newNode;
        }

        protected virtual void VariantRemoveHeadNode() { }
        public void RemoveHeadNode()
        {
            if (Head is null)
                throw new InvalidOperationException("Can't remove from an empty list!");
            
            VariantRemoveHeadNode();
            Head = (TNode)Head.Next;
        }

        protected virtual void VariantRemoveNodeAfter(TNode target) { }
        public void RemoveNodeAfter(TNode target)
        {
            if (target is null || target.Next is null)
                return;

            VariantRemoveNodeAfter(target);
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