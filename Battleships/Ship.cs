using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Ship
    {
        public enum Orientation { Vertical, Horizontal };

        string name;
        int size;
        Orientation orientation;
        bool positioned = false;

        public Ship(string inName, int inSize)
        {
            name = inName;
            size = inSize;
        }

        public string GetName()
        {
            return name;
        }

        public int GetSize()
        {
            return size;
        }

        public Orientation GetOrientation()
        {
            return orientation;
        }

        public bool SetOrientation(Orientation inOrientation)
        {
            orientation = inOrientation;
            return true;
        }

        public bool IsPositioned()
        {
            return positioned;
        }

        public bool SetAsPositioned()
        {
            positioned = true;
            return true;
        }
    }
}
