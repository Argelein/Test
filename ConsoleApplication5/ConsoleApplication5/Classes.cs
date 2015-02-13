using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Hero
    {
        int XCoord, YCoord;
        public Hero()
        {
            this.XCoord = 0;
            this.YCoord = 0;
        }

        public Hero(World World)
        {
            this.XCoord = (int)((World.GetSize())[0] / 2);
            this.YCoord = (int)((World.GetSize())[1] / 2);
        }

        public Hero(World World, int XCoord, int YCoord)
        {
            this.XCoord = XCoord;
            this.YCoord = YCoord;
        }

        public Hero(World World, int[] Coords)
            : this(World, Coords[0], Coords[1])
        {

        }

        public int[] GetCoords()
        {
            int[] Coords = { this.XCoord, this.YCoord };
            return Coords;
        }
        public int Move(int Direction)
        {
            switch (Direction)
            {
                case 1:
                    this.XCoord--;
                    this.YCoord++;
                    return 0;
                case 2:
                    this.YCoord++;
                    return 0;
                case 3:
                    this.XCoord++;
                    this.YCoord++;
                    return 0;
                case 4:
                    this.XCoord--;
                    return 0;
                case 5:
                    return 0;
                case 6:
                    this.XCoord++;
                    return 0;
                case 7:
                    this.XCoord--;
                    this.YCoord--;
                    return 0;
                case 8:
                    this.YCoord--;
                    return 0;
                case 9:
                    this.XCoord++;
                    this.YCoord--;
                    return 0;
                default:
                    return 0;
            }
        }
    }
    class Enemy
    {
        int x, y;
    }
}
