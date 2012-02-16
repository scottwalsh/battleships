using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Square
    {
        int x;
        int y;
        bool hasShip = false;
        bool bombed = false;
        Ship ship;

        public Square(int inX, int inY)
        {
            x = inX;
            y = inY;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetShip(Ship inShip)
        {
            hasShip = true;
            ship = inShip;
        }

        public bool ContainsShip()
        {
            return hasShip;
        }

        public bool IsBombed()
        {
            return bombed;
        }

        public void Bomb()
        {
             bombed = true;
        }
    }
}
