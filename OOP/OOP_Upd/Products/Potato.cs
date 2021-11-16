using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Potato : FoodBase
    {

        public Potato(int weight)
        {
            Name = "Potato";
            Calories = 80;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Vegetables;

    }
}
