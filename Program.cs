using System;
using CollectionTypes;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.AddTail(i);
            }

            Console.WriteLine(list);
        }
    }
}
