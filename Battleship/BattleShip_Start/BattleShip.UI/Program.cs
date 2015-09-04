
using System;
using System.Collections.Generic;
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

            SetUpBoard SetItUp = new SetUpBoard();
            SetItUp.SetUpGame(wf);

            //Turns PlayerTurns = new Turns();
            //PlayerTurns.
            
        }
    }
}