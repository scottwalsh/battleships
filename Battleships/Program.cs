using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Welcome to battleships.");

            game.PositionShips();
            game.TakeTurns();

            Console.WriteLine("Game over");
            Console.ReadLine();
        }

        //// Move to Grid class?, move to UI class?
        //private static void PrintGrid(Player player)
        //{
        //    foreach (Square square in player.GameGrid)
        //    {
        //        if (square.Bombed && square.Ship != null)
        //        {
        //            Console.Write("X");
        //            Console.BackgroundColor = ConsoleColor.Red;
        //        }
        //        else if (square.Ship != null)
        //        {
        //            Console.Write(" ");
        //            Console.BackgroundColor = ConsoleColor.DarkGray;
        //        }
        //        else if (square.Bombed)
        //        {
        //            Console.Write("X");
        //            Console.BackgroundColor = ConsoleColor.Blue;
        //        }
        //        else // EMPTY, SEA
        //        {
        //            Console.Write(" ");
        //            Console.BackgroundColor = ConsoleColor.Blue;
        //        }
        //    }
        //}
    }
}
