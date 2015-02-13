using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class World
    {
        //fields
        protected string Type;
        protected int XSize, YSize, EnemyCap;
        public Person MainCharacter;
        public Enemy[] Enemies;
        char[,] Terrain;


        //constructors
        public World()
        {
            this.XSize = 100;
            this.YSize = 100;
            this.GenerateBarrenWorld(20);
            this.EnemyCap = 100;
            this.Enemies = new Enemy[EnemyCap];
            //this.MainCharacter = new Person(ref this);
        }

        public World(int XSize, int YSize, int rockrate)
        {
            this.XSize = XSize;
            this.YSize = YSize;
            this.GenerateBarrenWorld(rockrate);
            this.EnemyCap = 100;
            this.Enemies = new Enemy[EnemyCap];
            //this.MainCharacter = new Person(ref this);
        }
        //methods
        public int[] GetSize()
        {
            int[] Size = new int[2];
            Size[0] = this.XSize;
            Size[1] = this.YSize;
            //XSize = this.XSize;
            //YSize = this.YSize;
            return Size;
        }

        private void GenerateBarrenWorld(int rockrate)
        {
            if (Terrain == null)
            {
                this.Terrain = new char[this.XSize, this.YSize];
                //create world array
                //create randomizer
                Random rnd = new Random();
                char tile = ' ';
                //fill world array
                for (int x = 0; x < this.XSize; x++)
                {
                    for (int y = 0; y < this.YSize; y++)
                    {
                        int dice = rnd.Next(1, rockrate + 1);
                        if (dice == rockrate)
                        {
                            tile = '^';
                        }
                        else
                        {
                            tile = '_';
                        }
                        this.Terrain[x, y] = tile;
                        //Console.Write("{0,6}", rnd.Next(-100, 101));
                    }
                    //Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("World is already Generated!");
            }
        }

        public char GetTerrainTile(int X,int Y)
        {
            return this.Terrain[X, Y];
        }
    }
}
