using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using MinesweeperModel;
using Timer = System.Windows.Forms.Timer;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        private int boardSize;
        private int bombPercentage;
        private Board board;
        private Button[,]? buttons;
        private DateTime gameStartTime;
        private bool rewardUsed = false;
        private Timer gameTimer;
        private int elapsedSeconds = 0;

        public Form1(int size, int bombs)
        {
            InitializeComponent();
            boardSize = size;
            bombPercentage = bombs;

            board = new Board(boardSize, bombPercentage);
            //board.InitializeBoard();

            InitializeGameBoard();
        }

        private void InitializeGameBoard()
        {
            lblStartTime.Text = "0s";
            lblScore.Text = "0";
            gameStartTime = DateTime.Now;
            panelGameBoard.Controls.Clear();
            GenerateGrid();

            UpdateButtonFaces();

            elapsedSeconds = 0;
            lblStartTime.Text = "0s";

            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second
            gameTimer.Tick += (s, e) =>
            {
                elapsedSeconds++;
                lblStartTime.Text = $"{elapsedSeconds}s";
            };
            gameTimer.Start();

        }

        private void GenerateGrid()
        {
            panelGameBoard.Controls.Clear(); // clear previous game board
            int tileSize = Math.Min(panelGameBoard.Width, panelGameBoard.Height) / boardSize;

            buttons = new Button[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(col * tileSize, row * tileSize),
                        Tag = new Point(row, col),
                        BackColor = Color.Gray
                    };


                    btn.MouseDown += Button_MouseDown;
                    buttons[row, col] = btn;
                    panelGameBoard.Controls.Add(btn);
                }
            }


            panelGameBoard.Invalidate();
            panelGameBoard.Update();
        }

        private void UpdateButtonFaces()
        {
            Debug.WriteLine("UpdateButtonFaces triggered");

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Button btn = buttons[row, col];
                    Cell cell = board.Cells[row, col];

                    btn.BackgroundImageLayout = ImageLayout.Stretch;

                    if (cell.IsFlagged)
                    {
                        btn.Text = "F";
                        btn.BackColor = Color.LightBlue;
                        btn.BackgroundImage = null;
                    }
                    else if (!cell.IsVisited)
                    {
                        btn.Text = "";
                        btn.BackgroundImage = Properties.Resources.TileFlat;
                    }
                    else if (cell.IsBomb)
                    {
                        btn.Text = "";
                        btn.BackgroundImage = Properties.Resources.Skull;
                    }
                    else if (cell.HasSpecialReward)
                    {
                        btn.Text = "";
                        btn.BackgroundImage = Properties.Resources.Gold;
                    }
                    else if (cell.NumberOfBombNeighbors >= 1 && cell.NumberOfBombNeighbors <= 8)
                    {
                        btn.Text = "";
                        btn.BackgroundImage = cell.NumberOfBombNeighbors switch
                        {
                            1 => Properties.Resources.Number1,
                            2 => Properties.Resources.Number2,
                            3 => Properties.Resources.Number3,
                            4 => Properties.Resources.Number4,
                            5 => Properties.Resources.Number5,
                            6 => Properties.Resources.Number6,
                            7 => Properties.Resources.Number7,
                            8 => Properties.Resources.Number8,
                            _ => Properties.Resources.TileFlat
                        };
                    }
                    else
                    {
                        btn.Text = "";
                        btn.BackgroundImage = Properties.Resources.Tile2;
                    }

                    btn.Invalidate();
                    btn.Update();
                }
            }

            panelGameBoard.Invalidate();
            panelGameBoard.Update();
            panelGameBoard.Refresh();
        }

        private void EndGameWithScore()
        {
            gameTimer?.Stop(); // stop timer when winning

            TimeSpan duration = DateTime.Now - gameStartTime;
            int sizeFactor = boardSize;
            int difficultyFactor = bombPercentage;
            int timePenalty = (int)duration.TotalSeconds;
            int baseScore = (sizeFactor * difficultyFactor * 10) - timePenalty;
            if (baseScore < 0) baseScore = 0;
            lblScore.Text = baseScore.ToString();

            MessageBox.Show($"You won!\nScore: {baseScore}\nTime: {duration.TotalSeconds:F1} seconds", "Victory!");

            using Form3 nameForm = new Form3(baseScore);
            if (nameForm.ShowDialog() == DialogResult.OK)
            {
                using Form4 scoreForm = new Form4(nameForm.PlayerName, baseScore);
                scoreForm.ShowDialog();
            }
        }




        private void btnRestart_Click(object sender, EventArgs e)
        {
            gameTimer?.Stop();
            board = new Board(boardSize, bombPercentage);
            rewardUsed = false;
            InitializeGameBoard();
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            Point pos = (Point)btn.Tag;
            int row = pos.X;
            int col = pos.Y;
            Cell cell = board.Cells[row, col];

            if (e.Button == MouseButtons.Right)
            {
                // flag toggle
                cell.IsFlagged = !cell.IsFlagged;
                UpdateButtonFaces();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                // reward usage
                if (!rewardUsed && board.RewardCollected)
                {
                    rewardUsed = true;
                    string message = cell.IsBomb
                        ? "This cell contains a BOMB!"
                        : $"This cell has {cell.NumberOfBombNeighbors} neighboring bombs.";
                    MessageBox.Show(message, "Reward Used");
                }
                else if (!board.RewardCollected)
                {
                    MessageBox.Show("You haven't collected a reward yet!", "No Reward");
                }
                else
                {
                    MessageBox.Show("You've already used your reward!", "Reward Expired");
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                // regular tile reveal
                if (!cell.IsVisited && !cell.IsFlagged)
                {
                    if (cell.IsBomb)
                    {
                        cell.IsVisited = true;
                        UpdateButtonFaces();
                        gameTimer.Stop(); // stop timer on loss

                        int sizeFactor = boardSize;
                        int difficultyFactor = bombPercentage;
                        int timePenalty = elapsedSeconds;
                        int baseScore = (sizeFactor * difficultyFactor * 10) - timePenalty;
                        if (baseScore < 0) baseScore = 0;
                        lblScore.Text = baseScore.ToString(); // show score on loss

                        MessageBox.Show($"Game Over!\nScore: {baseScore}\nTime: {elapsedSeconds} seconds", "Bomb hit!");
                        board.PrintBoard(true);
                        return;
                    }

                    else if (cell.HasSpecialReward)
                    {
                        MessageBox.Show("You found a reward! You can peek at any cell.");
                        cell.HasSpecialReward = false;
                        board.RewardCollected = true;
                    }
                    else if (cell.NumberOfBombNeighbors == 0)
                    {
                        board.FloodFill(row, col);
                    }
                    else
                    {
                        cell.IsVisited = true;
                    }

                    if (board.DetermineGameState() == GameState.Won)
                    {
                        EndGameWithScore();
                    }

                    UpdateButtonFaces();
                }
            }
        }
    }
}
