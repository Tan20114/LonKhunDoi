using System.Drawing;
using System.Windows.Forms;

namespace StartGame
{
    class FlipAnimation : Animation
    {
        public FlipAnimation(PictureBox pictureBox, int interval) : base(pictureBox, interval) { }

        protected override void UpdatePictureBox()
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

            // Apply horizontal flip to the frame
            frameImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            pictureBox.Image = frameImage;
        }
    }
}
