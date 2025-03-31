using MinesweeperModel;
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
    public partial class Form4 : Form
    {
        private static List<GameStat> statList = new List<GameStat>();
        private GameStat gameStat;
        private BindingSource bindingSource = new BindingSource();

        public Form4(string name, int score)
        {
            InitializeComponent();

            GameStat gameStat = new GameStat
            {
                Name = name,
                Score = score,
                Date = DateTime.Now,
                Id = GameStatManager.Stats.Count + 1
            };

            GameStatManager.Stats.Add(gameStat);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GameStatManager.Stats;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter writer = new StreamWriter(sfd.FileName);
                foreach (var stat in statList)
                {
                    writer.WriteLine($"{stat.Id},{stat.Name},{stat.Score},{stat.Date}");
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                statList.Clear();
                foreach (var line in File.ReadAllLines(ofd.FileName))
                {
                    var parts = line.Split(',');
                    statList.Add(new GameStat
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Score = int.Parse(parts[2]),
                        Date = DateTime.Parse(parts[3])
                    });
                }

                bindingSource.DataSource = null;
                bindingSource.DataSource = statList;
                dataGridView1.DataSource = bindingSource;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderBy(s => s.Name).ToList();
            RefreshGrid();
        }

        private void byScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Score).ToList();
            RefreshGrid();
        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statList = statList.OrderByDescending(s => s.Date).ToList();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            bindingSource.DataSource = null;
            bindingSource.DataSource = statList;
            dataGridView1.DataSource = bindingSource;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}