using System;
using System.Linq;
using System.Collections.Generic;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfo[] userinfo = { new UserInfo("Dmitry","Medvedev",50000000000),
                                  new UserInfo("Alex","Erohin",100),
                                  new UserInfo("Alexey","Volkov",40000),
                                  new UserInfo("Wiley","Coyote",1000000)};

            ArrSort.Sort(userinfo, UserInfo.UserSalary);

            Console.WriteLine("Сортируем исходный объект по доходу: \n" +
                "-------------------------------------\n");
            foreach (var ui in userinfo)
                Console.WriteLine(ui);

            Console.ReadLine();
        }
    }
}
