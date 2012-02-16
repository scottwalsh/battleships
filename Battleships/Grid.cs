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
            if (s.GetOrientation() == Ship.Orientation.Horizontal)
            {
                int shipSize = s.GetSize();
                for (int i = 0; i < shipSize; i++)
                {
                    Square sq = GetSquare(x + i, y);
                    if (sq != null && !sq.ContainsShip())
                    {
                        // WOOP! Success
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (s.GetOrientation() == Ship.Orientation.Vertical)
            {
                int shipSize = s.GetSize();
                for (int i = 0; i < shipSize; i++)
                {
                    Square sq = GetSquare(x, y + i);
                    if (sq != null && !sq.ContainsShip())
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
                if (s.GetOrientation() == Ship.Orientation.Horizontal)
                {
                    int shipSize = s.GetSize();
                    for (int i = 0; i < shipSize; i++)
                    {
                        Square sq = GetSquare(x + i, y);
                        sq.SetShip(s);
                    }
                }
                else if (s.GetOrientation() == Ship.Orientation.Vertical)
                {
                    int shipSize = s.GetSize();
                    for (int i = 0; i < shipSize; i++)
                    {
                        Square sq = GetSquare(x, y + i);
                        sq.SetShip(s);
                    }
                }
                return true;
            }
            else
            {
                throw new Exception();
                return false;
            }
            
        }

        private Square GetSquare(int x, int y)
        {
            foreach(Square square in grid)
            {
                if ((x == square.GetX()) && (y == square.GetY()))
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
                if ((x == square.GetX()) && (y == square.GetY()))
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
            if (sq.IsBombed())
            {
                // Why you trying to bomb something twice, fool
            }
            else
            {
                sq.Bomb();
            }

            if (sq.ContainsShip())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetBombedSquaresCount()
        {
            int count = 0;
            foreach (Square sq in grid)
            {
                if (sq.IsBombed())
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
                if (sq.IsBombed() && sq.ContainsShip())
                {
                    count++;
                }
            }
            return count;
        }
    }
}
