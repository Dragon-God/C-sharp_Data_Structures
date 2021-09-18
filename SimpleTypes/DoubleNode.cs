namespace SimpleTypes
{
    public class DoubleNode <TData>
    {
        public TData Data { get; set; }
        public DoubleNode <TData> Next { get; set; }
        public DoubleNode <TData> Previous { get; set; }

        public DoubleNode () { }
        public DoubleNode (TData data)
        {
            Data = data;
        }
    }
}