using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class Interface
    {
        //constants:

        const char LeftTopCornerChar = '╔';
        const char FlatBorderChar = '═';
        const char RightTopCornerChar = '╗';
        const char LeftBottomCornerChar = '╚';
        const char BottomBorderChar = '═';
        const char RightBottomCornerChar = '╝';
        const char SideBorder = (char)9553;
        const char HeroSymbol = '*';
        const char EnemySymbol = 'X';
        const char Blanc = ' ';

        //fields
        int UIWidth, UIHeight;
        public readonly int framesizeX, framesizeY;
        public readonly int attrplaceX, attrplaceY;
        bool FirstTime;
        char[,] IFArray;
        char[,] IFArrayPrev;

        //constructors
        public Interface(int UIWidth, int UIHeight, World MainWorld)
        {
            this.UIWidth = UIWidth;
            this.UIHeight = UIHeight;
            this.framesizeX = this.UIWidth - 20;
            this.framesizeY = this.UIHeight - 20;
            this.attrplaceX = this.framesizeX + 2;
            this.attrplaceY = 3;
            this.IFArray = new char[UIWidth, UIHeight];
            this.IFArrayPrev = new char[UIWidth, UIHeight];
            this.FillIFArraywithStatic();
            this.FillIFArraywithWorld(MainWorld);
            this.UpdatePlayerAttributes(MainWorld);
            this.FirstTime = true;
        }

        //methods
        private void FillIFArraywithStatic()
        {
            //creating frame
            for (int y = 0; y < UIHeight; y++)
            {
                for (int x = 0; x < UIWidth; x++)
                {
                    if ((x == 0) && (y == 0))
                    {
                        this.IFArray[x, y] = LeftTopCornerChar;
                        continue;
                    }
                    else if (((y == 0) && (x < this.framesizeX) && (x != 0)) || ((y == this.framesizeY) && (x < this.framesizeX) && (x != 0)))
                    {
                        this.IFArray[x, y] = FlatBorderChar;
                        continue;
                    }
                    else if ((x == this.framesizeX) && (y == 0))
                    {
                        this.IFArray[x, y] = RightTopCornerChar;
                        continue;
                    }
                    else if ((y == this.framesizeY) && (x == this.framesizeX))
                    {
                        this.IFArray[x, y] = RightBottomCornerChar;
                        continue;
                    }
                    else if ((y == this.framesizeY) && (x == 0))
                    {
                        this.IFArray[x, y] = LeftBottomCornerChar;
                        continue;
                    }
                    else if (((x == 0) && (y != 0) && (y < this.framesizeY)) || ((y < this.framesizeY) && (y != 0) && (x == this.framesizeX)))
                    {
                        this.IFArray[x, y] = SideBorder;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            //fill player attributes table
            //fill Hit Points field
            this.IFArray[this.attrplaceX, this.attrplaceY] = "H"[0];
            this.IFArray[this.attrplaceX + 1, this.attrplaceY] = "P"[0];
            this.IFArray[this.attrplaceX + 2, this.attrplaceY] = ":"[0];
            this.IFArray[this.attrplaceX + 7, this.attrplaceY] = "/"[0];
            //fill Coords fields
            this.IFArray[this.attrplaceX, this.attrplaceY + 1] = "X"[0];
            this.IFArray[this.attrplaceX + 1, this.attrplaceY + 1] = ":"[0];
            this.IFArray[this.attrplaceX, this.attrplaceY + 2] = "Y"[0];
            this.IFArray[this.attrplaceX + 1, this.attrplaceY + 2] = ":"[0];
        }

        public void FillIFArraywithWorld(World World)
        {
            //get world size
            int WorldXSize = (World.GetSize())[0];
            int WorldYSize = (World.GetSize())[1];
            //get Hero coordinates
            int XCoord = (World.MainCharacter.GetCoords())[0];
            int YCoord = (World.MainCharacter.GetCoords())[1];
            //create ScreenOutput array
            for (int y = 1; y < UIHeight-20; y++)
            {
                for (int x = 1; x < UIWidth-20; x++)
                {
                    if ((x > 0) && (x < this.framesizeX) && (y > 0) && (y < this.framesizeY))
                    {
                        
                        if ((XCoord > (((int)(this.framesizeX / 2)) - x)) && (YCoord > ((int)(this.framesizeY / 2)) - y) && ((XCoord - (((int)(this.framesizeX / 2)) - x )) < WorldXSize) && ((YCoord - (((int)(this.framesizeY / 2)) - y)) < WorldYSize))
                        {
                            if ((x == (((int)(this.framesizeX / 2)) + 1)) && (y == (((int)(this.framesizeY / 2)) + 1)))
                            {
                                this.IFArray[x, y] = HeroSymbol;
                            }
                            else if ((World.Enemies[0].X == XCoord - (((int)(this.framesizeX / 2)) - x)) && (World.Enemies[0].Y == YCoord - (((int)(this.framesizeY / 2)) - y)))
                            {
                                this.IFArray[x, y] = EnemySymbol;
                            }
                            else
                            {
                                this.IFArray[x, y] = World.GetTerrainTile(XCoord - (((int)(this.framesizeX / 2)) - x), YCoord - (((int)(this.framesizeY / 2)) - y));
                                //ScreenOutput[x, y] = World.GetTerrainTile(XCoord - (((int)(this.framesizeX / 2)) - x), YCoord - (((int)(this.framesizeY / 2)) - y));
                                continue;
                            }
                        }
                        else
                        {
                            this.IFArray[x, y] = ' ';
                            //ScreenOutput[x, y] = ' ';
                            continue;
                        }
                    }
                }
            }
        }

        public void UpdatePlayerAttributes(World World)
        {
            //update player attributes
            //update Hit Points value
            for (int i = 0; i < 3; i++)
            {
                this.IFArray[this.attrplaceX + 6 - i, this.attrplaceY] = World.MainCharacter.HP.ToString()[World.MainCharacter.HP.ToString().Length - i - 1];
            }
            //update Max Hit Points value
            for (int i = 0; i < World.MainCharacter.MAXHP.ToString().Length; i++)
            {
                this.IFArray[this.attrplaceX + 10 - i, this.attrplaceY] = World.MainCharacter.MAXHP.ToString()[World.MainCharacter.MAXHP.ToString().Length - i - 1];
            }
            
            //update Hero Coords values
            //X coord
            for (int i = 0; i < 4; i++)
            {
                if ((World.MainCharacter.X.ToString().Length - i > 0) && (World.MainCharacter.X.ToString().Length - i <= World.MainCharacter.X.ToString().Length))
                    this.IFArray[this.attrplaceX + 10 - i, this.attrplaceY + 1] = World.MainCharacter.X.ToString()[World.MainCharacter.X.ToString().Length - i - 1];
                else
                    this.IFArray[this.attrplaceX + 10 - i, this.attrplaceY + 1] = Blanc;
            }
            //Y coord
            for (int i = 0; i < 4; i++)
            {
                if ((World.MainCharacter.Y.ToString().Length - i > 0) && (World.MainCharacter.Y.ToString().Length - i <= World.MainCharacter.Y.ToString().Length))
                    this.IFArray[this.attrplaceX + 10 - i, this.attrplaceY + 2] = World.MainCharacter.Y.ToString()[World.MainCharacter.Y.ToString().Length - i - 1];
                else
                    this.IFArray[this.attrplaceX + 10 - i, this.attrplaceY + 2] = Blanc;
            }
        }

        public void DrawScreenOutput(World MainWorld)
        {
            //saving current interface state
            this.IFArrayPrev = this.IFArray;
            this.FillIFArraywithWorld(MainWorld);
            this.UpdatePlayerAttributes(MainWorld);
            //get world size
            //int UIWidth = IFArray.GetLength(0);
            //int UIHeight = IFArray.GetLength(1);
            // set window params
            //Console.Clear();
            Console.SetWindowSize(this.UIWidth, this.UIHeight);
            Console.BufferHeight = this.UIHeight;
            Console.BufferWidth = this.UIWidth + 1;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            //draw the world
            for (int y = 0; y < this.UIHeight; y++)
            {
                for (int x = 0; x < this.UIWidth; x++)
                {
                    if ((this.IFArray != this.IFArrayPrev) || (this.FirstTime))
                    {
                        Console.Write(this.IFArray[x, y]);
                    }
                }
                if (y < (this.UIHeight - 1))
                {
                    Console.WriteLine();
                }
            }
            Console.SetCursorPosition(0, this.UIHeight - 15);
        }

        public void DrawEnemyStats(World MainWorld)
        {
            Console.SetCursorPosition(this.UIWidth - 17, 10);
            Console.Write("HP: {0}",MainWorld.Enemies[0].HP);
            Console.SetCursorPosition(this.UIWidth - 17, 11);
            Console.Write("X: {0}", MainWorld.Enemies[0].X);
            Console.SetCursorPosition(this.UIWidth - 17, 12);
            Console.Write("Y: {0}", MainWorld.Enemies[0].Y);
            Console.SetCursorPosition(this.UIWidth - 17, 13);
            Console.Write("Hdirec: {0}", MainWorld.Enemies[0].GetHeroDirection());
            Console.SetCursorPosition(this.UIWidth - 17, 14);
            Console.Write("Hdist: {0}", MainWorld.Enemies[0].GetHeroDistance());
            Console.SetCursorPosition(this.UIWidth - 17, 15);
            Console.Write("Angle: {0}", MainWorld.Enemies[0].angle *180 / 3.14);
            Console.SetCursorPosition(0, this.UIHeight - 15);
        }

        //static char[,] CreateScreenOutput(World World, char[,] Interface)
        //{
        //    //get world size
        //    int WorldXSize = (World.GetSize())[0];
        //    int WorldYSize = (World.GetSize())[1];
        //    //get interface size
        //    int UIWidth = Interface.GetLength(0);
        //    int UIHeight = Interface.GetLength(1);
        //    //get coordinates
        //    int XCoord = (World.MainCharacter.GetCoords())[0];
        //    int YCoord = (World.MainCharacter.GetCoords())[1];
        //    //create array for output
        //    char[,] ScreenOutput = new char[UIWidth, UIHeight];

        //    //create ScreenOutput array
        //    for (int y = 0; y < UIHeight; y++)
        //    {
        //        for (int x = 0; x < UIWidth; x++)
        //        {
        //            if ((x == 0) && (y == 0))
        //            {
        //                ScreenOutput[x, y] = Interface[x, y];
        //                continue;
        //            }
        //            else if (((y == 0) && (x < this.framesizeX) && (x != 0)) || ((y == this.framesizeY) && (x < this.framesizeX) && (x != 0)))
        //            {
        //                ScreenOutput[x, y] = Interface[x, y];
        //                continue;
        //            }
        //            else if ((x == this.framesizeX) && (y == 0))
        //            {
        //                ScreenOutput[x, y] = Interface[x, y];
        //                continue;
        //            }
        //            else if ((y == this.framesizeY) && (x == this.framesizeX))
        //            {
        //                ScreenOutput[x, y] = Interface[x, y];
        //                continue;
        //            }
        //            else if ((y == this.framesizeY) && (x == 0))
        //            {
        //                ScreenOutput[x, y] = Interface[x, y];
        //                continue;
        //            }
        //            else if (((x == 0) && (y != 0) && (y < this.framesizeY)) || ((y < this.framesizeY) && (y != 0) && (x == this.framesizeX)))
        //            {
        //                ScreenOutput[x, y] = Interface[x, y];
        //                continue;
        //            }
        //            else if ((x > 0) && (x < this.framesizeX) && (y > 0) && (y < this.framesizeY))
        //            {
        //                if ((XCoord > (((int)(this.framesizeX / 2)) - x)) && (YCoord > ((int)(this.framesizeY / 2)) - y) && ((XCoord - (((int)(this.framesizeX / 2)) - x)) < WorldXSize) && ((YCoord - (((int)(this.framesizeY / 2)) - y)) < WorldYSize))
        //                {
        //                    ScreenOutput[x, y] = World.GetTerrainTile(XCoord - (((int)(this.framesizeX / 2)) - x), YCoord - (((int)(this.framesizeY / 2)) - y));
        //                    continue;
        //                }
        //                else
        //                {
        //                    ScreenOutput[x, y] = ' ';
        //                    continue;
        //                }
        //            }
        //        }
        //        //if (y < (UIHeight - 1))
        //        //{
        //        //    Console.WriteLine();
        //        //}
        //    }
        //    return ScreenOutput;
        //}

        public int InputControl(World World, ConsoleKeyInfo cki)
        {
            //set starting console params
            //ConsoleKeyInfo cki;
            //Console.TreatControlCAsInput = true;
            //Console.CursorVisible = false;
            //Console.SetCursorPosition(xwidth, ywidth);

            //handle control
            //cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.NumPad1:
                    World.MainCharacter.Move(1);
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                    return 0;
                case ConsoleKey.NumPad2:
                    World.MainCharacter.Move(2);
                    //Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    return 0;
                case ConsoleKey.NumPad3:
                    World.MainCharacter.Move(3);
                    //Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop - 1);
                    return 0;
                case ConsoleKey.NumPad4:
                    World.MainCharacter.Move(4);
                    //YCoord;
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    return 0;
                case ConsoleKey.NumPad5:
                    World.MainCharacter.Move(5);
                    return 0;
                case ConsoleKey.NumPad6:
                    World.MainCharacter.Move(6);
                    //YCoord;
                    //Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    return 0;
                case ConsoleKey.NumPad7:
                    World.MainCharacter.Move(7);
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                    return 0;
                case ConsoleKey.NumPad8:
                    //XCoord;
                    World.MainCharacter.Move(8);
                    //Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    return 0;
                case ConsoleKey.NumPad9:
                    World.MainCharacter.Move(9);
                    //Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop + 1);
                    return 0;
                //case NumPad:
                //case NumPad1:
                case ConsoleKey.Escape:
                    return 1;
                default:
                    return 0;
            }
        }

    }
}
