
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    class Program
    {
        private static Player player;

        public static void Play()
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

            StartMenu Start = new StartMenu();
            Start.ShowMenu(wf);


            Console.WriteLine("{0} vs {1}\n", wf.p1.playerName, wf.p2.playerName);

            //SetUpBoard SetItUp = new SetUpBoard();
            //SetItUp.SetUpGame(wf);

            SetUpBoard SetItUpHard = new SetUpBoard();
            SetItUpHard.SetUpGameAuto(wf);
            //Console.ReadLine();


            do
            {
                var turn = wf.whosNext;
                var turnResponse = wf.p1.playerBoard.FireShot(new Coordinate(100, 100));
                if (turn == 1)
                {

                    while (turnResponse.ShotStatus == ShotStatus.Invalid || turnResponse.ShotStatus == ShotStatus.Duplicate)
                    {

                        // player 1 
                        Console.WriteLine("{0}, press enter to show your board.", wf.p1.playerName);
                        Console.ReadLine();
                        wf.ShowBoard(wf.p1);
                        Console.WriteLine("\n");
                        Console.WriteLine("{0}, enter your x coordinate: ", wf.p1.playerName);
                        var x = Console.ReadLine();
                        var finalP1X = 0;

                        switch (x.ToUpper())
                        {
                            case "A":
                                finalP1X = 1;
                                break;
                            case "B":
                                finalP1X = 2;
                                break;
                            case "C":
                                finalP1X = 3;
                                break;
                            case "D":
                                finalP1X = 4;
                                break;
                            case "E":
                                finalP1X = 5;
                                break;
                            case "F":
                                finalP1X = 6;
                                break;
                            case "G":
                                finalP1X = 7;
                                break;
                            case "H":
                                finalP1X = 8;
                                break;
                            case "I":
                                finalP1X = 9;
                                break;
                            case "J":
                                finalP1X = 10;
                                break;
                        }

                        Console.WriteLine("{0}, enter your y coordinate: ", wf.p1.playerName);
                        var y = Console.ReadLine();
                        var finaly = 0;
                        int value;
                        if (int.TryParse(y, out value))
                        {
                            finaly = value;
                        }
                        else { finaly = 0; }

                        var turnCoordinate = new Coordinate(finalP1X, finaly);

                        turnResponse = wf.p1.playerBoard.FireShot(turnCoordinate);
                        Console.WriteLine(turnResponse.ShotStatus);

                        if (turnResponse.ShotStatus == ShotStatus.Hit)
                        {
                            Console.WriteLine("You hit something!");
                        }
                        else if (turnResponse.ShotStatus == ShotStatus.Miss)
                        {
                            Console.WriteLine("Your projectile splashes into the ocean, you missed!");
                        }
                        else if (turnResponse.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            Console.WriteLine("You sank your opponent's {0)", turnResponse.ShipImpacted);
                        }


                    }

                    wf.ShowBoard(wf.p1);

                    Console.WriteLine("\n");
                    Console.WriteLine("Press enter to clear the board");
                    Console.ReadLine();
                    Console.Clear();

                    wf.whosNext = 2;

                }
                else
                {
                    while (turnResponse.ShotStatus == ShotStatus.Invalid || turnResponse.ShotStatus == ShotStatus.Duplicate)
                    {

                        // player 2 
                        Console.WriteLine("{0}, press enter to show your board.", wf.p2.playerName);
                        Console.ReadLine();
                        wf.ShowBoard(wf.p2);
                        Console.WriteLine("\n");
                        Console.WriteLine("{0}, enter your x coordinate: ", wf.p2.playerName);
                        var x = Console.ReadLine();
                        var finalP2X = 0;

                        switch (x.ToUpper())
                        {
                            case "A":
                                finalP2X = 1;
                                break;
                            case "B":
                                finalP2X = 2;
                                break;
                            case "C":
                                finalP2X = 3;
                                break;
                            case "D":
                                finalP2X = 4;
                                break;
                            case "E":
                                finalP2X = 5;
                                break;
                            case "F":
                                finalP2X = 6;
                                break;
                            case "G":
                                finalP2X = 7;
                                break;
                            case "H":
                                finalP2X = 8;
                                break;
                            case "I":
                                finalP2X = 9;
                                break;
                            case "J":
                                finalP2X = 10;
                                break;
                        }

                        Console.WriteLine("{0}, enter your y coordinate: ", wf.p1.playerName);
                        var y = Console.ReadLine();
                        var finaly = 0;
                        int value;
                        if (int.TryParse(y, out value))
                        {
                            finaly = value;
                        }
                        else { finaly = 0; }

                        var turnCoordinate = new Coordinate(finalP2X, finaly);

                        turnResponse = wf.p2.playerBoard.FireShot(turnCoordinate);
                        Console.WriteLine(turnResponse.ShotStatus);

                        if (turnResponse.ShotStatus == ShotStatus.Hit)
                        {
                            Console.WriteLine("You hit something!");
                        }
                        else if (turnResponse.ShotStatus == ShotStatus.Miss)
                        {
                            Console.WriteLine("Your projectile splashes into the ocean, you missed!");
                        }
                        else if (turnResponse.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            Console.WriteLine("You sank your opponent's {0)", turnResponse.ShipImpacted);
                        }
                    }
                    wf.ShowBoard(wf.p2);

                    Console.WriteLine("\n");
                    Console.WriteLine("Press enter to clear the board");
                    Console.ReadLine();
                    Console.Clear();
                    wf.whosNext = 1;

                }



                if (turnResponse.ShotStatus == ShotStatus.Victory)
                {
                    var winner = "";
                    if (wf.whosNext == 2)
                    {
                        winner = wf.p1.playerName;
                    }
                    else
                    {
                        winner = wf.p2.playerName;
                    }
                    Console.Clear();
                    Console.WriteLine("Congrats, {0}, you've sunk all your oppenent's ships, you win!", winner);
                    Console.ReadLine();

                    wf.whosNext = 3;
                }
            } while (wf.whosNext != 3);

            // give some message about who won
            // ask them if they want to play again. 
            // if they do, call some method called PlayGame that we haven't made yet which runs the do while loop
            // if they don't, quit the program and say bye
            Console.WriteLine("Press 1 to play again, or press 2 to quit.");
            var num = Console.ReadLine();
            var final_num = int.Parse(num);
            if (final_num == 1)
            {
                Play();
            }
            else return;




            //Turns PlayerTurns = new Turns();
            //PlayerTurns.
        }
        static void Main(string[] args)
        {


            Play();


        }
    }
}