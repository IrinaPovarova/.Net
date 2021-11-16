using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Onion : FoodBase
    {
        public Onion(int weight)
        {
            Name = "Onion";
            Calories = 40;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Vegetables;

    }
}
