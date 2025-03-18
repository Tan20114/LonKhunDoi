namespace YellowWin
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlayerWin = new System.Windows.Forms.Label();
            this.PlayAgain = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.LetterExit = new System.Windows.Forms.Label();
            this.LetterPlay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayAgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PlayerWin
            // 
            this.PlayerWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PlayerWin.Location = new System.Drawing.Point(468, 34);
            this.PlayerWin.Name = "PlayerWin";
            this.PlayerWin.Size = new System.Drawing.Size(1212, 250);
            this.PlayerWin.TabIndex = 1;
            this.PlayerWin.Text = "Player 2 Is Winner";
            this.PlayerWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlayerWin.Click += new System.EventHandler(this.PlayerWin_Click);
            // 
            // PlayAgain
            // 
            this.PlayAgain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PlayAgain.Location = new System.Drawing.Point(651, 315);
            this.PlayAgain.Name = "PlayAgain";
            this.PlayAgain.Size = new System.Drawing.Size(800, 260);
            this.PlayAgain.TabIndex = 2;
            this.PlayAgain.TabStop = false;
            // 
            // Exit
            // 
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.Location = new System.Drawing.Point(651, 698);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(800, 260);
            this.Exit.TabIndex = 3;
            this.Exit.TabStop = false;
            // 
            // LetterExit
            // 
            this.LetterExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LetterExit.Location = new System.Drawing.Point(760, 751);
            this.LetterExit.Name = "LetterExit";
            this.LetterExit.Size = new System.Drawing.Size(600, 160);
            this.LetterExit.TabIndex = 4;
            this.LetterExit.Text = "Exit";
            this.LetterExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LetterExit.Click += new System.EventHandler(this.label1_Click);
            // 
            // LetterPlay
            // 
            this.LetterPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LetterPlay.Location = new System.Drawing.Point(760, 366);
            this.LetterPlay.Name = "LetterPlay";
            this.LetterPlay.Size = new System.Drawing.Size(600, 160);
            this.LetterPlay.TabIndex = 5;
            this.LetterPlay.Text = "Play Again";
            this.LetterPlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.LetterPlay);
            this.Controls.Add(this.LetterExit);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.PlayAgain);
            this.Controls.Add(this.PlayerWin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayAgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label PlayerWin;
        private System.Windows.Forms.PictureBox PlayAgain;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.Label LetterExit;
        private System.Windows.Forms.Label LetterPlay;
    }
}

