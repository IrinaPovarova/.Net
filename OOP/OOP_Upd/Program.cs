using OOP.Meals;
using OOP.Products;
using System;
using System.Collections.Generic;

namespace OOP
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var listForBorsch = new FoodBase[]
            {
                new Water(1500),
                new Beef(500),
                new Potato(300),
                new Cabbage(200),
                new Beet(200),
                new Carrot(200),
                new Onion(100),
                new SunFlowerOil(50),
                new Peper(5),
                new Salt(20),
                new SourCream(100),
                new Garlic(0)
            };
            var borsch = new Borsch(listForBorsch);
            var mealname = borsch.MealName;
            borsch.FindPoductWieghInIntervalForBorsch();

            var listForSalad = new FoodBase[]
            {
                new Cabbage(500),
                new Carrot(100),
                new Onion(50),
                new SunFlowerOil(100),
                new Peper(10),
                new Salt(15)
            };
            var salad = new Salad(listForSalad);
            mealname = salad.MealName;
            salad.SortPoductInSaladByCalories();

            var listForStake = new FoodBase[]
            {
                new Beef(700),
                new SunFlowerOil(50),
                new Peper(10),
                new Salt(20)
            };
            var stake = new Stake(listForStake);
            mealname = stake.MealName;

            var listForCompote = new FoodBase[]
            {
                new Water(2000),
                new Strawberry(500),
                new Sugar(50)
            };
            var compote = new Compote(listForCompote);
            mealname = compote.MealName;

            var dinner = new Dinner()
            {
                Meals = new List<MealBase> { borsch, salad, stake, compote }
            };
            dinner.Cook();

        }
    }
}
