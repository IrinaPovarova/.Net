using System;
using System.Collections.Generic;
using System.Text;

namespace Lambda
{
    class UserInfo
    {
            public string Name { get; private set; }
            public string Family { get; private set; }
            public decimal Salary { get; private set; }

            public UserInfo(string Name, string Family, decimal Salary)
            {
                this.Name = Name;
                this.Family = Family;
                this.Salary = Salary;
            }
        // Переопределим метод ToString
        public override string ToString()
            {
                return string.Format("{0} {1}, {2:C}", Name, Family, Salary);
            }
        // Данный метод введен для соответствия сигнатуре 
        // делегата Func
        public static bool UserSalary(UserInfo obj1, UserInfo obj2)
            {
            return obj1.Salary < obj2.Salary;
            }
    }
}
