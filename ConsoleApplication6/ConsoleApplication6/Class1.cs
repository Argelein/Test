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
            int rand = rnd.Next(1, 1000);
            this.id = rand;
            this.description = "init";
        }
    }
    class Class2
    {
        //field
        public int id;
        public Class1 test;
        Random rnd = new Random();
        public string description;

        //constructor
        public Class2()
        {
            int rand = rnd.Next(1, 1000);
            this.id = rand;
            this.description = "init2";
        }
    }
}
