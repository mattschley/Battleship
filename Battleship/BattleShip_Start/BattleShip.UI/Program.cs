using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    class WorkFlowObject
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
            Console.WriteLine("  1    2    3    4    5    6    7    8    9    10");
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
                        char print = WorkFlowObject.NumToChar(y);
                        Console.Write(print + " -  ");
                    }
                    else
                    {
                        Console.Write("  -  ");
                    }
                }
            }
        }

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
            WorkFlowObject wf = new WorkFlowObject
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


            Console.Write("WHat is player 1's name?");
            wf.p1.playerName = Console.ReadLine();

            Console.Write("WHat is player 2's name?");
            wf.p2.playerName = Console.ReadLine();

           
            wf.ShowBoard(wf.p1);
            wf.ShowBoard(wf.p2);

            Console.Write("Player 1's Turn to set up Board");
            Console.WriteLine("What ship?");
           
            var request1 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(4, 4),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            var request2 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(10, 6),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Battleship
            };

            var request3 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(3, 5),
                Direction = ShipDirection.Left,
                ShipType = ShipType.Submarine
            };
            var request4 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(3, 3),
                Direction = ShipDirection.Up,
                ShipType = ShipType.Cruiser
            };

            var request5 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(1, 8),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Destroyer
            };


            wf.p1.playerBoard.PlaceShip(request1);
            wf.p1.playerBoard.PlaceShip(request2);
            wf.p1.playerBoard.PlaceShip(request3);
            wf.p1.playerBoard.PlaceShip(request4);
            wf.p1.playerBoard.PlaceShip(request5);

            //PlaceShipRequest req1 = new PlaceShipRequest()
            //{
            //    Coordinate = new Coordinate(5, 5),
            //    Direction = ShipDirection.Up,
            //    ShipType = ShipType.Battleship

            //};

            //var res1 = wf.p1.playerBoard.PlaceShip(req1);

            //Console.WriteLine(res);
            if (wf.p1.playerBoard.ShotHistory.Count == 0)
            {
                Console.WriteLine("null");
            }
            foreach (KeyValuePair<Coordinate, ShotHistory> kvp in wf.p1.playerBoard.ShotHistory)
            {

                var x = kvp.Key.XCoordinate.ToString();
                var y = kvp.Key.YCoordinate.ToString();

                var hist = kvp.Value.ToString();

                Console.WriteLine(String.Format("{0}{1}{2}",x,y,hist));
                Console.WriteLine("DId we even get here!");
                Console.ReadLine();
            }

            //Console.WriteLine(wf.p1.playerBoard.ShotHistory);
            Console.WriteLine(wf.p1.playerBoard);
            Console.ReadLine();




        }

        
    }
}
