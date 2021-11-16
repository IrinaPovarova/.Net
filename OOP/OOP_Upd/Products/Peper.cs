using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Peper : FoodBase
    {
        public Peper(int weight)
        {
            Name = "Peper";
            Calories = 25;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Additions;

    }
}
