using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace StartGame
{
    public static class Assets
    {
        public static Image DefaultImage { get; private set; }
        public static Image HoverImage { get; private set; }
        public static Image ClockImage { get; private set; }
        public static Image BackGround { get; private set; }
        public static Image Bottom { get; private set; }
        public static Image BottomHover { get; private set; }
        public static string[] ImagePaths { get; private set; }
        public static Image SpriteSheetPath { get; private set; }
        public static Image SpriteSheetPath2 { get; private set; }
        public static int FrameWidth { get; private set; }
        public static int FrameHeight { get; private set; }
        public static int TotalFrames { get; private set; }

        static Assets()
        {
            DefaultImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Bottom_template.png"));
            HoverImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Bottom_template_press.png"));
            ClockImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Clock.png"));
            
            Assets.ImagePaths = new string[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" , "backgroundfrontcmu.png") ,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets" ,"backgroundlandmarkone.png") ,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" , "backgroundspirit.png") ,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" , "backgroundtemple.png")
            };

            SpriteSheetPath = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Sprite_Idel.png"));
            FrameWidth = 640;
            FrameHeight = 530;
            TotalFrames = 2;
        }
    }
}
