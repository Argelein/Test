﻿using System;
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
        public Double angle;
        bool alive;
        //int XCoord, YCoord, hp, maxhp, HeroDirection;
        //readonly int WorldXSize, WorldYSize;

        //const
        const double rad22_5 = 0.39269908169872415480783042290994, rad67_5 = 1.1780972450961724644234912687298;
        const double rad112_5 = 1.9634954084936207740391521145497, rad157_5 = 2.7488935718910690836548129603696;

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
            World.Enemies.Add(this);
            this.DetermineHeroDistance(World);
            this.DetermineHeroDirection(World);
        }
        public void DetermineHeroDirection(World World)
        {
            //angle calculation
            Double angle = Math.Atan2(0, 5) - Math.Atan2(World.MainCharacter.Y - this.Y, World.MainCharacter.X - this.X);
            //direction 
            if (angle <= rad22_5 && angle >= -rad22_5)
            {
                this.HeroDirection = 6;
            }
            else if (angle <= rad67_5 && angle >= rad22_5)
            {
                this.HeroDirection = 9;
            }
            else if (angle <= rad112_5 && angle >= rad67_5)
            {
                this.HeroDirection = 8;
            }
            else if (angle <= rad157_5 && angle >= rad112_5)
            {
                this.HeroDirection = 7;
            }
            else if (angle <= -rad157_5 || angle >= rad157_5)
            {
                this.HeroDirection = 4;
            }
            else if (angle <= -rad112_5 && angle >= -rad157_5)
            {
                this.HeroDirection = 1;
            }
            else if (angle <= -rad67_5 && angle >= -rad112_5)
            {
                this.HeroDirection = 2;
            }
            else if (angle <= -rad22_5 && angle >= -rad67_5)
            {
                this.HeroDirection = 3;
            }
        }

        public void DetermineHeroDistance(World World)
        {

            this.HeroDistance = (int)(Math.Sqrt(Math.Pow((X - World.MainCharacter.X), 2) + Math.Pow((Y - World.MainCharacter.Y), 2)));
            //math. //this.X
            //HeroDirection = 5;
        }

        public int GetHeroDirection()
        {
            return this.HeroDirection;
        }
        public int GetHeroDistance()
        {
            return this.HeroDistance;
        }
        public void movetohero()
        {
            this.Move(this.HeroDirection);
            //this.DetermineHeroDistance();
            //this.DetermineHeroDirection();
        }



    }
}
