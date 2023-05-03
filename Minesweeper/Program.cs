using System;
using System.Collections.Generic;

namespace Minesweeper
{
   
    class Program
    {
        static void Main(string[] args)
        {
            MinesweeperGame game = new MinesweeperGame();
            game.PlaceMines();
            game.PrintBoard();

            while (true)
            {
                Console.WriteLine("Enter direction (up, down, left, right):");
                string direction = Console.ReadLine();
                bool continueGame = game.MovePlayer(direction);
                if (!continueGame)
                {
                    break;
                }
            }
        }
    }
}



