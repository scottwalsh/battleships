using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Game
    {
        readonly List<Player> players;
        public List<Player> Players { get; set; }

        public Game()
        {
            List<Player> players = new List<Player>();
            Player player1 = new Player("Player One");
            players.Add(player1);
            Player player2 = new Player("Player Two");
            players.Add(player2);
            Players = players;
        }

        private Coordinate ReadCoordinates()
        {
            try
            {
                Console.WriteLine("Enter x coordinate.");
                string xString = Console.ReadLine();
                int x = Int32.Parse(xString);

                Console.WriteLine("Enter y coordinate.");
                string yString = Console.ReadLine();
                int y = Int32.Parse(yString);

                Coordinate c = new Coordinate(x, y);
                return c;
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number."); //TODO: You must enter a number.. on the grid.
                return null;
            }
        }

        public bool PositionShips()
        {
            // Position ships
            foreach (Player player in Players)
            {
                foreach (Ship ship in player.Ships)
                {
                    while (!ship.Positioned)
                    {
                        Console.WriteLine(player.Name);
                        Console.WriteLine("Choose where to position your " + ship.Name.ToLower() + ".");

                        Coordinate c = ReadCoordinates();

                        // TODO: Move this to a ReadOrientation method,
                        //     may be part of bigger problems relating to ship holding it's own orientation
                        //     shouldn't this be held on the map?
                        Console.WriteLine("Enter orientation (vertical/horizontal).");
                        string orientationString = Console.ReadLine().ToLower();
                        if (orientationString == "v" || orientationString == "vertical")
                        {
                            ship.O = Ship.Orientation.Vertical;
                        }
                        else if (orientationString == "h" || orientationString == "horizontal")
                        {
                            ship.O = Ship.Orientation.Horizontal;
                        }
                        else
                        {
                            // FAIL!
                            Console.WriteLine("Ship placement failed.");
                        }
                        ship.Positioned = player.GameGrid.PositionShip(c, ship);
                        Console.Clear();
                        if (!ship.Positioned)
                        {
                            Console.WriteLine("Failed to place " + ship.Name);
                        }
                    }
                }
            }
            return true;
        }

        public bool TakeTurns()
        {
            bool end = false;
            while (!end) // FIXME: may not be the end of the game if more than two people are playing
            {
                // Take turns in trying to hit the other persons ships
                foreach (Player attackPlayer in Players)
                {
                    foreach (Player defencePlayer in Players)
                    {
                        if (attackPlayer == defencePlayer)
                        {
                            continue;
                        }
                        Console.Clear();
                        Console.WriteLine(attackPlayer.Name);
                        Console.WriteLine("You are attacking " + defencePlayer.Name);
                        Console.WriteLine("Select your target");

                        Coordinate c = null;
                        while (c == null)
                        {
                            try
                            {
                                c = ReadCoordinates();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Could not target location.");
                                Console.WriteLine("Have another go.");
                            }
                        }

                        //TODO: successful guess does not mean hit ship, it means you selected a valid location
                        //instead could return square so we can display details about it
                        bool guess = defencePlayer.GameGrid.MakeGuess(c);
                        if (guess)
                        {
                            Console.WriteLine("BOOM! You hit an enemy ship.");
                        }
                        else
                        {
                            Console.WriteLine("You missed.");
                        }

                        // End state
                        // For this to work all ships in the ships list must be placed on the grid
                        if (defencePlayer.GameGrid.GetBombedShipsCount() >= defencePlayer.GetShipSquareCount())
                        {
                            // Someone has lost
                            Console.WriteLine(defencePlayer.Name + " has no ships left. They have walked the plank.");
                            end = true;

                            // A better end state which works for more players?
                            //players.Remove(defencePlayer);
                            //if (players.Count() < 2) {end = true;}
                        }
                    }
                }
            }
            return true;
        }
    }
}
