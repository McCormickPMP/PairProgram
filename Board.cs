using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgramming
{
    public class Board
    {
        char[,] grid = new char[3, 3];

        char[,] getGrid()
        {
            return grid;
        }
        void setGrid(char[,] board)
        {
            grid = board;
        }
        bool CheckWin(char[,] board)
        {
            bool result = false;
            //check rows
            for (int i = 0; i < 3; i++)
            {
                char firstChar = board[i, 0];
                if ((firstChar == 'X') || (firstChar == 'O'))
                {
                    if ((board[i, 0] == board[i, 1]) && (board[i, 0] == board[i, 2]))
                    {
                        result = true;
                    }
                }
            }
            //check column
            for (int i = 0; i < 3; i++)
            {
                char firstChar = board[0, i];
                if ((firstChar == 'X') || (firstChar == 'O'))
                {
                    if ((board[0, i] == board[1, i]) && (board[0, i] == board[2, i]))
                    {
                        result = true;
                    }
                }
            }
            //check diagonal
            char cornerCell1 = board[0, 0];

            if (cornerCell1 == 'X' || cornerCell1 == 'O')
            {
                if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
                {
                    result = true;
                }
            }
            char cornerCell3 = board[0, 2];

            if (cornerCell3 == 'X' || cornerCell3 == 'O')
            {
                if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
                {
                    result = true;
                }
            }
            return result;
        }
        bool CheckFull(char[,] board)
        {
            bool result = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != 'X' && board[i, j] != 'O')
                    {
                        result = false;
                    }
                }
            }
            return result;
        }
        public void Run()
        {
            bool gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("Hello and welcome to Tic Tac Toe!");
                Console.WriteLine("\n");
                Console.WriteLine("How many human players? (Expected answer: 2): ");
                string numPlayers = Console.ReadLine();
                Console.Clear();

                if (numPlayers == "2")
                {
                    //declare and initialize our grid to 1-9
                    char[,] grid = new char[3, 3];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            grid[i, j] = (char)(j + (3 * i) + 49);
                        }
                    }
                    bool isWon = false;
                    bool isFull = false;
                    string player = "X";
                    string userMoveString = "";
                    char userMoveChar = (char)0;
                    int roundCount = 1;
                    while (!isWon && !isFull)
                    {
                        Console.WriteLine("Round " + roundCount);
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine(grid[i, 0] + "|" + grid[i, 1] + "|" + grid[i, 2]);
                        }
                        Console.WriteLine(player + "'s turn to move.");
                        bool validMove = false;
                        //force them to make a valid move
                        while (validMove != true)
                        {
                            Console.WriteLine("Enter a number: ");
                            userMoveString = Console.ReadLine();
                            userMoveChar = userMoveString[0];
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (userMoveChar == grid[i, j])
                                    {
                                        validMove = true;
                                        grid[i, j] = player[0];
                                    }
                                }
                            }
                            if (!validMove)
                            {
                                Console.WriteLine("Number invalid!");
                            }
                        }
                        isWon = CheckWin(grid);
                        if (isWon)
                        {
                            break;
                        }
                        isFull = CheckFull(grid);
                        if (isFull)
                        {
                            break;
                        }
                        if (player == "O")
                        {
                            roundCount = roundCount + 1;
                            player = "X";
                        }
                        else
                        {
                            player = "O";
                        }
                        Console.Clear();
                    }
                    Console.WriteLine("\n");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine(grid[i, 0] + "|" + grid[i, 1] + "|" + grid[i, 2]);
                    }
                    if (isWon)
                    {
                        Console.WriteLine("Player " + player + " is the winner!");
                    }
                    if (isFull)
                    {
                        Console.WriteLine("Draw!");
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("Again?:");
                Console.ReadLine();
            }
        }
    }
}
