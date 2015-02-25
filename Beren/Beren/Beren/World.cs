using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beren
{
    class World
    {
        //constants
        const char rocktile = '^', plainstile = '_';
        
        //fields
        readonly string Type;
        readonly int XSize, YSize;
        Hero Beren;
        List<Enemy> Enemies;
        //List<Enemy> DeadEnemies;
        Tile[,] WorldArray;

        //properties
        //public List<Enemy> Enemies
        //{
        //    get { return enemies; }
        //}

        //constructors
        public World(int XSize, int YSize, int rockrate)
        {
            this.XSize = XSize;
            this.YSize = YSize;
            WorldArray = new Tile[XSize, YSize];
            this.Enemies = new List<Enemy>();
            //this.MainCharacter = new Person(ref this);
        }

        //methods
        //enemies handling: get enemies list
        public List<Enemy> GetEnemies()
        {
            return Enemies;
        }
        //enemies handling: add enemy to the enemies list
        public void AddEnemy(Enemy InputEnemy)
        {
            Enemies.Add(InputEnemy);
        }
        //enemies handling: kill enemy and remove it from the enemies list
        public void KillEnemy(Enemy InputEnemy)
        {
            Enemies.Remove(InputEnemy);
        }
        //enemies handling: move enemy on the map towards Hero
        public void MoveEnemy(ref Enemy InputEnemy)
        {
            //saving previous enemy state to tempenemy
            //Creature tempenemy = InputEnemy;
            //moving enemy towards hero
            InputEnemy.movetohero();
            // Move(InputEnemy.GetHeroDirection());
            //checking 
            //if (InputEnemy.X > this.XSize - 1)
            //    InputEnemy.X = this.XSize - 1;
            //if (InputEnemy.Y > this.YSize - 1)
            //    InputEnemy.Y = this.YSize - 1;
            //if (InputEnemy.X < 0)
            //    InputEnemy.X = 0;
            //if (InputEnemy.Y < 0)
            //    InputEnemy.Y = 0;
            //return 0;
        }
        //accessors
        public int[] GetSize()
        {
            int[] Size = new int[2];
            Size[0] = this.XSize;
            Size[1] = this.YSize;
            //XSize = this.XSize;
            //YSize = this.YSize;
            return Size;
        }
        public Hero GetHero()
        {
            return Beren;
        }
        private void GenerateBarrenTerrain(int rockrate)
        {
            //this.Terrain = new char[this.XSize, this.YSize];
            //create world array
            //create randomizer
            Random rnd = new Random();
            char landtile = plainstile;
            //fill world array with terrain
            for (int x = 0; x < this.XSize; x++)
            {
                for (int y = 0; y < this.YSize; y++)
                {
                    int dice = rnd.Next(1, rockrate + 1);
                    if (dice == rockrate)
                    {
                        landtile = rocktile;
                    }
                    else
                    {
                        landtile = plainstile;
                    }
                    this.WorldArray[x, y].Terrain = landtile;
                }
            }
        }

    }
}
