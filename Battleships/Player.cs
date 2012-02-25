using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Player
    {
        readonly string name;
        public string Name { get; private set; }

        readonly List<Ship> ships;
        public List<Ship> Ships { get; private set; }

        readonly Grid g;
        public Grid G { get; set; }

        public Player(string name)
        {
            Name = name;
            G = new Grid(8, 8);

            //TODO: Ships cannot be larger than grid
            Ships = new List<Ship>();
            Ship aircraftcarrier = new Ship("Aircraft Carrier", 5);
            Ship battleship = new Ship("Battleship", 4);
            Ship destroyer = new Ship("Destroyer", 3);
            Ship submarine = new Ship("Submarine", 3);
            Ship patrolboat = new Ship("Patrol Boat", 2);
            Ships.Add(aircraftcarrier);
            Ships.Add(battleship);
            Ships.Add(destroyer);
            Ships.Add(submarine);
            Ships.Add(patrolboat);
        }



        // End state
        // For this to work all ships in the ships list must be placed on the grid
        public bool HasLost()
        {
            if (G.GetBombedShipSquareCount() >= G.GetShipSquareCount())
            {
                return true;
            }
            return false;
        }
    }
}
