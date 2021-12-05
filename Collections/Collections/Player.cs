using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {

            return $"{FirstName} {LastName} - {Level}\n";
        }
    }
}
