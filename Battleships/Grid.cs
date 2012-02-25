using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Grid
    {
        // Initialize the grid
        int width;
        int height;
        List<Square> grid = new List<Square>();

        public Grid(int inXSize, int inYSize)
        {
            width = inXSize;
            height = inYSize;

            // Create the grid using a funky-for-loop-solution
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Square sq = new Square(x, y);
                    grid.Add(sq);
                }
            }
        }

        public bool CheckShipPosition(Coordinate c, Ship s)
        {
            if (s.O == Ship.Orientation.Horizontal)
            {
                int shipSize = s.Size;
                for (int i = 0; i < shipSize; i++)
                {
                    c.X += i;
                    Square sq = GetSquare(c);
                    if (sq != null && sq.Ship == null)
                    {
                        // WOOP! Success
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (s.O == Ship.Orientation.Vertical)
            {
                int shipSize = s.Size;
                for (int i = 0; i < shipSize; i++)
                {
                    c.Y += i;
                    Square sq = GetSquare(c);
                    if (sq != null && sq.Ship == null)
                    {
                        // WOOP! Success
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool PositionShip(Coordinate c, Ship s)
        {
            if (CheckShipPosition(c, s))
            {
                if (s.O == Ship.Orientation.Horizontal)
                {
                    int shipSize = s.Size;
                    for (int i = 0; i < shipSize; i++)
                    {
                        c.X += i;
                        Square sq = GetSquare(c);
                        sq.Ship = s;
                    }
                }
                else if (s.O == Ship.Orientation.Vertical)
                {
                    int shipSize = s.Size;
                    for (int i = 0; i < shipSize; i++)
                    {
                        c.Y += i;
                        Square sq = GetSquare(c);
                        sq.Ship = s;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private Square GetSquare(Coordinate c)
        {
            foreach(Square square in grid)
            {
                if (c == square.C)
                {
                    return square;
                }
            }
            return null;
        }

        //private bool SetSquare(Coordinate c, Square inSquare) // This isn't even being used?
        //{
        //    Square foundSquare = null;
        //    foreach (Square square in grid)
        //    {
        //        if (c == square.C)
        //        {
        //            foundSquare = inSquare;
        //            return true;
        //        }
        //    }

        //    if (foundSquare == null)
        //    {
        //        return false;
        //    }

        //    foundSquare = inSquare;
        //    return true;
        //}

        public bool MakeGuess(Coordinate c)
        {
            Square sq = GetSquare(c);
            if (sq.Bombed)
            {
                // TODO: Why you trying to bomb something twice, fool
                return false;
            }
            else
            {
                sq.Bombed = true;
            }

            if (sq.Ship != null)
            {
                
            }
            return true;
        }

        public int GetBombedShipsCount()
        {
            int count = 0;
            foreach (Square sq in grid)
            {
                if (sq.Bombed && sq.Ship != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
