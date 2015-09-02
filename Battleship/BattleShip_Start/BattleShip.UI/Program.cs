using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class WorkflowObject
    {
        public Player p1;
        public Player p2;
        public int whosNext;
        public static int ChartoOne(char characterToChange)
        {
            switch (characterToChange)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
                case 'I':
                    return 9;
                case 'L':
                    return 10;
                default:
                    return 0;
            }
        }

        public int[,] boardGrid = new int[10,10];

    }

    class Player
    {
        public Board playerBoard;
        public string playerName;
    }

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowObject wf = new WorkflowObject
            {
                p1 = new Player()
                {
                    playerBoard = new Board(),
                    playerName = ""
                },
                p2 = new Player()
                {
                    playerBoard = new Board(),
                    playerName = ""
                },
                whosNext = 1
            };
            Console.WriteLine("What is player 1's name?");
            wf.p1.playerName = Console.ReadLine();

            Console.WriteLine("What is player 2's name?");
            wf.p2.playerName = Console.ReadLine();

            //need to set up the board. what does that mean?

            //for (int i = 0; i < boardGrid.Length; i++)
            //{
            //    Console.WriteLine(boardGrid);
            //}
            
            //need more instructions for the user: how to enter coordinates.
            Console.WriteLine("{0}, place your ship on the board.", wf.p1.playerName);
            //*staring coordinates* = Console.ReadLine();

            //do the same for player 2

            Console.ReadLine();
        }
    }
}
