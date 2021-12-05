using System;
using System.Collections.Generic;
using System.Text;

namespace Indeksators
{
    class People
    {
        Person[] data;
        public People()
        {
            data = new Person[5];
        }
        // индексатор
        public Person this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
    }
}
