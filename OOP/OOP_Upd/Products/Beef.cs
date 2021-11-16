using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    internal class Beef : FoodBase
    {
        public Beef(int weight)
        {
            Name = "Beef";
            Calories = 250;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Meat;

    }
}
