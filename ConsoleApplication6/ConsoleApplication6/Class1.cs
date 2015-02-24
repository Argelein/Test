using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Class1
    {
        //field
        public int id;
        public string description;
        Random rnd = new Random();
        //constructor
        public Class1()
        {
            this.id = rnd.Next(1, 1000);
            this.description = "init";
        }
    }
}
