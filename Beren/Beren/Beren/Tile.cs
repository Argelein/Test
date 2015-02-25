using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beren
{
    class Tile
    {
        //fields
        readonly public int x, y;
        bool heropresent, enemypresent, itemspresent;
        Enemy enemy;
        char terrain;

        //properties
        public bool HeroPres
        {
            get { return heropresent; }
            set { heropresent = value; }
        }
        public bool EnemyPres
        {
            get { return enemypresent; }
            set { enemypresent = value; }
        }
        public bool ItemsPres
        {
            get { return itemspresent; }
            set { itemspresent = value; }
        }
        public Enemy Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }
        public char Terrain
        {
            get { return terrain; }
            set { terrain = value; }
        }
    }
}
