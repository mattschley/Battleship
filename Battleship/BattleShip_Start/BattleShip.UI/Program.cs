
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

            StartMenu Start = new StartMenu();
            Start.ShowMenu(wf);

            
            Console.WriteLine("{0} vs {1}\n", wf.p1.playerName, wf.p2.playerName);

            //SetUpBoard SetItUp = new SetUpBoard();
            //SetItUp.SetUpGame(wf);

            SetUpBoard SetItUpHard = new SetUpBoard();
            SetItUpHard.SetUpGameAuto(wf);
            Console.ReadLine();

            
            do
            {
                var turn = wf.whosNext;
                var turnResponse = wf.p1.playerBoard.FireShot(new Coordinate(100, 100));
                if (turn == 1)
                {
                    
                    while(turnResponse.ShotStatus == ShotStatus.Invalid || turnResponse.ShotStatus == ShotStatus.Duplicate) { 
                    
                        // player 1 is up -- do stuff 
                        Console.WriteLine("{0}, enter your x coordinate: ", wf.p1.playerName);
                        var x = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine("{0}, enter your y coordinate: ", wf.p1.playerName);
                        var y = int.Parse(Console.ReadLine());

                        var turnCoordinate = new Coordinate(x, y);

                        turnResponse = wf.p1.playerBoard.FireShot(turnCoordinate);
                        Console.WriteLine(turnResponse.ShotStatus);
                        
                    } 
                        
                    wf.ShowBoard(wf.p1);
                    wf.whosNext = 2;

                }
                else
                {
                    // player 2 is up -- do stuff 
                    wf.whosNext = 1;
                }
                

           
                if (turnResponse.ShotStatus == ShotStatus.Victory)
                {
                    wf.whosNext = 3;
                }
            } while (wf.whosNext != 3);

            // give some message about who won
            // ask them if they want to play again. 
            // if they do, call some method called PlayGame that we haven't made yet which runs the do while loop
            // if they don't, quit the program and say bye

            



            //Turns PlayerTurns = new Turns();
            //PlayerTurns.




        }
    }
}