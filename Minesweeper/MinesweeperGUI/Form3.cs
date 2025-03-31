using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class Form3 : Form
    {
        public string PlayerName {  get; set; }

        public Form3(int score)
        {
            InitializeComponent();
            lblScore.Text = $"Score: {score}";

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PlayerName = txtName.Text.Trim();
            if (string.IsNullOrEmpty(PlayerName))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
