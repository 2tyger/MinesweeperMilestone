namespace MinesweeperGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelGameBoard = new Panel();
            btnRestart = new Button();
            label1 = new Label();
            lblStartTime = new Label();
            label3 = new Label();
            lblScore = new Label();
            SuspendLayout();
            // 
            // panelGameBoard
            // 
            panelGameBoard.AutoSize = true;
            panelGameBoard.BackgroundImageLayout = ImageLayout.Center;
            panelGameBoard.Location = new Point(12, 12);
            panelGameBoard.Name = "panelGameBoard";
            panelGameBoard.Size = new Size(467, 426);
            panelGameBoard.TabIndex = 0;
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(497, 103);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(75, 23);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(497, 12);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 2;
            label1.Text = "Timer:";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(497, 27);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(38, 15);
            lblStartTime.TabIndex = 3;
            lblStartTime.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(496, 56);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(497, 71);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(38, 15);
            lblScore.TabIndex = 5;
            lblScore.Text = "label4";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 450);
            Controls.Add(lblScore);
            Controls.Add(label3);
            Controls.Add(lblStartTime);
            Controls.Add(label1);
            Controls.Add(btnRestart);
            Controls.Add(panelGameBoard);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelGameBoard;
        private Button btnRestart;
        private Label label1;
        private Label lblStartTime;
        private Label label3;
        private Label lblScore;
    }
}
