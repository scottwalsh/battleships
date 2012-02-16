using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Player
    {
        string name;
        List<Ship> ships = new List<Ship>();
        public Grid grid;

        public Player(string inName)
        {
            name = inName;
            grid = new Grid(8, 8);

            //Ships cannot be larger than grid

            ships = new List<Ship>();
            Ship patrolboat = new Ship("Patrol Boat", 2);
            Ship submarine = new Ship("Submarine", 3);
            Ship destroyer = new Ship("Destroyer", 3);
            Ship battleship = new Ship("Battleship", 4);
            Ship aircraftcarrier = new Ship("Aircraft Carrier", 5);
            ships.Add(patrolboat);
            ships.Add(submarine);
            ships.Add(destroyer);
            ships.Add(battleship);
            ships.Add(aircraftcarrier);
        }

        public string GetName()
        {
            return name;
        }

        public List<Ship> GetShips()
        {
            return ships;
        }

        public int GetShipSquareCount()
        {
            int count = 0;
            foreach (Ship ship in ships)
            {
                count += ship.GetSize();
            }
            return count;
        }
    }
}
