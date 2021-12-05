using System;
using System.Collections.Generic;
using System.Text;

namespace Collection1
{
    class Person
    {
        public Person(int position)
        {
            Position = position;
        }

        public int Position { get; private set; }

        public Person NextPerson { get; set; }
    }
}
