using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class WorkFlowObject
    {
        public Player p1;
        public Player p2;
        public int whosNext;

        public static int CharToNum(char c)
        {
            switch (c)
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

        public static char NumToChar(int d)
        {
            switch (d)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                case 5:
                    return 'E';
                case 6:
                    return 'F';
                case 7:
                    return 'G';
                case 8:
                    return 'H';
                case 9:
                    return 'I';
                case 10:
                    return 'J';
                default:
                    return ' ';
            }
        }

        public void ShowBoard(Player p)
        {
            Console.WriteLine("  A    B    C    D    E    F    G    H    I    J");
            for (int y = 1; y < 11; y++)
            {
                if (y != 1)
                {
                    Console.WriteLine("\n");
                }

                for (int x = 1; x < 11; x++)
                {
                    Coordinate coordinateToCheck = new Coordinate(x, y);

                    if (p.playerBoard.ShotHistory.ContainsKey(coordinateToCheck))
                    {
                        Console.WriteLine("Hi");
                    }
                    else if (coordinateToCheck.XCoordinate == 1)
                    {
                        Console.Write(y + " -  ");
                    }
                    else
                    {
                        Console.Write("  -  ");
                    }
                }
            }
        }

    }
}
