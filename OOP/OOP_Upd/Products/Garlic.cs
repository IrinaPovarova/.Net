using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Garlic : FoodBase
    {
        public Garlic(int weight)
        {
            Name = "Garlic";
            Calories = 25;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Vegetables;

    }
}
