using System;

namespace Indeksators
{
    class Program
    {
        static void Main(string[] args)
   {

            /*  var item = new SaleItem { Name = "Shoes", Price = 19.95m };
                Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
                People people = new People();
                people[0] = new Person { Name = "Tom" };
                people[1] = new Person { Name = "Bob" };

                Person tom = people[0];
                Console.WriteLine(tom?.Name); 
            var tempRecord = new TempRecord();

            // Use the indexer's set accessor
            tempRecord[3] = 58.3F;
            tempRecord[5] = 60.1F;

            // Use the indexer's get accessor
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Element #{i} = {tempRecord[i]}");
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");*/
            
            var week = new DayCollection();
            Console.WriteLine(week["Fri"]);

            try
            {
                Console.WriteLine(week["Made-up day"]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Not supported input: {e.Message}");
            }

        }
    }
}
