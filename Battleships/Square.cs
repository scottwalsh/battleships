using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Square
    {
        readonly Coordinate c;
        public Coordinate C { get; set; }

        readonly bool bombed;
        public bool Bombed { get; set; }
        
        readonly Ship ship;
        public Ship Ship { get; set; }

        public Square(int x, int y)
        {
            C = new Coordinate(x, y);
            bombed = false;
        }
    }
}
