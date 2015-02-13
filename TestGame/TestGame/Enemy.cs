using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class Enemy : Creature
    {
        //fields
        int XCoord,YCoord, hp, maxhp;
        readonly int WorldXSize, WorldYSize;

        //constructors:
        private Enemy() : base() { }
        public Enemy(ref World World) : base(ref World) { }
        public Enemy(ref World World, int XCoord, int YCoord) : base(ref World, XCoord, YCoord) { }
        public Enemy(ref World World, int[] Coords) : base(ref World, Coords) { }
        public Enemy(ref World World, int XCoord, int YCoord, int maxhp) : base(ref World, XCoord, YCoord, maxhp) { }
        public Enemy(ref World World, int[] Coords, int maxhp) : base(ref World, Coords, maxhp) { }
    }
}
