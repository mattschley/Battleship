using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class StartMenu
    {
        public void ShowMenu(WorkFlowObject wf)
        {
            Console.WriteLine("**** BATTLESHIP ****");

            Console.WriteLine("\n");

            Console.Write("What is player 1's name? ");
            wf.p1.playerName = Console.ReadLine();
            if (wf.p1.playerName == String.Empty)
            {
                wf.p1.playerName = "Player 1";
            }

            Console.WriteLine("\n");

            Console.Write("What is player 2's name? ");
            wf.p2.playerName = Console.ReadLine();
            if (wf.p2.playerName == String.Empty)
            {
                wf.p2.playerName = "Player 2";
            }

            Console.WriteLine("\n");
        }
    }
}
