using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Salt : FoodBase
    {
        public Salt(int weight)
        {
            Name = "Salt";
            Calories = 0;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Additions;

    }
}
