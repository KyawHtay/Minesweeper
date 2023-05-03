using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MinesweeperGame
{
    private char[,] board;
    private List<int[]> mines;
    private int[] playerPos;
    private int lives;
    private int moves;

    public MinesweeperGame()
    {
        board = new char[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                board[i, j] = '-';
            }
        }

        mines = new List<int[]>();
        playerPos = new int[2];
        playerPos[0] = 0;
        playerPos[1] = 0;

        lives = 3;
        moves = 0;
    }

    public void PlaceMines()
    {
        Random rand = new Random();
        while (mines.Count < 3)
        {
            int x = rand.Next(5);
            int y = rand.Next(5);
            if (x != 0 && y != 0 && x != 4 && y != 4 && !ContainsMine(x, y))
            {
                mines.Add(new int[] { x, y });
                board[x, y] = 'X';
            }
        }
    }

    private bool ContainsMine(int x, int y)
    {
        foreach (int[] mine in mines)
        {
            if (mine[0] == x && mine[1] == y)
            {
                return true;
            }
        }
        return false;
    }

    public void PrintBoard()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public bool MovePlayer(string direction)
    {
        int[] newPos = new int[2];
        newPos[0] = playerPos[0];
        newPos[1] = playerPos[1];

        if (direction == "up")
        {
            if (playerPos[0] == 0)
            {
                Console.WriteLine("Can't move further up!");
                return true;
            }
            else
            {
                newPos[0] = playerPos[0] - 1;
            }
        }
        else if (direction == "down")
        {
            if (playerPos[0] == 4)
            {
                Console.WriteLine("Can't move further down!");
                return true;
            }
            else
            {
                newPos[0] = playerPos[0] + 1;
            }
        }
        else if (direction == "left")
        {
            if (playerPos[1] == 0)
            {
                Console.WriteLine("Can't move further left!");
                return true;
            }
            else
            {
                newPos[1] = playerPos[1] - 1;
            }
        }
        else if (direction == "right")
        {
            if (playerPos[1] == 4)
            {
                Console.WriteLine("Can't move further right!");
                return true;
            }
            else
            {
                newPos[1] = playerPos[1] + 1;
            }
        }

        moves++;

        if (ContainsMine(newPos[0], newPos[1]))
        {
            Console.WriteLine("Oh no! You hit a mine!");
            lives--;
            board[newPos[0], newPos[1]] = 'X';
            PrintBoard();
            Console.WriteLine("Lives left: " + lives);
            Console.WriteLine("Moves made: " + moves);
            if (lives == 0)
            {
                Console.WriteLine("Game over! You ran out of lives.");
                return false;
            }
            return true;
        }
        else
        {
            board[newPos[0], newPos[1]] = 'P';
            board[playerPos[0], playerPos[1]] = '-';
            playerPos[0] = newPos[0];
            playerPos[1] = newPos[1];
            PrintBoard();
            Console.WriteLine("Lives left: " + lives);
            Console.WriteLine("Moves made: " + moves);
            if (playerPos[0] == 4 && playerPos[1] == 4)
            {
                Console.WriteLine("Congratulations! You made it to the other side!");
                Console.WriteLine("Final score: " + moves);
                return false;
            }
            return true;
        }
    }
}