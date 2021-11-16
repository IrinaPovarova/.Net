using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class SunFlowerOil : FoodBase
    {

        public SunFlowerOil(int weight)
        {
            Name = "SunFlowerOil";
            Calories = 900;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Additions;

    }
}
