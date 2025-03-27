using System;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form2 : Form
    {
        public int BoardSize { get; private set; }
        public int BombPercentage { get; private set; }

        public Form2()
        {
            InitializeComponent();

            // set valid range before assigning values
            trackBarSize.Minimum = 5;
            trackBarSize.Maximum = 20;

            trackBarBombs.Minimum = 5;
            trackBarBombs.Maximum = 50; // ensure its greater than or equal to 20

            // set default values within valid range
            trackBarSize.Value = 10;
            trackBarBombs.Value = 20;

            lblSizeValue.Text = trackBarSize.Value.ToString();
            lblBombsValue.Text = trackBarBombs.Value + "%";

            // update labels dynamically when trackbars move
            trackBarSize.Scroll += (s, e) => lblSizeValue.Text = trackBarSize.Value.ToString();
            trackBarBombs.Scroll += (s, e) => lblBombsValue.Text = trackBarBombs.Value + "%";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // get selected values
            BoardSize = trackBarSize.Value;
            BombPercentage = trackBarBombs.Value;

            // pass data to Form1 and start the game
            Form1 gameForm = new Form1(BoardSize, BombPercentage);
            gameForm.Show();
            this.Hide(); // hide Form2 after starting the game
        }
    }
}
