using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 test1 = new Class1();
            Class1 test2 = new Class1();
            Class1 test3 = new Class1();
            Class1 test4 = new Class1();
            Class1 test5 = new Class1();
            Class1 test6 = new Class1();
            Class2 test00 = new Class2();
            test00.test = test6;

            List<Class1> TestList = new List<Class1>();

            TestList.Add(test1);
            TestList.Add(test2);
            TestList.Add(test3);
            TestList.Add(test4);
            TestList.Add(test5);
            TestList.Add(test6);

            
            //IEnumerable<Class1>
            Console.WriteLine("After init");
            Console.WriteLine("test1 SA ID: {0}; Description: {1}.", test1.id,test1.description);
            Console.WriteLine("test2 SA ID: {0}; Description: {1}.", test2.id,test2.description);
            Console.WriteLine("test3 SA ID: {0}; Description: {1}.", test3.id,test3.description);
            Console.WriteLine("test4 SA ID: {0}; Description: {1}.", test4.id,test4.description);
            Console.WriteLine("test5 SA ID: {0}; Description: {1}.", test5.id,test5.description);
            Console.WriteLine("test6 SA ID: {0}; Description: {1}.", test6.id,test6.description);

            Console.WriteLine("test1 in List ID: {0}; Description: {1}.", TestList[0].id,TestList[0].description);
            Console.WriteLine("test2 in List ID: {0}; Description: {1}.", TestList[1].id,TestList[1].description);
            Console.WriteLine("test3 in List ID: {0}; Description: {1}.", TestList[2].id,TestList[2].description);
            Console.WriteLine("test4 in List ID: {0}; Description: {1}.", TestList[3].id,TestList[3].description);
            Console.WriteLine("test5 in List ID: {0}; Description: {1}.", TestList[4].id,TestList[4].description);
            Console.WriteLine("test6 in List ID: {0}; Description: {1}.", TestList[5].id,TestList[5].description);

            Console.WriteLine("List altering");

            TestList[0].description = "listtest1";
            TestList[1].description = "listtest2";
            TestList[2].description = "listtest3";
            TestList[3].description = "listtest4";
            TestList[4].description = "listtest5";
            TestList[5].description = "listtest6";

            Console.WriteLine("test1 SA ID: {0}; Description: {1}.", test1.id,test1.description);
            Console.WriteLine("test2 SA ID: {0}; Description: {1}.", test2.id,test2.description);
            Console.WriteLine("test3 SA ID: {0}; Description: {1}.", test3.id,test3.description);
            Console.WriteLine("test4 SA ID: {0}; Description: {1}.", test4.id,test4.description);
            Console.WriteLine("test5 SA ID: {0}; Description: {1}.", test5.id,test5.description);
            Console.WriteLine("test6 SA ID: {0}; Description: {1}.", test6.id,test6.description);

            Console.WriteLine("test1 in List ID: {0}; Description: {1}.", TestList[0].id,TestList[0].description);
            Console.WriteLine("test2 in List ID: {0}; Description: {1}.", TestList[1].id,TestList[1].description);
            Console.WriteLine("test3 in List ID: {0}; Description: {1}.", TestList[2].id,TestList[2].description);
            Console.WriteLine("test4 in List ID: {0}; Description: {1}.", TestList[3].id,TestList[3].description);
            Console.WriteLine("test5 in List ID: {0}; Description: {1}.", TestList[4].id,TestList[4].description);
            Console.WriteLine("test6 in List ID: {0}; Description: {1}.", TestList[5].id,TestList[5].description);

            Console.WriteLine("test6 in test00 ID: {0}; Description: {1}.", test00.test.id, test00.test.description);
            test00.test.description = "taratata";

            Console.WriteLine("Altering in class");
            Console.WriteLine("test6 SA ID: {0}; Description: {1}.", test6.id, test6.description);
            Console.WriteLine("test6 in test00 ID: {0}; Description: {1}.", test00.test.id, test00.test.description);
            Console.WriteLine("test6 SA ID: {0}; Description: {1}.", test6.id, test6.description);


            Console.ReadKey();

        }
    }
}
