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

        private int ReadNumber()
        {
            int? n = null;

            while (n == null)
            {
                try
                {
                    string nString = Console.ReadLine();
                    n = Int32.Parse(nString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number.");
                }
            }
            return (int)n;
        }

        private Coordinate ReadCoordinates()
        {
            Coordinate c = null;
            while (c == null)
            {
                try
                {
                    Console.WriteLine("Enter x coordinate.");
                    int x = ReadNumber();
                    Console.WriteLine("Enter y coordinate.");
                    int y = ReadNumber();

                    c = new Coordinate(x, y);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You must enter a number."); //TODO: You must enter a number.. on the grid.
                }
            }
            return c;
        }

        private Ship.Orientation ReadOrientation()
        {
            Ship.Orientation? orientation = null;
            while (orientation == null)
            {
                Console.WriteLine("Enter orientation (vertical/horizontal).");
                string orientationString = Console.ReadLine().ToLower();
                if (orientationString == "v" || orientationString == "vertical")
                {
                    orientation = Ship.Orientation.Vertical;
                }
                else if (orientationString == "h" || orientationString == "horizontal")
                {
                    orientation = Ship.Orientation.Horizontal;
                }
                else
                {
                    // FAIL!
                    Console.WriteLine("Enter a valid orientation.");
                }
            }
            return (Ship.Orientation)orientation;
        }

        public bool PositionShips()
        {
            foreach (Player player in Players)
            {
                foreach (Ship ship in player.Ships)
                {
                    while (!ship.Positioned)
                    {
                        Console.WriteLine(player.Name);
                        Console.WriteLine("Choose where to position your " + ship.Name.ToLower() + ".");
                        Coordinate c = ReadCoordinates();
                        
                        ship.O = ReadOrientation();

                        ship.Positioned = player.G.PositionShip(c, ship);
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
            while (players.Count() > 1)
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
                        //TODO: have another go after a successful hit?
                        bool guess = defencePlayer.G.MakeGuess(c);
                        if (guess)
                        {
                            Console.WriteLine("BOOM! You hit an enemy ship.");
                        }
                        else
                        {
                            Console.WriteLine("You missed.");
                        }

                        if (defencePlayer.HasLost())
                        {
                            // Someone has lost, remove them from the game
                            Console.WriteLine(defencePlayer.Name + " has no ships left. They have walked the plank.");
                            players.Remove(defencePlayer);
                        }
                    }
                }
            }
            Console.WriteLine(players.First() + " has won the game.");
            return true;
        }
    }
}
