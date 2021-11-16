using System;
using System.Collections.Generic;
using OOP.Meals;
using System.Text;

namespace OOP
{
    class Dinner : ICook
    {
        public List<MealBase> Meals { get; set; }

        public void Cook()
        {
            foreach (MealBase meal in Meals)
            {
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"{meal.MealName} - List of products:");
                meal.ShowComponents();
                meal.GetTotalCalories();
                meal.GetTotalWeight();
                meal.Cook();
            }
        }
    }
}
