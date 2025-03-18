using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurpleWin
{
    public partial class Form1: Form
    {
        Form m;

        public Form1(Form main)
        {
            m = main;
            InitializeComponent();
            string backGround = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "purplewin.png");
            pictureBox1.BackgroundImage = Image.FromFile(backGround);

            string bottom = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Bottom_template.png");
            string bottomHover = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Bottom_template_press.png");
            Image defaultImage = Image.FromFile(bottom);
            Image hoverImage = Image.FromFile(bottomHover);

            PlayerWin.Parent = pictureBox1;
            PlayerWin.Location = new Point(550, 50);

            PlayAgain.Parent = pictureBox1;
            PlayAgain.BackColor = Color.Transparent;
            PlayAgain.Location = new Point(700, 350);

            LetterPlay.Parent = PlayAgain;
            LetterPlay.BackColor = Color.Transparent;
            LetterPlay.BringToFront();
            LetterPlay.Location = new Point((PlayAgain.Width - LetterPlay.Width) / 2, (PlayAgain.Height - LetterPlay.Height) / 2);

            PlayAgain.BackgroundImage = defaultImage;
            PlayAgain.MouseEnter += (s, e) => {
                PlayAgain.BackgroundImage = hoverImage;
            };

            PlayAgain.MouseLeave += (s, e) => {
                PlayAgain.BackgroundImage = defaultImage;
            };
            LetterPlay.MouseEnter += (s, e) => {
                PlayAgain.BackgroundImage = hoverImage;
            };
            LetterPlay.MouseLeave += (s, e) => {
                PlayAgain.BackgroundImage = defaultImage;
            };

            Exit.Parent = pictureBox1;
            Exit.BackColor = Color.Transparent;
            Exit.Location = new Point(700, 750);

            LetterExit.Parent = Exit;
            LetterExit.BackColor = Color.Transparent;
            LetterExit.BringToFront();
            LetterExit.Location = new Point((Exit.Width - LetterExit.Width) / 2, (Exit.Height - LetterExit.Height) / 2);

            Exit.BackgroundImage = defaultImage;
            Exit.MouseEnter += (s, e) => {
                Exit.BackgroundImage = hoverImage;
            };

            Exit.MouseLeave += (s, e) => {
                Exit.BackgroundImage = defaultImage;
            };

            Exit.Click += (s, e) => {
                this.Close();
            };

            LetterExit.MouseEnter += (s, e) => {
                Exit.BackgroundImage = hoverImage;
            };
            LetterExit.MouseLeave += (s, e) => {
                Exit.BackgroundImage = defaultImage;
            };
            LetterExit.Click += (s, e) => {
                this.Close();
            };
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PlayerWin_Click(object sender, EventArgs e)
        {
        }

        private void LetterPlay_Click(object sender, EventArgs e)
        {
            m.Show();
            this.Hide();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            m.Show();
            this.Hide();
        }
    }
}
