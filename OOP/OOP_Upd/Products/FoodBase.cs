using OOP.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public abstract class FoodBase
    {
        public int Weight { get; set; }

        public double Calories { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            var strProduct = $"{Name} -Product type: {ProductType} Product weight {Weight}g";
            Console.WriteLine(strProduct);
            return strProduct;
        }
        public abstract ProductType ProductType { get; }

    }
}
