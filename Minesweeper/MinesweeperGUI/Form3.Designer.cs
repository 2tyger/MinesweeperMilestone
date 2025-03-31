namespace MinesweeperGUI
{
    partial class Form3
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
            label1 = new Label();
            txtName = new TextBox();
            lblScore = new Label();
            btnOK = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(233, 15);
            label1.TabIndex = 0;
            label1.Text = "Congratulations you win. Enter your name.";
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(233, 23);
            txtName.TabIndex = 1;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(12, 53);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(39, 15);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(89, 76);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 112);
            Controls.Add(btnOK);
            Controls.Add(lblScore);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label lblScore;
        private Button btnOK;
    }
}