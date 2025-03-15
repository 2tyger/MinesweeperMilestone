namespace MinesweeperModel
{
    // represents possible game states
    public enum GameState
    {
        InProgress, // game is in progress
        Won, // player successfully cleared all safe cells
        Lost // player hit a bomb and lost
    }

    // minesweeper game board
    public class Board
    {
        public int Size { get; } // size of the board
        public Cell[,] Cells { get; } // 2d array of cells
        public GameState State { get; private set; } = GameState.InProgress; // current game state
        private int TotalBombs; // total number of bombs on board
        public bool RewardCollected { get; private set; } = false; // tracks if the reward was collected
        private int rewardRow, rewardCol; // stores reward location

        public Board(int size, int bombCount)
        {
            Size = size;
            TotalBombs = bombCount;
            Cells = new Cell[size, size];

            InitializeBoard(); // create empty board
            PlaceReward();  // place reward first so no bombs appear on it
            SetupBombs();   // place bombs in random spots
            CountBombsNearby(); // calculate number of nearby bombs for each cell
        }

        private void InitializeBoard()
        {
            // creates empty board with default cells
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Cells[row, col] = new Cell { Row = row, Column = col };
                }
            }
        }

        // recursive flood fill algorithm to reveal empty areas
        public void FloodFill(int row, int col)
        {
            // check if the cell is out of bounds or already visited
            if (row < 0 || row >= Size || col < 0 || col >= Size)
                return;

            if (Cells[row, col].IsVisited || Cells[row, col].IsFlagged)
                return;

            if (Cells[row, col].IsBomb)
                return; // do not reveal bombs

            // mark the cell as visited
            Cells[row, col].IsVisited = true;

            // if the cell has neighboring bombs, stop the recursion here
            if (Cells[row, col].NumberOfBombNeighbors > 0)
                return;

            // recursive call floodfill on surrounding (8) cells
            FloodFill(row - 1, col); // up
            FloodFill(row + 1, col); // down
            FloodFill(row, col - 1); // left
            FloodFill(row, col + 1); // right
            FloodFill(row - 1, col - 1); // topleft
            FloodFill(row - 1, col + 1); // topright
            FloodFill(row + 1, col - 1); // bottomleft
            FloodFill(row + 1, col + 1); // bottomright

            // check if all safe cells are visited
            DetermineGameState();
        }

        private void PlaceReward()
        {
            // randomly select cell for reward and ensures that no bomb is placed there
            Random rand = new Random();
            rewardRow = rand.Next(Size);
            rewardCol = rand.Next(Size);
            Cells[rewardRow, rewardCol].HasSpecialReward = true;
        }

        private void SetupBombs()
        {
            // places bomb randomly ensuring no bomb is placed in reward location
            Random rand = new Random();
            int bombsPlaced = 0;

            while (bombsPlaced < TotalBombs)
            {
                int row = rand.Next(Size);
                int col = rand.Next(Size);

                if (!Cells[row, col].IsBomb && !Cells[row, col].HasSpecialReward) // no bomb under reward
                {
                    Cells[row, col].IsBomb = true;
                    bombsPlaced++;
                }
            }
        }

        private void CountBombsNearby()
        {
            // counts how many bombs are in adjacent cells for each cell
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (!Cells[row, col].IsBomb)
                    {
                        Cells[row, col].NumberOfBombNeighbors = GetNeighborBombCount(row, col);
                    }
                }
            }
        }

        private int GetNeighborBombCount(int row, int col)
        {
            // checks all adjacent cells and counts the number of bombs
            int count = 0;
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r >= 0 && r < Size && c >= 0 && c < Size && Cells[r, c].IsBomb)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public GameState DetermineGameState()
        {
            // checks if win or lose
            if (Cells.Cast<Cell>().Any(cell => cell.IsBomb && cell.IsVisited))
            {
                State = GameState.Lost;
            }
            else if (Cells.Cast<Cell>().All(cell => cell.IsBomb || cell.IsVisited))
            {
                State = GameState.Won;
            }
            return State;
        }

        public void PrintBoard(bool revealBombs = false)
        {
            Console.WriteLine("\nHere is the current board\n");

            // print column numbers
            Console.Write("    ");
            for (int i = 0; i < Size; i++)
                Console.Write($" {i}  ");
            Console.WriteLine();

            // print top border
            Console.Write("   +" + new string('-', Size * 4) + "+\n");

            for (int row = 0; row < Size; row++)
            {
                Console.Write($" {row} |");
                for (int col = 0; col < Size; col++)
                {
                    var cell = Cells[row, col];

                    if (revealBombs && cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                    }
                    else if (cell.HasSpecialReward && !cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" r ");
                    }
                    else if (cell.IsVisited || revealBombs)
                    {
                        switch (cell.NumberOfBombNeighbors)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                        }

                        if (cell.NumberOfBombNeighbors > 0)
                            Console.Write($" {cell.NumberOfBombNeighbors} ");
                        else
                            Console.Write(" . ");
                    }
                    else if (cell.IsFlagged)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" F ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ? ");
                    }
                    Console.ResetColor();
                    Console.Write("|"); // divider between cells
                }
                Console.WriteLine();
                Console.Write("   +" + new string('-', Size * 4) + "+\n"); // row divider
            }
        }
    }
}
