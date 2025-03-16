using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartGame
{
    internal class SpriteEditor
    {
        public Image sprite;
        public int tFrame { get; private set;}

        public int FrameWidth
        {
            get => sprite.Width / tFrame;
        }
        public int FrameHeight
        {
            get => sprite.Height;
        }
        public SpriteEditor(Image sheet, int totalFrame)
        {
            sprite = sheet;
            tFrame = totalFrame;
        }
    }
}
