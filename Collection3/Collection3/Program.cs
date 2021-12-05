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

            var list = new List<int>(Enumerable.Range(1, N));
            Console.WriteLine(string.Join(" ", list));
            var currentItem = list[0];
            int i = 0;
            while (list.Count != 1)
            {
                list.Remove(list[i+1] ?? list[i]);
                currentItem = currentItem.Next ?? list.First;
            }
            Console.WriteLine(list.First.Value);

            Console.ReadKey();
        }
    }
}
