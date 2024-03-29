﻿using System;
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

        public Square(Coordinate c)
        {
            C = c;
            bombed = false;
        }

        public Square(int x, int y) // Might no longer be needed
        {
            C = new Coordinate(x, y);
            bombed = false;
        }
    }
}
