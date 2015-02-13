using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Figure
    {
        Point pointa, pointb, pointc, pointd, pointe;
        double perimeter;//, LengthSide1, LengthSide2, LengthSide3, LengthSide4, LengthSide5;

        public double Perimeter
        {
            get
            {
                if (perimeter != null)
                    return perimeter;
                else
                    return 0;
            }
        }

        public Figure(Point pointa, Point pointb, Point pointc, Point pointd = null, Point pointe = null)
        {
            this.pointa = pointa;
            this.pointb = pointb;
            this.pointc = pointc;
            this.pointd = pointd;
            this.pointe = pointe;
            this.PerimeterCalculator();
        }

        public double LengthSide(Point A, Point B)
        {
            if (A == null || B == null)
                return 0;
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y,2));
        }

        public void PerimeterCalculator()
        {
            //double perimeter;
            if ((pointd == null) && (pointe == null))
            {
                this.perimeter = LengthSide(pointa, pointb) + LengthSide(pointb, pointc) + LengthSide(pointc, pointa);
            }
            else if (pointd == null)
	        {
                this.perimeter = LengthSide(pointa, pointb) + LengthSide(pointb, pointc) + LengthSide(pointc, pointe) + LengthSide(pointe, pointa);
	        }
            else if (pointe == null)
	        {
                this.perimeter = LengthSide(pointa, pointb) + LengthSide(pointb, pointc) + LengthSide(pointc, pointd) + LengthSide(pointd, pointa);
	        }
            else
                this.perimeter = LengthSide(pointa, pointb) + LengthSide(pointb, pointc) + LengthSide(pointc, pointd) + LengthSide(pointd, pointe) + LengthSide(pointe, pointa);
            //this.perimeter = perimeter;

            //return (LengthSide(pointa, pointb) + LengthSide(pointb, pointc) + LengthSide(pointc, pointd) + LengthSide(pointd, pointe) + LengthSide(pointe, pointa));
        }
    }
}
