using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Beet : FoodBase
    {

        public Beet(int weight)
        {
            Name = "Beet";
            Calories = 46;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Vegetables;

    }
}
