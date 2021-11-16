using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Sugar : FoodBase
    {
        public Sugar(int weight)
        {
            Name = "Sugar";
            Calories = 400;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Additions;

    }
}
