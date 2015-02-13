using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Point
    {
        int x, y;
        string name;

        public Point(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
        
        public int X
        {
            get {return x;}
        }

        public int Y
        {
            get {return y;}
        }

        public string Name
        {
            get {return name;}
        }        
    }
}
