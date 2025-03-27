namespace MinesweeperGUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBarSize = new TrackBar();
            trackBarBombs = new TrackBar();
            lblBombsValue = new Label();
            lblSizeValue = new Label();
            button1 = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBarSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBombs).BeginInit();
            SuspendLayout();
            // 
            // trackBarSize
            // 
            trackBarSize.Location = new Point(12, 58);
            trackBarSize.Name = "trackBarSize";
            trackBarSize.Size = new Size(190, 45);
            trackBarSize.TabIndex = 0;
            // 
            // trackBarBombs
            // 
            trackBarBombs.Location = new Point(12, 124);
            trackBarBombs.Name = "trackBarBombs";
            trackBarBombs.Size = new Size(190, 45);
            trackBarBombs.TabIndex = 1;
            // 
            // lblBombsValue
            // 
            lblBombsValue.AutoSize = true;
            lblBombsValue.Location = new Point(12, 106);
            lblBombsValue.Name = "lblBombsValue";
            lblBombsValue.Size = new Size(87, 15);
            lblBombsValue.TabIndex = 2;
            lblBombsValue.Text = "Percent Bombs";
            // 
            // lblSizeValue
            // 
            lblSizeValue.AutoSize = true;
            lblSizeValue.Location = new Point(12, 40);
            lblSizeValue.Name = "lblSizeValue";
            lblSizeValue.Size = new Size(27, 15);
            lblSizeValue.TabIndex = 3;
            lblSizeValue.Text = "Size";
            // 
            // button1
            // 
            button1.Location = new Point(69, 175);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Play";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnPlay_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 5;
            label3.Text = "Play Minesweeper";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(213, 215);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(lblSizeValue);
            Controls.Add(lblBombsValue);
            Controls.Add(trackBarBombs);
            Controls.Add(trackBarSize);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)trackBarSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBombs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBarSize;
        private TrackBar trackBarBombs;
        private Label lblBombsValue;
        private Label lblSizeValue;
        private Button button1;
        private Label label3;
    }
}