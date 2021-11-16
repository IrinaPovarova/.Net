using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Cabbage : FoodBase
    {
        public Cabbage(int weight)
        {
            Name = "Cabbage";
            Calories = 30;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Vegetables;

    }
}
