namespace Shell
{
    public class Node<TData>
    {
        public TData Data { get; set; }
        public Node<TData> Next { get; set; }

        public Node() { }
        public Node(TData data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class DoubleNode<TData>: Node<TData>
    {
        public new DoubleNode <TData> Next { get; set; }
        public DoubleNode <TData> Previous { get; set; }

        public DoubleNode () { }
        public DoubleNode (TData data): base(data) {}
    }

    public class LinkedList<TData, TNode> where TNode: Node<TData>
    {
        public TNode Head { get; internal set; }
        public TNode Tail { get; internal set; }

        public LinkedList()
        {
            Head = Tail = null;
        }

        // Non virtual interface pattern
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
    }
    
    public class DoublyLinkedList<TData>: LinkedList<TData, DoubleNode<TData>>
    {
        public DoublyLinkedList(): base() {}

        // The variant processing necessary to implement the API in a doubly linked list.
        protected override void VariantAddHeadNode(DoubleNode<TData> newHead)
        {
            Head.Previous = newHead;
        }
    }
}