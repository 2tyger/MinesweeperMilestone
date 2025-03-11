using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperModel
{
    // represents a single cell in the minesweeper board
    public class Cell
    {
        public int Row { get; set; }  // row index of the cell
        public int Column { get; set; }  // column index of the cell
        public bool IsVisited { get; set; } = false;  // tracks if the player has visited this cell
        public bool IsBomb { get; set; } = false;  // true if the cell contains a bomb
        public bool IsFlagged { get; set; } = false;  // true if the player has flagged this cell
        public int NumberOfBombNeighbors { get; set; } = 0;  // counts adjacent bombs
        public bool HasSpecialReward { get; set; } = false;  // true if this cell has a reward
    }
}
