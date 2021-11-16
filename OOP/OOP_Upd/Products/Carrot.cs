using System;
using System.Collections.Generic;
using System.Text;
using OOP.Meals;

namespace OOP.Products
{
    class Carrot : FoodBase
    {
        public Carrot(int weight)
        {
            Name = "Carrot";
            Calories = 50;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Vegetables;

    }
}
