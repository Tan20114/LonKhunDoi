using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            pictureBox.BackgroundImage = Image.FromFile("C:\\Users\\Lenovo\\Documents\\GitHub\\LonKhunDoi\\LonKhunDoi\\bin\\Debug\\main_menu.png");

            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Lenovo\\Documents\\GitHub\\LonKhunDoi\\LonKhunDoi\\bin\\Debug\\new_startimagelogo.png");

            pictureBox1.Parent = pictureBox;
            pictureBox1.BackColor = Color.Transparent;

            Image defaultImage = Image.FromFile("C:\\Users\\Lenovo\\Documents\\GitHub\\LonKhunDoi\\LonKhunDoi\\bin\\Debug\\new_startimagelogo.png");
            Image hoverImage = Image.FromFile("C:\\Users\\Lenovo\\Documents\\GitHub\\LonKhunDoi\\LonKhunDoi\\bin\\Debug\\new_startimagelogowhenhover.png");

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
