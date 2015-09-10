using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class PlaceShips
    {
        public void PlaceTheShips(Player player)
        {
            PlaceShipRequest ShipToPlace = new PlaceShipRequest();

            for (int i = 0; i < 5; i++)
            {
                ShipPlacement response = ShipPlacement.NotEnoughSpace;
                do
                {
                    Console.WriteLine("Place your {0} on the x axis with a letter: ", ShipToPlace.ShipType);
                    string userinputXCoord = Console.ReadLine();
                    int Xcoord = 0;

                    switch (userinputXCoord.ToUpper())
                    {
                        case "A":
                            Xcoord = 1;
                            break;
                        case "B":
                            Xcoord = 2;
                            break;
                        case "C":
                            Xcoord = 3;
                            break;
                        case "D":
                            Xcoord = 4;
                            break;
                        case "E":
                            Xcoord = 5;
                            break;
                        case "F":
                            Xcoord = 6;
                            break;
                        case "G":
                            Xcoord = 7;
                            break;
                        case "H":
                            Xcoord = 8;
                            break;
                        case "I":
                            Xcoord = 9;
                            break;
                        case "J":
                            Xcoord = 10;
                            break;
                    }

                    Console.WriteLine("\nPlace your {0} on the y axis with a number: ", ShipToPlace.ShipType);
                    string inputYCoord = Console.ReadLine();
                    var new_string = 0;
                    if (int.TryParse(inputYCoord, out new_string))
                    {
                        new_string = new_string;
                    }
                    else
                    {
                        new_string = 0;

                    }
                    //int Ycoord = int.Parse(inputYCoord);
                    int Ycoord = new_string;
                    Console.WriteLine("\nWhat direction should your carrier point? (Up, Down, Right, Left): ");
                    string inputCarrierDirection = Console.ReadLine();
                    ShipDirection myDirection = 0;
                    switch (inputCarrierDirection.ToUpper())
                    {
                        case "UP":
                        case "U":
                            myDirection = ShipDirection.Up;
                            break;
                        case "DOWN":
                        case "D":
                            myDirection = ShipDirection.Down;
                            break;
                        case "RIGHT":
                        case "R":
                            myDirection = ShipDirection.Right;
                            break;
                        case "LEFT":
                        case "L":
                            myDirection = ShipDirection.Left;
                            break;
                    }

                    ShipToPlace.Direction = myDirection;

                    ShipToPlace.Coordinate = new Coordinate(Xcoord, Ycoord);

                    response = player.playerBoard.PlaceShip(ShipToPlace);

                    if (response == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine("\nThere isn't enough room.  Try again.\n");
                    }
                    if (response == ShipPlacement.Overlap)
                    {
                        Console.WriteLine("\nThat ship overlaps another.  Please try again.\n");
                    }
                    

                } while (response != ShipPlacement.Ok);      
                
                ShipToPlace.ShipType++;

                int howManyShipsPlaced = 0;
                howManyShipsPlaced++;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nYou've placed {0} of 5 ships so far.", howManyShipsPlaced);
                Console.ResetColor();

                Console.WriteLine("\n");

            }
        }

        public void PlaceTheShipsAuto(Player player)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(4, 4),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Carrier
            };

            player.playerBoard.PlaceShip(request);
            var request1 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(10, 6),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Battleship
            };

            player.playerBoard.PlaceShip(request1);

            var request2 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(3, 5),
                Direction = ShipDirection.Left,
                ShipType = ShipType.Submarine
            };

            player.playerBoard.PlaceShip(request2);

            var request3 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(3, 3),
                Direction = ShipDirection.Up,
                ShipType = ShipType.Cruiser
            };

            player.playerBoard.PlaceShip(request3);

            var request4 = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(1, 8),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Destroyer
            };

            player.playerBoard.PlaceShip(request4);
        }
    }
}
