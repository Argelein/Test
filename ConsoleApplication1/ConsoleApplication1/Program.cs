using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(1, 1, "A");
            Point B = new Point(1, 2, "B");
            Point C = new Point(2, 2, "C");
            Point D = new Point(2, 1, "D");
            //Point E = new Point(3, 2, "E");
            Figure Figure = new Figure(A, B, C, D);//, E);
            Point[] points = { A, B, C, D };//, E };
            Figure1 Figure1 = new Figure1(points);

            //Figure.PerimeterCalculator();
            //Figure1.PerimeterCalculator();

            Console.WriteLine("Figure perimeter {0}", Figure.Perimeter);
            Console.WriteLine("Figure1 perimeter {0}", Figure1.Perimeter);
            Console.ReadKey();
        }
    }
}
