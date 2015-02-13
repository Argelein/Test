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
            int test4000 = 4000;
            int test400 = 400;
            int test40 = 40;
            int test4 = 4;
            Console.WriteLine("int |{0}|, string |{1}|", test4000, test4000.ToString());
            Console.WriteLine("int |{0}|, string |{1}|", test400, test400.ToString());
            Console.WriteLine("int |{0}|, string |{1}|", test40, test40.ToString());
            Console.WriteLine("int |{0}|, string |{1}|", test4, test4.ToString());
            //test40 = 4;
            Console.WriteLine("lengtht |{0}|", test40.ToString().Length);
            Console.WriteLine("int |{0}|, string |{1}|, chars |{2}|{3}|", test40, test40.ToString(), test40.ToString()[0], test40.ToString()[1]);
            //Console.WriteLine("int |{0}|, string |{1}|, chars |{2}|{3}|{4}|{5}|", test4, test4.ToString(), test4.ToString()[0],test4.ToString()[1], test4.ToString()[2], test4.ToString()[3]);

            Console.ReadKey();

        }
    }
}
