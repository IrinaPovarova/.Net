using System;
using System.Linq;
using System.Collections.Generic;
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of people");
            int number = Convert.ToInt32(Console.ReadLine());
            var list = new List<int>(Enumerable.Range(1, number));
            var personNumber = ListProcessor.DeleteEvenNumbersOfPeople(list);
            Console.WriteLine($"Last Person number in the list {personNumber}");

            var linkedlist = new LinkedList<int>(Enumerable.Range(1, number));
            var peopleLinkedList = new ListLinked(linkedlist);
            personNumber = ListProcessor.DeleteEvenNumbersOfPeople(list);
            Console.WriteLine($"Last Person number in the linkedlist  {personNumber}");

            var myArray = new DynamicArray<int>();
            Console.WriteLine(myArray.Capacity);
            myArray.Add(1);
            Console.WriteLine(myArray.ToString());
            var myRange = new int[4] { 0, 1, 2, 3 };
            myArray.AddRange(myRange);
            Console.WriteLine(myArray.ToString());

            myArray = new DynamicArray<int>(6);
            Console.WriteLine(myArray.Capacity);
            myArray.Add(1);
            Console.WriteLine(myArray.ToString());
            myRange = new int[4] { 4, 5, 6, 7 };
            myArray.AddRange(myRange);
            Console.WriteLine(myArray.ToString());

            myArray = new DynamicArray<int>(new int[] { 8, 12, 3, 6, 5 });
            Console.WriteLine(myArray[3]);
            Console.WriteLine(myArray.ToString());
            myArray.Sort((element1, element2) => element1 < element2);
            Console.WriteLine(myArray.ToString());

            Console.WriteLine(myArray.Capacity);
            Console.WriteLine(myArray.ToString());
            myArray.Add(6);
            Console.WriteLine(myArray.ToString());
            myArray.Remove(1);
            Console.WriteLine(myArray.ToString());
            myRange = new int[4] { 8, 9, 10, 11 };
            myArray.AddRange(myRange);
            Console.WriteLine(myArray.ToString());
            myArray.Insert(7, 2);
            Console.WriteLine($"{myArray.ToString()} \n");

            var players = new DynamicArray<Player>(new Player[] {
                new Player() {FirstName= "Tom", LastName = "Johnse", Level = 8  },
                new Player() { FirstName = "Max", LastName = "Broen", Level = 6 },
                new Player() { FirstName = "Kate", LastName = "Li", Level = 5 },
                new Player() { FirstName = "Liz", LastName = "Ten", Level = 4 },
                new Player() { FirstName = "Mary", LastName = "Popins", Level = 9 },
                new Player() { FirstName = "Tom", LastName = "Cruize", Level = 7},
                new Player() { FirstName = "Joan", LastName = "Froggatt", Level = 6 },
                new Player() { FirstName = "Bred", LastName = "Pitt", Level = 8},
            });
            Console.WriteLine(players);
            players.Sort((element1, element2) => element1.Level > element2.Level);

            double sum = 0;

            for (int i = 0; i < players.Lenght; i++)
            {
                sum = sum + players[i].Level;
            }
            double average = sum / players.Lenght;
            var teams = players.Split((element1, element2) => (element1.Level + element2.Level) / 2.0 >= average - 0.5 && (element1.Level + element2.Level) / 2.0 <= average + 0.5);
            var isSecond = false;
            foreach (var item in teams)
            {
                Console.Write($"{item.Key} - {item.Value}");
                if (isSecond)
                {
                    Console.WriteLine();
                }
                isSecond = !isSecond;
            }
           
        }
    }
}  
