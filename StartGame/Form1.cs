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
using PurpleWin;
using YellowWin;

namespace StartGame
{
    public partial class Form1 : Form
    {
        Form previousForm;

        public static float score;

        Item item;

        Player1 p1;
        Player2 p2;

        UI ui;

        bool isGameStart = false;
        bool isSpawnable = false;

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

        Animation seniorAni1;
        Animation seniorAni2;

        public Form1(Form main)
        {
            InitializeComponent();

            previousForm = main;

            InitializeBGM();

            item = new Item(this);
            p1 = new Player1(item, this);
            p2 = new Player2(item, this);
            p1.SetOpponent(p2);
            p2.SetOpponent(p1);

            ui = new UI(this,p1,p2);

            Car1.Visible = false;
            Car2.Visible = false;

            Car1.BackgroundImage = Assets.car;
            Car2.BackgroundImage = Assets.car;

            Senior1.Visible = false;
            Senior2.Visible = false;

            seniorAni1 = new Animation(Assets.bHug1,Senior1,100);
            seniorAni2 = new Animation(Assets.bHug2,Senior2,100);

            pictureBox3.BackgroundImage = Assets.DefaultImage;
            pictureBox3.Location = new Point((this.ClientSize.Width - pictureBox3.Width) / 2, -50);
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BringToFront();
            label2.Parent = pictureBox3;
            label2.BackColor = Color.Transparent;
            label2.BringToFront();
            label2.Location = new Point((pictureBox3.Width - label2.Width) / 2, (pictureBox3.Height - label2.Height) / 2);

            pictureBox3.MouseEnter += PictureBox3_MouseEnter;
            pictureBox3.MouseLeave += PictureBox3_MouseLeave;
            label2.MouseEnter += Label2_MouseEnter;
            label2.MouseLeave += Label2_MouseLeave;

            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.label2.Click += new System.EventHandler(this.label2_Click);

            gameTimer = new Timer();
            gameTimer.Interval = 1000;//
            gameTimer.Tick += GameTimer_Tick;

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTimer_Tick;

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.RightToLeftLayout = true;
            progressBar1.Location = new Point(365, 800);

            progressBar2.Maximum = 100;
            progressBar2.Value = progressValue2;
            progressBar2.Style = ProgressBarStyle.Continuous;
            progressBar2.Location = new Point(735, 800);

            progressTimer = new Timer();
            progressTimer.Interval = 900;
            progressTimer.Tick += ProgressTimer_Tick;

            this.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);

            imageTimer = new Timer();
            imageTimer.Interval = 22500;
            imageTimer.Tick += ImageTimer_Tick;

            pictureBox3.Visible = true;
            label2.Location = new Point((pictureBox3.Width - label2.Width) / 2, (pictureBox3.Height - label2.Height) / 2);
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
            this.Icon = Assets.gameIcon;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(HandleInput);

            label2.BackColor = Color.Transparent;
            label2.Visible = true;
            label2.BringToFront();
            label2.Location = new Point((pictureBox3.Width - label2.Width) / 2, (pictureBox3.Height - label2.Height) / 2);
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
            pictureBox3.Location = new Point((this.ClientSize.Width - pictureBox3.Width) / 2, -50);
            label2.Location = new Point((pictureBox3.Width - label2.Width) / 2, (pictureBox3.Height - label2.Height) / 2);
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
            pictureBox3.Location = new Point((this.ClientSize.Width - pictureBox3.Width) / 2, 30);
            label2.Location = new Point(pictureBox3.Width / 2 - label2.Width / 2, pictureBox3.Height / 2 - label2.Height / 2);

            Delay(2000);
            Assets.YoungMaiTongRiem.Stop();
            Assets.YoungMaiTongRiem.Play();
        }
        private void StartGame()
        {
            progressValue1 = 0;
            progressValue2 = 0;
            progressBar1.Value = progressValue1;
            progressBar2.Value = progressValue2;

            currentImageIndex = 0;
            this.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);

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
            this.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);
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
            score = 0;
            progressValue1 = 0;
            progressValue2 = 0;
            progressBar1.Value = progressValue1;
            progressBar2.Value = progressValue2;
            currentImageIndex = 0;
            this.BackgroundImage = Image.FromFile(Assets.ImagePaths[currentImageIndex]);
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
                isSpawnable = true;
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isSpawnable)
            {
                SpawnItemInterval(15000);
                isSpawnable = false;
            }
            isGameStart = true;
            

            gameCountdown--;
            label2.Text = gameCountdown.ToString();

            if (gameCountdown <= 0)
            {
                isGameStart = false;
                gameTimer.Stop();
                if (score > 0)
                {
                    Assets.bgm.Stop();
                    RestartScene();
                    PurpleWin.Form1 purpleWinForm = new PurpleWin.Form1(previousForm);
                    purpleWinForm.Show();
                    this.Hide();
                }
                else if (score < 0)
                {
                    Assets.bgm.Stop();
                    RestartScene();
                    YellowWin.Form1 yellowWinForm = new YellowWin.Form1(previousForm);
                    yellowWinForm.Show();
                    this.Hide();
                }
                else
                {
                    RestartScene();
                }
                    
            }
        }

        async void Delay(int delay)
        {
            await Task.Delay(delay);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Delay(2000);
            Assets.YoungMaiTongRiem.Stop();
            Assets.YoungMaiTongRiem.Play();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            if(isGameStart)
            {
                p1.MakeScore(e);
                p1.CollectItem(e);
                p1.UseItem(e);
                p2.MakeScore(e);
                p2.CollectItem(e);
                p2.UseItem(e);
            }
        }

        async void SpawnItemInterval(int interval)
        {
            await Task.Delay(interval);
            if (item.ItemCount < 1)
            {
                item.SpawnItem();
            }
            SpawnItemInterval(interval);
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            p1.resetKeyPress();
            p2.resetKeyPress();
        }

        public static void InitializeBGM()
        {
            Assets.bgm.MediaEnded += (sender, e) => Assets.bgm.Position = TimeSpan.Zero; // Loop audio
            Assets.bgm.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            item.Update();
            ui.Update();
        }

        private void RVisual2_Click(object sender, EventArgs e)
        {

        }

        private void LVisual2_Click(object sender, EventArgs e)
        {

        }
    }
}