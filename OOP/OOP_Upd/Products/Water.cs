using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Water : FoodBase
    {
        public Water(int weight)
        {
            Name = "Water";
            Calories = 0;
            Weight = weight;
        }

        public override ProductType ProductType => ProductType.Water;

    }
}
