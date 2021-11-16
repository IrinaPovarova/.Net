using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Products
{
    class Strawberry : FoodBase
    {
        public Strawberry(int weight)
        {
            Name = "Strawberry";
            Calories = 30;
            Weight = weight;
        }
        public override ProductType ProductType => ProductType.Berries;

    }
}
