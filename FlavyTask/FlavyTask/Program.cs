using System;
using System.Collections.Generic;
using System.Linq;

namespace FlavyTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the number of people");
            int number = Convert.ToInt32(Console.ReadLine());
            IEnumerable<int> list = new List<int>(Enumerable.Range(1, number));
            //var peopleList = new Elements(list);
            //peopleList.

        }
    }

}
