namespace Tantan
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.A_VIsualize = new System.Windows.Forms.Label();
            this.D_Visualize = new System.Windows.Forms.Label();
            this.J_Visualize = new System.Windows.Forms.Label();
            this.L_Visualize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(349, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.Update);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // A_VIsualize
            // 
            this.A_VIsualize.AutoSize = true;
            this.A_VIsualize.Location = new System.Drawing.Point(133, 277);
            this.A_VIsualize.Name = "A_VIsualize";
            this.A_VIsualize.Size = new System.Drawing.Size(20, 20);
            this.A_VIsualize.TabIndex = 3;
            this.A_VIsualize.Text = "A";
            // 
            // D_Visualize
            // 
            this.D_Visualize.AutoSize = true;
            this.D_Visualize.Location = new System.Drawing.Point(230, 277);
            this.D_Visualize.Name = "D_Visualize";
            this.D_Visualize.Size = new System.Drawing.Size(21, 20);
            this.D_Visualize.TabIndex = 4;
            this.D_Visualize.Text = "D";
            // 
            // J_Visualize
            // 
            this.J_Visualize.AutoSize = true;
            this.J_Visualize.Location = new System.Drawing.Point(466, 277);
            this.J_Visualize.Name = "J_Visualize";
            this.J_Visualize.Size = new System.Drawing.Size(17, 20);
            this.J_Visualize.TabIndex = 5;
            this.J_Visualize.Text = "J";
            // 
            // L_Visualize
            // 
            this.L_Visualize.AutoSize = true;
            this.L_Visualize.Location = new System.Drawing.Point(556, 277);
            this.L_Visualize.Name = "L_Visualize";
            this.L_Visualize.Size = new System.Drawing.Size(18, 20);
            this.L_Visualize.TabIndex = 6;
            this.L_Visualize.Text = "L";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_Visualize);
            this.Controls.Add(this.J_Visualize);
            this.Controls.Add(this.D_Visualize);
            this.Controls.Add(this.A_VIsualize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Start);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleInput);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label A_VIsualize;
        private System.Windows.Forms.Label D_Visualize;
        private System.Windows.Forms.Label J_Visualize;
        private System.Windows.Forms.Label L_Visualize;
        public System.Windows.Forms.Timer timer1;
    }
}

