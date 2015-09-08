using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class SetUpBoard
    {
        public void SetUpGame(WorkFlowObject wf)
        {
            wf.ShowBoard(wf.p1);
            SetupPlayer(wf.p1);

            Console.Clear();

            wf.ShowBoard(wf.p2);
            SetupPlayer(wf.p2);
        }

        public void SetUpGameAuto(WorkFlowObject wf)
        {
            wf.ShowBoard(wf.p1);
            SetUpPlayerAutomatically(wf.p1);

            Console.Clear();

            wf.ShowBoard(wf.p2);
            SetUpPlayerAutomatically(wf.p2);

        }

        private void SetupPlayer(Player player)
        {
            Console.WriteLine("\n\n");

            Console.WriteLine("{0}'s turn to set up the board.", player.playerName);

            Console.WriteLine("\n");

            PlaceShips placeShips = new PlaceShips();
            placeShips.PlaceTheShips(player);
        }

        private void SetUpPlayerAutomatically(Player player)
        {
            PlaceShips placeShips = new PlaceShips();
            placeShips.PlaceTheShipsAuto(player);
        }
    }
}
