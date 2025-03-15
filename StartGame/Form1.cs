using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StartGame
{
    public partial class Form1 : Form
    {
        private Timer imageTimer;
        private int currentImageIndex = 0;
        private Timer progressTimer;
        private int progressValue1 = 0;
        private int progressValue2 = 0;
        private Timer countdownTimer;
        private int countdownValue;
        private int gameCountdown = 90;
        private Timer gameTimer;
        private bool isClockActive = false;
        private Animation animation1;
        private Animation animation2;

        public Form1()
        {
            InitializeComponent();

            animation1 = new Animation(Assets.SpriteSheetPath,2,pictureBox4, 450, false);
            pictureBox4.Parent = pictureBox1;
            pictureBox4.BackColor = Color.Transparent;
            animation2 = new Animation(Assets.SpriteSheetPath, 2, pictureBox5, 450, true);
            pictureBox5.Parent = pictureBox1;
            pictureBox5.BackColor = Color.Transparent;

            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackgroundImage = Assets.DefaultImage;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BringToFront();
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label2.BringToFront();
            label2.Location = new Point(pictureBox3.Location.X - 325, pictureBox3.Location.Y - 10);

            pictureBox3.MouseEnter += PictureBox3_MouseEnter;
            pictureBox3.MouseLeave += PictureBox3_MouseLeave;
            label2.MouseEnter += Label2_MouseEnter;
            label2.MouseLeave += Label2_MouseLeave;

            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.label2.Click += new System.EventHandler(this.label2_Click);

            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.RightToLeftLayout = true;

            progressBar2.Maximum = 100;
            progressBar2.Value = progressValue2;
            progressBar2.Style = ProgressBarStyle.Continuous;

            progressTimer = new Timer();
            progressTimer.Interval = 900;
            progressTimer.Tick += ProgressTimer_Tick;

            pictureBox1.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);

            imageTimer = new Timer();
            imageTimer.Interval = 22500;
            imageTimer.Tick += ImageTimer_Tick;

            pictureBox3.Visible = true;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label1.BringToFront();
            label2.Location = new Point(pictureBox3.Location.X + 10, pictureBox3.Location.Y + 10);
        }
        private void PictureBox3_MouseEnter(object sender, EventArgs e)
        {
            if (!isClockActive)
                pictureBox3.BackgroundImage = Assets.HoverImage;
        }

        private void PictureBox3_MouseLeave(object sender, EventArgs e)
        {
            if (!isClockActive)
                pictureBox3.BackgroundImage = Assets.DefaultImage;
        }

        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            if (!isClockActive)
                pictureBox3.BackgroundImage = Assets.HoverImage;
        }

        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            if (!isClockActive)
                pictureBox3.BackgroundImage = Assets.DefaultImage;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Parent = pictureBox3;
            label2.BackColor = Color.Transparent;
            label2.Visible = true;
            label2.BringToFront();
            label2.Location = new Point(pictureBox3.Location.X -325, pictureBox3.Location.Y-10);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            isClockActive = true;
            pictureBox3.BackgroundImage = Assets.ClockImage;

            pictureBox3.MouseEnter -= PictureBox3_MouseEnter;
            pictureBox3.MouseLeave -= PictureBox3_MouseLeave;
            label2.MouseEnter -= Label2_MouseEnter;
            label2.MouseLeave -= Label2_MouseLeave;

            countdownValue = 4;
            label2.Text = countdownValue.ToString();
            countdownTimer.Start();
            pictureBox3.Location = new Point(465, 25);
            label2.Location = new Point(pictureBox3.Width / 2 - label2.Width / 2, pictureBox3.Height / 2 - label2.Height / 2);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            isClockActive = true;
            pictureBox3.BackgroundImage = Assets.ClockImage;

            pictureBox3.MouseEnter -= PictureBox3_MouseEnter;
            pictureBox3.MouseLeave -= PictureBox3_MouseLeave;
            label2.MouseEnter -= Label2_MouseEnter;
            label2.MouseLeave -= Label2_MouseLeave;

            countdownValue = 4;
            label2.Text = countdownValue.ToString();
            countdownTimer.Start();
            pictureBox3.Location = new Point(465, 25);
            label2.Location = new Point(pictureBox3.Width / 2 - label2.Width / 2, pictureBox3.Height / 2 - label2.Height / 2);
        }
        private void StartGame()
        {
            progressValue1 = 0;
            progressValue2 = 0;
            progressBar1.Value = progressValue1;
            progressBar2.Value = progressValue2;

            currentImageIndex = 0;
            pictureBox1.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);

            gameCountdown = 90;
            label2.Text = gameCountdown.ToString();
            imageTimer.Start();
            progressTimer.Start();
            gameTimer.Start();
        }
        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            currentImageIndex++;

            if (currentImageIndex >= Assets.ImagePaths.Length)
            {
                imageTimer.Stop();
                return;
            }
            pictureBox1.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
        private void progressBar2_Click(object sender, EventArgs e)
        {
        }
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (progressValue1 < 100)
            {
                progressValue1++;
                progressBar1.Value = progressValue1;
            }
            if (progressValue2 < 100)
            {
                progressValue2++;
                progressBar2.Value = progressValue2;
            }

            if (progressValue1 >= 100 && progressValue2 >= 100)
            {
                progressTimer.Stop();
                RestartScene();
            }
        }
        private void RestartScene()
        {
            progressValue1 = 0;
            progressValue2 = 0;
            progressBar1.Value = progressValue1;
            progressBar2.Value = progressValue2;
            currentImageIndex = 0;
            pictureBox1.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);
            imageTimer.Stop();
            progressTimer.Stop();
            gameTimer.Stop();

            isClockActive = false;
            pictureBox3.BackgroundImage = Assets.DefaultImage;
            label2.Text = "Start";
            pictureBox3.Visible = true;
            label2.Visible = true;

            pictureBox3.MouseEnter += PictureBox3_MouseEnter;
            pictureBox3.MouseLeave += PictureBox3_MouseLeave;
            label2.MouseEnter += Label2_MouseEnter;
            label2.MouseLeave += Label2_MouseLeave;
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdownValue <= 6)
            {
                label2.Text = countdownValue.ToString();
                countdownValue++;
            }
            else
            {
                countdownTimer.Stop();
                StartGame();
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gameCountdown--;
            label2.Text = gameCountdown.ToString();

            if (gameCountdown <= 0)
            {
                gameTimer.Stop();
                RestartScene();
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }
    }
}