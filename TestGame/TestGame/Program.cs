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


        static void Main(string[] args)
        {
            //starting parameters
            int UIWidth = 50;
            int UIHeight = 50;
            int WorldXSize = 20;
            int WorldYSize = 20;
            int WorldRockRate = 20;
            int XCoord = 10;
            int YCoord = 10;

            //defining variables
            int ExitFlag = 0;
            ConsoleKeyInfo cki;

            //creating instances
            World MainWorld = new World(WorldXSize, WorldYSize, WorldRockRate);
            Person MainCharacter = new Person(ref MainWorld, XCoord, YCoord);
            //char[,] Interface = new char[UIWidth, UIHeight];
            //char[,] World = new char[WorldXSize, WorldYSize];
            //char[,] ScreenOutput = new char[UIWidth, UIHeight];
            //char[,] ScreenOutputOld = new char[UIWidth, UIHeight];
            Interface MainInterface = new Interface(UIWidth, UIHeight, MainWorld);

            for (; ; )
            {
                //ScreenOutputOld = ScreenOutput;
                //ScreenOutput = CreateScreenOutput(MainWorld, Interface);
                //DrawScreenOutput(ScreenOutput, ScreenOutputOld);
                //handle control
                MainInterface.FillIFArraywithWorld(MainWorld);
                MainInterface.UpdatePlayerAttributes(MainWorld);

                MainInterface.DrawScreenOutput(MainWorld);
                cki = Console.ReadKey();
                ExitFlag = MainInterface.InputControl(MainWorld, cki);
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

