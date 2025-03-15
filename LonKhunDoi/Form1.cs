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
using StartGame;

namespace LonKhunDoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string backGround = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "main_menu.png");
            string bottom = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "new_startimagelogo.png");
            string bottomHover = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "new_startimagelogowhenhover.png");

            pictureBox.BackgroundImage = Image.FromFile(backGround);

            pictureBox1.Parent = pictureBox;
            pictureBox1.BackColor = Color.Transparent;

            Image defaultImage = Image.FromFile(bottom);
            Image hoverImage = Image.FromFile(bottomHover);

            pictureBox1.BackgroundImage = defaultImage;
            pictureBox1.MouseEnter += (s, e) => {
                pictureBox1.BackgroundImage = hoverImage;
            };

            pictureBox1.MouseLeave += (s, e) => {
                pictureBox1.BackgroundImage = defaultImage;
            };

            pictureBox1.Click += (s, e) => {
                StartGame.Form1 startGameForm = new StartGame.Form1();
                startGameForm.Show();
                this.Hide();
            };
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            
        }
    }
}
