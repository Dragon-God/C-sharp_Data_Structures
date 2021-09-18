namespace SimpleTypes
{
    public class SingleNode<TData>: Node<TData>
    {
        public SingleNode() { }
        public SingleNode(TData data): base(data) { }
    }
}