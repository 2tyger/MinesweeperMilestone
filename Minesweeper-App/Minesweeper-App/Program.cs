using System;
using MinesweeperModel;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Minesweeper!");

        // ask for board size
        Console.Write("Enter board size (e.g., 5, 10, 15): ");
        int boardSize = int.Parse(Console.ReadLine());

        // ask for number of bombs
        Console.Write("Enter number of bombs: ");
        int bombCount = int.Parse(Console.ReadLine());

        // create new game with given size and bomb count
        Board board = new Board(boardSize, bombCount);
        bool gameRunning = true; // flag to keep track of game state
        bool rewardAvailable = false; // flag to track reward

        // main game loop that continues to win or lose
        while (gameRunning)
        {

            // display current board state
            board.PrintBoard();

            // ask for row and column
            Console.Write("\nEnter the row number: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter the column number: ");
            int col = int.Parse(Console.ReadLine());

            // ask for action
            Console.Write("Enter 1 to visit the cell, 2 to flag the cell, 3 to use reward: ");
            int action = int.Parse(Console.ReadLine());

            if (action == 2)
            {
                // mark flagged
                board.Cells[row, col].IsFlagged = true;
            }
            else if (action == 1)
            {
                // visit
                if (!board.Cells[row, col].IsVisited)
                {
                    if (board.Cells[row, col].NumberOfBombNeighbors == 0)
                    {
                        // trigger flood fill to reveal surrounding empty space
                        board.FloodFill(row, col);
                    }
                    else
                    {
                        // reveal only this cell
                        board.Cells[row, col].IsVisited = true;
                    }
                }

                if (board.DetermineGameState() == GameState.Won)
                {
                    Console.WriteLine("\nCongratulations! You won the game!");
                    board.PrintBoard(true); // reveal full board
                    break; // exit loop
                }

                if (board.Cells[row, col].IsBomb)
                {
                    Console.WriteLine("\nYou hit a bomb! game over.");
                    Console.WriteLine("here is the full board:");
                    board.PrintBoard(true);
                    break;
                }

                if (board.Cells[row, col].HasSpecialReward)
                {
                    Console.WriteLine("\nYou found a special reward!");
                    rewardAvailable = true;
                    board.Cells[row, col].HasSpecialReward = false;
                }
            }
            else if (action == 3)
            {
                if (rewardAvailable)
                {
                    // allow peek as reward
                    Console.Write("\nEnter row to peek: ");
                    int peekRow = int.Parse(Console.ReadLine());
                    Console.Write("Enter column to peek: ");
                    int peekCol = int.Parse(Console.ReadLine());

                    if (board.Cells[peekRow, peekCol].IsBomb)
                    {
                        // reveal bomb // color
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPeek Result: This cell contains a BOMB!");
                    }
                    else
                    {
                        // reveal neighboring bomb number // color
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\nPeek Result: This cell has {board.Cells[peekRow, peekCol].NumberOfBombNeighbors} neighboring bombs.");
                    }
                    Console.ResetColor();
                    rewardAvailable = false; // reward has one use
                }
                else
                {
                    Console.WriteLine("\nNo reward available to use!");
                }
            }
        }
    }
}

