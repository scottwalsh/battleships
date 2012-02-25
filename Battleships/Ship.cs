using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Ship
    {
        readonly string name;
        public string Name { get; set; }

        readonly int size;
        public int Size { get; set; }

        public enum Orientation { Vertical, Horizontal };
        readonly Orientation o;
        public Orientation O { get; set; }

        //TODO: Add list of coordinates

        readonly bool positioned;
        public bool Positioned { get; set; }

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
            Positioned = false;
        }
    }
}
