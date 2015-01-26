using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    //class Person
    //{
    //    public int XCoord;
    //    public int YCoord;

    //}

    //class World
    //{
    //    private string Type;
    //    private int XSize, YSize;
    //    public Person MainCharacter;
    //    char[,] Terrain;

    //    public World(int XSize, int YSize);
    //    {
    //        this.XSize = 100;
    //        this.YSize = 100;
    //    }
    //}


    class Program
    {
        static char[,] GenerateBarrenWorld(int WorldXSize, int WorldYSize, int rockrate)
        {
            //create world array
            char[,] World = new char[WorldXSize, WorldYSize];
            //create randomizer
            Random rnd = new Random();
            char tile = ' ';
            //fill world array
            for (int x = 0; x < WorldXSize; x++)
            {
                for (int y = 0; y < WorldYSize; y++)
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
                    World[x, y] = tile;
                    //Console.Write("{0,6}", rnd.Next(-100, 101));
                }
                //Console.WriteLine();
            }
            return World;
        }

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

        static char[,] CreateScreenOutput(char[,] World, char[,] Interface, int XCoord, int YCoord)
        {
            //get world size
            int WorldXSize = World.GetLength(0);
            int WorldYSize = World.GetLength(1);
            //get interface size
            int UIWidth = Interface.GetLength(0);
            int UIHeight = Interface.GetLength(1);
            //create array for output
            char[,] ScreenOutput = new char[UIWidth, UIHeight];

            // set window params
            //Console.Clear();
            //Console.SetWindowSize(UIWidth, UIHeight);
            //Console.BufferHeight = UIHeight*2;
            //Console.BufferWidth = UIWidth*2;

            //draw the world
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
                            ScreenOutput[x, y] = World[XCoord - (((int)((UIWidth - 20) / 2)) - x), YCoord - (((int)((UIHeight - 20) / 2)) - y)];
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

        static int Move(ref int XCoord, ref int YCoord)
        {
            //set starting console params
            ConsoleKeyInfo cki;
            //Console.TreatControlCAsInput = true;
            //Console.CursorVisible = false;
            //Console.SetCursorPosition(xwidth, ywidth);

            //handle control
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.NumPad1:
                    XCoord--;
                    YCoord++;
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop - 1);
                    return 0;
                case ConsoleKey.NumPad2:
                    //XCoord;
                    YCoord++;
                    //Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    return 0;
                case ConsoleKey.NumPad3:
                    XCoord++;
                    YCoord++;
                    //Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop - 1);
                    return 0;
                case ConsoleKey.NumPad4:
                    XCoord--;
                    //YCoord;
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    return 0;
                //case NumPad5:
                case ConsoleKey.NumPad6:
                    XCoord++;
                    //YCoord;
                    //Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    return 0;
                case ConsoleKey.NumPad7:
                    XCoord--;
                    YCoord--;
                    //Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop + 1);
                    return 0;
                case ConsoleKey.NumPad8:
                    //XCoord;
                    YCoord--;
                    //Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                    return 0;
                case ConsoleKey.NumPad9:
                    XCoord++;
                    YCoord--;
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
            int WorldXSize = 100;
            int WorldYSize = 100;
            int WorldRockRate = 20;
            int XCoord = 40;
            int YCoord = 40;
            int ExitFlag = 0;
            char[,] Interface = new char[UIWidth, UIHeight];
            char[,] World = new char[WorldXSize, WorldYSize];
            char[,] ScreenOutput = new char[UIWidth, UIHeight];
            char[,] ScreenOutputOld = new char[UIWidth, UIHeight];
            Interface = CreateInterface(UIWidth, UIHeight);
            World = GenerateBarrenWorld(WorldXSize, WorldYSize, WorldRockRate);

            for (; ; )
            {
                ScreenOutputOld = ScreenOutput;
                ScreenOutput = CreateScreenOutput(World, Interface, XCoord, YCoord);
                DrawScreenOutput(ScreenOutput, ScreenOutputOld);
                ExitFlag = Move(ref XCoord, ref YCoord);
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

