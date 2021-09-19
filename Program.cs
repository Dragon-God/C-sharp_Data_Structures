using System;

using SimpleTypes;
using CollectionTypes;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int, Node<int>> list = new LinkedList<int, Node<int>>();
            list.AddHeadNode(new Node<int>(0));

            for (int i = 1; i < 10; i++)
            {
                list.AddTailNode(new Node<int>(i));
            }
            Console.WriteLine(list);

            Node<int> current = list.Head;
            for (int i = 0; i < 10; i++, current = current.Next.Next)
            {
                list.AddNodeAfter(current, new Node<int>(0 - current.Data));
            }
            Console.WriteLine(list);

            foreach (Node<int> node in list)
            {
                if (node.Data >= 0)
                    list.RemoveNodeAfter(node);
            }
            Console.WriteLine(list);
        }
    }
}
