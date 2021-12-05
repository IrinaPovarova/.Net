using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collection3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 3;

            var list = new LinkedList<int>(Enumerable.Range(1, N));
            Console.WriteLine(string.Join(" ", list));
            var currentItem = list.First;
            while (list.Count != 1)
            {
                list.Remove(currentItem.Next ?? list.First);
                currentItem = currentItem.Next ?? list.First;
            }
            Console.WriteLine(list.First.Value);

            Console.ReadKey();
        }
    }
}

