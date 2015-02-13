using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class Person : Creature
    {
        //fields
        int XCoord,YCoord, hp, maxhp;
        //readonly int WorldXSize, WorldYSize;

        //constructors:
        private Person() : base() { }
        public Person(ref World World) : base(ref World) { World.MainCharacter = this; }
        public Person(ref World World, int XCoord, int YCoord) : base(ref World, XCoord, YCoord) { World.MainCharacter = this; }
        public Person(ref World World, int[] Coords) : base(ref World, Coords) { World.MainCharacter = this; }
        public Person(ref World World, int XCoord, int YCoord, int maxhp) : base(ref World, XCoord, YCoord, maxhp) { World.MainCharacter = this; }
        public Person(ref World World, int[] Coords, int maxhp) : base(ref World, Coords, maxhp) { World.MainCharacter = this; }

        //methods
        public override void Hit(int Direction)
        {
            switch (Direction)
            {
                case 1:
                    this.XCoord--;
                    this.YCoord++;
                    break;
                case 2:
                    this.YCoord++;
                    break;
                case 3:
                    this.XCoord++;
                    this.YCoord++;
                    break;
                case 4:
                    this.XCoord--;
                    break;
                case 5:
                    break;
                case 6:
                    this.XCoord++;
                    break;
                case 7:
                    this.XCoord--;
                    this.YCoord--;
                    break;
                case 8:
                    this.YCoord--;
                    break;
                case 9:
                    this.XCoord++;
                    this.YCoord--;
                    break;
                default:
                    break;
            }
            if (XCoord > WorldXSize)
                XCoord = WorldXSize;
            if (YCoord > WorldYSize)
                YCoord = WorldYSize;
            if (XCoord < 0)
                XCoord = 0;
            if (YCoord < 0)
                YCoord = 0;
            //return 0;
        }
    }
}
