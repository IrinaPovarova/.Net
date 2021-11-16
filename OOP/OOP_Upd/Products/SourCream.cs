using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class SourCream : FoodBase
    {
        public SourCream(int weight)
        {
            Name = "SourCream ";
            Calories = 200;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Additions;
    }
}
