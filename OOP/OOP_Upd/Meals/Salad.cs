using System;
using OOP.Meals;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Salad : MealBase
    {
        public string productType { get; set; }
        public Salad(FoodBase[] products) : base(products)
        {
            MealName = "Salad";
            Console.WriteLine("**********************************************************");
            Console.WriteLine($"{MealName}:");
        }
        public void SortPoductInSaladByCalories()
        {

            double ctemp;
            string ptemp;
            int count = 0;
            var listCalories = new List<double>();
            var listProducs = new List<string>();
            int[] rnd_array = new int[20];
            foreach (var item in _products)
            {
                if (item.ProductType == Products.ProductType.Vegetables)
                {
                    listCalories.Add(item.Calories);
                    listProducs.Add(item.Name);
                    count++;
                }
            }
            var calories_array = listCalories.ToArray();
            var products_array = listProducs.ToArray();

            for (int i = 0; i <= count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (calories_array[i] > calories_array[j])
                    {
                        ctemp = calories_array[i];
                        ptemp = products_array[i];
                        calories_array[i] = calories_array[j];
                        products_array[i] = products_array[j];
                        calories_array[j] = ctemp;
                        products_array[j] = ptemp;
                    }
                }
            }

            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Products in salad sorted by calories:");
            for (int i = 0; i < count+1; i++)
            {
                try
                {
                    Console.WriteLine($"{products_array[i]} - {calories_array[i]}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error occured: {ex.Message}");
                }
            }
        }
        public override void Cook()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("How to cook salad:");
            Console.WriteLine("Cut Cabbage, Carrot, Onion");
            Console.WriteLine("Add Salt, Peper, Sun Flower Oil");
        }
    }
}
