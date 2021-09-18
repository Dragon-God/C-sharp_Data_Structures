namespace SimpleTypes
{
    public class DoubleNode<TData>: Node<TData>
    {
        public new DoubleNode <TData> Next { get; set; }
        public DoubleNode <TData> Previous { get; set; }

        public DoubleNode () { }
        public DoubleNode (TData data): base(data) {}
    }
}