using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            Player player1 = new Player("Player One");
            Player player2 = new Player("Player Two");
            players.Add(player1);
            players.Add(player2);

            // Position ships
            foreach (Player p in players)
            {
                foreach (Ship s in p.GetShips())
                {
                    int x = -1;
                    int y = -1;
                    while (!s.IsPositioned())
                    {
                        try
                        {
                            Console.WriteLine(p.GetName());
                            Console.WriteLine("Choose where to position your " + s.GetName().ToLower() + ".");

                            Console.WriteLine("Enter x coordinate.");
                            string xString = Console.ReadLine();
                            x = Int32.Parse(xString);

                            Console.WriteLine("Enter y coordinate.");
                            string yString = Console.ReadLine();
                            y = Int32.Parse(yString);

                            Console.WriteLine("Enter orientation (vertical/horizontal).");
                            string orientationString = Console.ReadLine().ToLower();
                            if (orientationString == "v" || orientationString == "vertical")
                            {
                                s.SetOrientation(Ship.Orientation.Vertical);
                            }
                            else if (orientationString == "h" || orientationString == "horizontal")
                            {
                                s.SetOrientation(Ship.Orientation.Horizontal);
                            }
                            else
                            {
                                // FAIL!
                                throw new Exception();
                            }
                            p.grid.PositionShip(x, y, s);
                            s.SetAsPositioned();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ship placement failed.");
                        }
                    }
                }
            }

            bool end = false;
            while (!end)
            {
                // Take turns in trying to hit the other persons ships
                foreach (Player p in players)
                {
                    Console.WriteLine(p.GetName());
                    Console.WriteLine("Select your target");
                    int x = -1;
                    int y = -1;
                    while (x == -1 && y == -1) // This matches the solution to read in ship placement, may be an idea to move coordinated reading into it's own method
                    {
                        try
                        {
                            // Read in coordinates from user
                            Console.WriteLine("Enter x coordinate");
                            string xString = Console.ReadLine();
                            x = Int32.Parse(xString);
                            Console.WriteLine("Enter y coordinate");
                            string yString = Console.ReadLine();
                            y = Int32.Parse(yString);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Could not target location.");
                            Console.WriteLine("Have another go.");
                            x = -1;
                            y = -1;
                        }
                    }

                    // TODO: make it target the other persons grid
                    bool guess = p.grid.MakeGuess(x, y); //FAIL! You don't guess at your own grid
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
                    if (player1.grid.GetBombedShipsCount() >= player1.GetShipSquareCount())
                    {
                        // Player 1 loses
                        Console.WriteLine(player1.GetName() + " has no ships left. They have walked the plank.");
                        end = true;
                    }
                    if (player2.grid.GetBombedShipsCount() >= player2.GetShipSquareCount())
                    {
                        // Player 2 loses
                        Console.WriteLine(player2.GetName() + " has no ships left. They have walked the plank.");
                        end = true;
                    }
                }
            }

            Console.WriteLine("Game over");
            Console.ReadLine();
        }

        // Move to Grid class?, move to UI class?
        //private static void PrintGrid(Player player)
        //{
        //    foreach (Square square in player.grid.)
        //    {
        //        // ALL GRID (SEA)
        //        Console.BackgroundColor = ConsoleColor.Blue;

        //        // BOAT
        //        Console.BackgroundColor = ConsoleColor.DarkGray;

        //        // BOMBED SHIP
        //        Console.Write("X");
        //        Console.BackgroundColor = ConsoleColor.Red;

        //        // BOMB
        //        Console.Write("X");
        //        Console.BackgroundColor = ConsoleColor.Blue;
        //    }
        //}
    }
}
