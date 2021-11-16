using System;
using OOP.Meals;
using System.Collections.Generic;
using System.Text;
namespace OOP
{
    class Stake : MealBase
    {
        public Stake(FoodBase[] products) : base(products)
        {
            MealName = "Stake";
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"{MealName}:");
        }
        public override void Cook()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("How to cook stake:");
            Console.WriteLine("Cut Meat");
            Console.WriteLine("Add Salt, Peper, Sun Flower Oil");
            Console.WriteLine("Fry");
        }
    }
}
