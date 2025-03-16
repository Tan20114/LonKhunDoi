using System;
using System.Drawing;
using System.Windows.Forms;

namespace StartGame
{
    class AnimationFlipped : Animation
    {
        public AnimationFlipped(PictureBox pictureBox, int interval)
            : base(pictureBox, interval)
        {
        }

        protected override void UpdatePictureBox()
        {
            // Ensure Assets.SpriteSheetPath is a valid Bitmap
            if (!(Assets.SpriteSheetPath is Bitmap spriteSheet))
            {
                throw new InvalidOperationException("Sprite sheet is not a valid Bitmap.");
            }

            // Calculate the frame rectangle based on sprite sheet dimensions
            int framesPerRow = spriteSheet.Width / Assets.FrameWidth;
            int framesPerColumn = spriteSheet.Height / Assets.FrameHeight;

            if (currentFrame < 0 || currentFrame >= framesPerRow * framesPerColumn)
            {
                throw new ArgumentOutOfRangeException(nameof(currentFrame), "Frame index is out of bounds.");
            }

            // Determine the rectangle for the current frame
            Rectangle frameRect = new Rectangle(
                (currentFrame % framesPerRow) * Assets.FrameWidth,
                (currentFrame / framesPerRow) * Assets.FrameHeight,
                Assets.FrameWidth,
                Assets.FrameHeight
            );

            // Create a new Bitmap with the size of the frame
            Bitmap frameImage = new Bitmap(Assets.FrameWidth, Assets.FrameHeight);

            // Ensure we are within bounds and draw the current frame from the sprite sheet
            using (Graphics g = Graphics.FromImage(frameImage))
            {
                g.DrawImage(spriteSheet, new Rectangle(0, 0, Assets.FrameWidth, Assets.FrameHeight), frameRect, GraphicsUnit.Pixel);
            }

            // Flip the frame horizontally
            Bitmap flippedFrameImage = new Bitmap(frameImage);
            flippedFrameImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            // Dispose of the original frame image to free memory
            frameImage.Dispose();

            // If the PictureBox already has an image, dispose it to prevent memory leaks
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
            }

            // Set the flipped frame as the new image for the PictureBox
            pictureBox.Image = flippedFrameImage;
        }
    }
}
