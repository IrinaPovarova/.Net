using System;
using System.Collections.Generic;
using OOP.Meals;
using System.Text;

namespace OOP
{
    class Compote : MealBase
    {
        public Compote(FoodBase[] products) : base(products)
        {
            MealName = "Compote";
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"{MealName}:");
        }
        public override void Cook()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("How to cook compote:");
            Console.WriteLine("Boil water");
            Console.WriteLine("Add Strawberry, Sugar");
        }
    }
}
