using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
{
    public class Animation
    {
        protected int currentFrame = 0;
        int frameRate = 0;

        private Timer animationTimer;
        protected PictureBox pictureBox;

        private string[] sprite;
        private bool isRunning = false;

        public Animation(string[] sprite, PictureBox pictureBox, int interval)
        {
            this.pictureBox = pictureBox;
            this.sprite = sprite;

            animationTimer = new Timer();
            animationTimer.Interval = interval;
            animationTimer.Tick += AnimationTimer_Tick;

            StartAnimation();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                UpdatePictureBox();
            }
        }

        protected void UpdatePictureBox()
        {
            frameRate++;
            if (frameRate == 2)
            {
                currentFrame++;
                frameRate = 0;
            }

            if (currentFrame >= sprite.Length)
            {
                currentFrame = 0;
            }

            pictureBox.BackgroundImage = Image.FromFile(sprite[currentFrame]);
            pictureBox.Refresh();
        }

        public void StopAnimation()
        {
            isRunning = false;
            animationTimer.Stop();
        }

        public void StartAnimation()
        {
            if (!isRunning)
            {
                isRunning = true;
                animationTimer.Start();
            }
        }
    }

}