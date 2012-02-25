using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Grid
    {
        // Initialize the grid
        int xSize;
        int ySize;
        List<Square> grid = new List<Square>();

        public Grid(int inXSize, int inYSize)
        {
            xSize = inXSize;
            ySize = inYSize;

            // Create the grid using a funky-for-loop-solution
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    Square sq = new Square(x, y);
                    grid.Add(sq);
                }
            }
        }

        public bool CheckShipPosition(int x, int y, Ship s)
        {
            if (s.O == Ship.Orientation.Horizontal)
            {
                int shipSize = s.Size;
                for (int i = 0; i < shipSize; i++)
                {
                    Square sq = GetSquare(x + i, y);
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
                    Square sq = GetSquare(x, y + i);
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

        public bool PositionShip(int x, int y, Ship s)
        {
            if (CheckShipPosition(x, y, s))
            {
                if (s.O == Ship.Orientation.Horizontal)
                {
                    int shipSize = s.Size;
                    for (int i = 0; i < shipSize; i++)
                    {
                        Square sq = GetSquare(x + i, y);
                        sq.Ship = s;
                    }
                }
                else if (s.O == Ship.Orientation.Vertical)
                {
                    int shipSize = s.Size;
                    for (int i = 0; i < shipSize; i++)
                    {
                        Square sq = GetSquare(x, y + i);
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

        private Square GetSquare(int x, int y)
        {
            foreach(Square square in grid)
            {
                if ((x == square.C.X) && (y == square.C.Y))
                {
                    return square;
                }
            }
            return null;
        }

        private bool SetSquare(int x, int y, Square inSquare) // This isn't even being used?
        {
            Square foundSquare = null;
            foreach (Square square in grid)
            {
                if ((x == square.C.X) && (y == square.C.Y))
                {
                    foundSquare = inSquare;
                    return true;
                }
            }

            if (foundSquare == null)
            {
                return false;
            }

            foundSquare = inSquare;
            return true;
        }

        public bool MakeGuess(int x, int y)
        {
            Square sq = GetSquare(x, y);
            if (sq.Bombed)
            {
                // TODO: Why you trying to bomb something twice, fool
            }
            else
            {
                sq.Bombed = true;
            }

            if (sq.Ship != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetBombedSquaresCount() // TODO: Do we even need this method?
        {
            int count = 0;
            foreach (Square sq in grid)
            {
                if (sq.Bombed)
                {
                    count++;
                }
            }
            return count;
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
