using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Coordinate
    {
        readonly int x;
        public int X { get; set; }

        readonly int y;
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        // TODO: Could overload == operator
        public bool Equals(Coordinate other)
        {
            if (other == null)
            {
                return false;
            }

            return this.X == other.X && this.Y == other.Y;
        }
    }
}
