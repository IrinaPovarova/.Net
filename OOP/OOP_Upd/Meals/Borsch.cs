using OOP.Meals;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Borsch : MealBase
    {
        
        public Borsch(FoodBase[] products) : base(products)
        {
            MealName = "Borsch";
            Console.WriteLine($"Cook dinner");
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"{MealName}:");
        }

        public void FindPoductWieghInIntervalForBorsch()
        {
            int count = 0;
            Console.WriteLine("Enter min weight");
            int setMinWeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter max weight");
            int setMaxWeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Product weight in Borsch within the defined interval [{setMinWeight} - {setMaxWeight}]g");
            foreach (var item in _products)
            {
                if (item.Weight >= setMinWeight & item.Weight <= setMaxWeight)
                {
                    Console.WriteLine($"{item.Name} - {item.Weight}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No products with weight in the defined interval");
            }
        }

        public override void Cook()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("How to cook borsch:");
            Console.WriteLine("Boil Meat");
            Console.WriteLine("Cut Cabbage, Carrot, Onion, Potato, Beet");
            Console.WriteLine("Fry Carrot, Onion in Sun Flower Oil");
            Console.WriteLine("Boil Cabbage, Carrot, Onion, Potato, Beet");
            Console.WriteLine("Add Salt, Peper, Sour Cream");
        }
    }
}
