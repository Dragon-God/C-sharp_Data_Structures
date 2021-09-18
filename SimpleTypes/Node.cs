namespace SimpleTypes
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
}