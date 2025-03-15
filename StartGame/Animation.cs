using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
{
    class Animation
    {
        private Timer animationTimer;
        protected int currentFrame = 0;
        protected PictureBox pictureBox;

        public Animation(PictureBox pictureBox, int interval)
        {
            this.pictureBox = pictureBox;

            animationTimer = new Timer();
            animationTimer.Interval = interval;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= Assets.TotalFrames)
            {
                currentFrame = 0;
            }
            UpdatePictureBox();
        }

        protected virtual void UpdatePictureBox()
        {
            Rectangle frameRect = new Rectangle(
                (currentFrame % (Assets.SpriteSheetPath.Width / Assets.FrameWidth)) * Assets.FrameWidth,
                (currentFrame / (Assets.SpriteSheetPath.Width / Assets.FrameWidth)) * Assets.FrameHeight,
                Assets.FrameWidth,
                Assets.FrameHeight
            );

            Bitmap frameImage = new Bitmap(Assets.FrameWidth, Assets.FrameHeight);

            using (Graphics g = Graphics.FromImage(frameImage))
            {
                g.DrawImage(Assets.SpriteSheetPath, 0, 0, frameRect, GraphicsUnit.Pixel);
            }

            pictureBox.Image = frameImage;
        }
    }
}
