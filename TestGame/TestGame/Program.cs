using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    class Program
    {
        //static char[,] GenerateBarrenWorld(int WorldXSize, int WorldYSize, int rockrate)
        //{
        //    //create world array
        //    char[,] World = new char[WorldXSize, WorldYSize];
        //    //create randomizer
        //    Random rnd = new Random();
        //    char tile = ' ';
        //    //fill world array
        //    for (int x = 0; x < WorldXSize; x++)
        //    {
        //        for (int y = 0; y < WorldYSize; y++)
        //        {
        //            int dice = rnd.Next(1, rockrate + 1);
        //            if (dice == rockrate)
        //            {
        //                tile = '^';
        //            }
        //            else
        //            {
        //                tile = '_';
        //            }
        //            World[x, y] = tile;
        //            //Console.Write("{0,6}", rnd.Next(-100, 101));
        //        }
        //        //Console.WriteLine();
        //    }
        //    return World;
        //}

        static char[,] CreateInterface(int UIWidth, int UIHeight)
        {
            //create interface array
            char[,] Interface = new char[UIWidth, UIHeight];
            char LeftTopCornerChar = '╔';
            char FlatBorderChar = '═';
            char RightTopCornerChar = '╗';
            char LeftBottomCornerChar = '╚';
            char BottomBorderChar = '═';
            char RightBottomCornerChar = '╝';
            char SideBorder = (char)9553;

            //fill interface array
            for (int y = 0; y < UIHeight; y++)
            {
                for (int x = 0; x < UIWidth; x++)
                {
                    if ((x == 0) && (y == 0))
                    {
                        Interface[x, y] = LeftTopCornerChar;
                        continue;
                    }
                    else if (((y == 0) && (x < (UIWidth - 20)) && (x != 0)) || ((y == (UIHeight - 20)) && (x < (UIWidth - 20)) && (x != 0)))
                    {
                        Interface[x, y] = FlatBorderChar;
                        continue;
                    }
                    else if ((x == (UIWidth - 20)) && (y == 0))
                    {
                        Interface[x, y] = RightTopCornerChar;
                        continue;
                    }
                    else if ((y == (UIHeight - 20)) && (x == (UIWidth - 20)))
                    {
                        Interface[x, y] = RightBottomCornerChar;
                        continue;
                    }
                    else if ((y == (UIHeight - 20)) && (x == 0))
                    {
                        Interface[x, y] = LeftBottomCornerChar;
                        continue;
                    }
                    else if (((x == 0) && (y != 0) && (y < (UIHeight - 20))) || ((y < (UIHeight - 20)) && (y != 0) && (x == (UIWidth - 20))))
                    {
                        Interface[x, y] = SideBorder;
                        continue;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            return Interface;
        }

        static void DrawScreenOutput(char[,] ScreenOutput, char[,] ScreenOutputOld)
        {
            //get world size
            int UIWidth = ScreenOutput.GetLength(0);
            int UIHeight = ScreenOutput.GetLength(1);

            // set window params
            //Console.Clear();
            Console.SetWindowSize(UIWidth, UIHeight);
            Console.BufferHeight = UIHeight;
            Console.BufferWidth = UIWidth + 1;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            //draw the world
            for (int y = 0; y < UIHeight; y++)
            {
                for (int x = 0; x < UIWidth; x++)
                {
                    if (ScreenOutput != ScreenOutputOld)
                    {
                        Console.Write(ScreenOutput[x, y]);
                    }
                }
                if (y < (UIHeight - 1))
                {
                    Console.WriteLine();
                }
            }
            Console.SetCursorPosition(0, UIHeight - 15);
        }

        static char[,] CreateScreenOutput(World World, char[,] Interface)
        {
            //get world size
            int WorldXSize = (World.GetSize())[0];
            int WorldYSize = (World.GetSize())[1];
            //get interface size
            int UIWidth = Interface.GetLength(0);
            int UIHeight = Interface.GetLength(1);
            //get coordinates
            int XCoord = (World.MainCharacter.GetCoords())[0];
            int YCoord = (World.MainCharacter.GetCoords())[1];
            //create array for output
            char[,] ScreenOutput = new char[UIWidth, UIHeight];

            //create ScreenOutput array
            for (int y = 0; y < UIHeight; y++)
            {
                for (int x = 0; x < UIWidth; x++)
                {
                    if ((x == 0) && (y == 0))
                    {
                        ScreenOutput[x, y] = Interface[x, y];
                        continue;
                    }
                    else if (((y == 0) && (x < (UIWidth - 20)) && (x != 0)) || ((y == (UIHeight - 20)) && (x < (UIWidth - 20)) && (x != 0)))
                    {
                        ScreenOutput[x, y] = Interface[x, y];
                        continue;
                    }
                    else if ((x == (UIWidth - 20)) && (y == 0))
                    {
                        ScreenOutput[x, y] = Interface[x, y];
                        continue;
                    }
                    else if ((y == (UIHeight - 20)) && (x == (UIWidth - 20)))
                    {
                        ScreenOutput[x, y] = Interface[x, y];
                        continue;
                    }
                    else if ((y == (UIHeight - 20)) && (x == 0))
                    {
                        ScreenOutput[x, y] = Interface[x, y];
                        continue;
                    }
                    else if (((x == 0) && (y != 0) && (y < (UIHeight - 20))) || ((y < (UIHeight - 20)) && (y != 0) && (x == (UIWidth - 20))))
                    {
                        ScreenOutput[x, y] = Interface[x, y];
                        continue;
                    }
                    else if ((x > 0) && (x < (UIWidth - 20)) && (y > 0) && (y < (UIHeight - 20)))
                    {
                        if ((XCoord > (((int)((UIWidth - 20) / 2)) - x)) && (YCoord > ((int)((UIHeight - 20) / 2)) - y) && ((XCoord - (((int)((UIWidth - 20) / 2)) - x)) < WorldXSize) && ((YCoord - (((int)((UIHeight - 20) / 2)) - y)) < WorldYSize))
                        {
                            ScreenOutput[x, y] = World.GetTerrainTile(XCoord - (((int)((UIWidth - 20) / 2)) - x), YCoord - (((int)((UIHeight - 20) / 2)) - y));
                            continue;
                        }
                        else
                        {
                            ScreenOutput[x, y] = ' ';
                            continue;
                        }

                    }
                }
                //if (y < (UIHeight - 1))
                //{
                //    Console.WriteLine();
                //}
            }
            return ScreenOutput;
        }

        static int InputControl(World World, ConsoleKeyInfo cki)
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

        static void Main(string[] args)
        {
            int UIWidth = 50;
            int UIHeight = 50;
            int WorldXSize = 10;
            int WorldYSize = 10;
            int WorldRockRate = 20;
            int XCoord = 40;
            int YCoord = 40;
            int ExitFlag = 0;
            ConsoleKeyInfo cki;
            World MainWorld = new World(WorldXSize, WorldYSize, WorldRockRate);
            Person MainCharacter = new Person(MainWorld, XCoord, YCoord);
            char[,] Interface = new char[UIWidth, UIHeight];
            char[,] World = new char[WorldXSize, WorldYSize];
            char[,] ScreenOutput = new char[UIWidth, UIHeight];
            char[,] ScreenOutputOld = new char[UIWidth, UIHeight];
            Interface = CreateInterface(UIWidth, UIHeight);
            //MainWorld.GenerateBarrenWorld(WorldRockRate);

            for (; ; )
            {
                ScreenOutputOld = ScreenOutput;
                ScreenOutput = CreateScreenOutput(MainWorld, Interface);
                DrawScreenOutput(ScreenOutput, ScreenOutputOld);
                //handle control
                cki = Console.ReadKey();
                ExitFlag = InputControl(MainWorld,cki);
                if (ExitFlag == 1)
                {
                    break;
                }
                //Console.ReadKey();
            }
            Console.WriteLine("    Bye!     ");
            Console.ReadKey();

        }

    }
}

