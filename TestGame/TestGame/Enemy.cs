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
        int HeroDirection, HeroDistance;
        bool alive;
        //int XCoord, YCoord, hp, maxhp, HeroDirection;
        //readonly int WorldXSize, WorldYSize;

        //constructors:
        private Enemy() : base() { }
        public Enemy(ref World World) : base(ref World) { this.init(ref World); }
        public Enemy(ref World World, int XCoord, int YCoord) : base(ref World, XCoord, YCoord) { this.init(ref World); }
        public Enemy(ref World World, int[] Coords) : base(ref World, Coords) { this.init(ref World); }
        public Enemy(ref World World, int XCoord, int YCoord, int maxhp) : base(ref World, XCoord, YCoord, maxhp) { this.init(ref World); }
        public Enemy(ref World World, int[] Coords, int maxhp) : base(ref World, Coords, maxhp) { this.init(ref World); }

        //methods
        private void init(ref World World)
        {
            World.Enemies[0] = this;
            this.DetermineHeroDistance(World);
            this.DetermineHeroDirection(World);
        }
        private void DetermineHeroDirection(World World)
        {
            
            Random rnd = new Random();
            //X or Y projection of Hero Distance
            int DistProj = (int)(Math.Sqrt(2) * this.HeroDistance);
            //directions array
            int[] dirs = {1,2,3,4,6,7,8,9};
            //result directions list
            List<int> dirres = new List<int>();
            //count checkpoints in all directions and their distances from enemy for direction determination
            double[] check = new double[8];
            check[0] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X - DistProj), 2) + Math.Pow(this.Y - (World.MainCharacter.Y - DistProj), 2));// direction 1 numpad
            check[1] = Math.Sqrt(Math.Pow(this.X - World.MainCharacter.X, 2) + Math.Pow(this.Y - (World.MainCharacter.Y - this.HeroDistance), 2)); // direction 2 numpad
            check[2] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X + DistProj), 2) + Math.Pow(this.Y - (World.MainCharacter.Y - DistProj), 2));// direction 3 numpad
            check[3] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X - this.HeroDistance), 2) + Math.Pow(this.Y - (World.MainCharacter.Y), 2));// direction 4 numpad
            check[4] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X + this.HeroDistance), 2) + Math.Pow(this.Y - (World.MainCharacter.Y), 2));// direction 6 numpad
            check[5] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X - DistProj), 2) + Math.Pow(this.Y - (World.MainCharacter.Y + DistProj), 2));// direction 7 numpad
            check[6] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X + this.HeroDistance), 2) + Math.Pow(this.Y - (World.MainCharacter.Y), 2));// direction 8 numpad
            check[7] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X + DistProj), 2) + Math.Pow(this.Y - (World.MainCharacter.Y + DistProj), 2));// direction 9 numpad
            //check[8] = Math.Sqrt(Math.Pow(this.X - (World.MainCharacter.X + DistProj), 2) + Math.Pow(this.Y - (World.MainCharacter.Y - DistProj), 2));
            //finding closest checkpoints and fixing them in dirres List
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] == check.Min())
                {
                    dirres.Add(dirs[i]);
                }
            }
            //fill this.HeroDirection with Hero direction
            if (dirres.Count == 1)
            {
                this.HeroDirection = dirres[0];
            }
            else
            {
                this.HeroDirection = rnd.Next(dirres.Count);
            }
        }
        private void DetermineHeroDistance(World World)
        {

            this.HeroDistance = (int)(Math.Sqrt(Math.Pow((X - World.MainCharacter.X), 2) + Math.Pow((Y - World.MainCharacter.Y), 2)));
            //math. //this.X
            //HeroDirection = 5;
        }

        public int GetHeroDirection()
        {
            return HeroDirection;
        }




    }
}
