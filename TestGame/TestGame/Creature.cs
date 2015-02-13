using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class Creature
    {
        //fields
        int XCoord, YCoord, hp, maxhp;
        public readonly int WorldXSize, WorldYSize;

        //properties:
        public int HP
        {
            get {return hp;}
            set {hp = value;}
        }
        public int MAXHP
        {
            get { return maxhp; }
            set { maxhp = value; }
        }
        public int X
        {
            get { return XCoord; }
            set { XCoord = value; }
        }
        public int Y
        {
            get { return YCoord; }
            set { YCoord = value; }
        }
        //constructors:
        protected Creature()
        {
            this.maxhp = 100;
            this.hp = this.maxhp;
        }
        public Creature(ref World World)
            :this()
        {
            this.XCoord = (int)((World.GetSize())[0]/2);
            this.YCoord = (int)((World.GetSize())[1]/2);
            this.WorldXSize = (World.GetSize())[0];
            this.WorldYSize = (World.GetSize())[1];
            
        }
        public Creature(ref World World, int XCoord, int YCoord)
            : this()
        {
            this.XCoord = XCoord;
            this.YCoord = YCoord;
            this.WorldXSize = (World.GetSize())[0];
            this.WorldYSize = (World.GetSize())[1];
        }
        public Creature(ref World World, int[] Coords)
            :this(ref World, Coords[0], Coords[1])
        {

        }
        public Creature(ref World World, int XCoord, int YCoord, int maxhp)
        {
            this.XCoord = XCoord;
            this.YCoord = YCoord;
            this.WorldXSize = (World.GetSize())[0];
            this.WorldYSize = (World.GetSize())[1];
            this.maxhp = maxhp;
            this.hp = this.maxhp;
        }
        public Creature(ref World World, int[] Coords, int maxhp)
            : this(ref World, Coords[0], Coords[1], maxhp) {   }
        
        //methods
        public int Move(int Direction)
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
            if (this.XCoord > this.WorldXSize)
                this.XCoord = this.WorldXSize;
            if (this.YCoord > this.WorldYSize)
                this.YCoord = this.WorldYSize;
            if (this.XCoord < 0)
                this.XCoord = 0;
            if (this.YCoord < 0)
                this.YCoord = 0;
            return 0;
        }
        public virtual void Hit(int Direction)
        {

        }
        public int[] GetCoords()
        {
            int[] Coords = { this.XCoord, this.YCoord };
            return Coords;
        }
    }
}
