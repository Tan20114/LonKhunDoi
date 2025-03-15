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
        private bool isFlip;
        protected int currentFrame = 0;
        protected PictureBox pictureBox;

        public Animation(PictureBox pictureBox, int interval, bool isFlip)
        {
            this.pictureBox = pictureBox;
            this.isFlip = isFlip;

            animationTimer = new Timer();
            animationTimer.Interval = interval;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

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
            SpriteEditor spriteSheet = new SpriteEditor(Assets.SpriteSheetPath,2);

            Rectangle frameRect = new Rectangle(
                (currentFrame % (spriteSheet.sprite.Width / spriteSheet.FrameWidth)) * spriteSheet.FrameWidth,
                (currentFrame / (spriteSheet.sprite.Width / spriteSheet.FrameWidth)) * spriteSheet.FrameHeight,
                spriteSheet.FrameWidth,
                spriteSheet.FrameHeight
            );

            Bitmap frameImage = new Bitmap(spriteSheet.FrameWidth, spriteSheet.FrameHeight);

            using (Graphics g = Graphics.FromImage(frameImage))
            {
                g.DrawImage(spriteSheet.sprite, 0, 0, frameRect, GraphicsUnit.Pixel);
            }

            pictureBox.Image = frameImage;

            if(isFlip)
            {
                pictureBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox.Refresh();
            }
        }
    }
}