using System;

using SimpleTypes;

namespace CollectionTypes
{
    public class DoublyLinkedList<TData>: LinkedList<TData, DoubleNode<TData>>
    {
        public DoublyLinkedList(): base() {}

        #region Linked List API
        protected override void VariantAddHeadNode(DoubleNode<TData> newHead)
        {
            Head.Previous = newHead;
        }

        protected override void VariantAddTailNode(DoubleNode<TData> newTail)
        {
            newTail.Previous = Tail;
        }

        protected override void VariantAddNodeAfter(DoubleNode<TData> target, DoubleNode<TData> newNode)
        {
            newNode.Previous = target;
        }

        protected override void VariantRemoveHeadNode()
        {
            Head.Next.Previous = null;
        }

        protected override void VariantRemoveNodeAfter(DoubleNode<TData> target)
        {
            target.Next.Previous = null;
        }

        public void RemoveTailNode()
        {
            if (Tail is null)
                throw new InvalidOperationException("Can't remove from an empty list!");
            
            Tail = Tail.Previous;
            Tail.Next = null;
        }
        #endregion
    }
}