using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Media;
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
        // ItemDrop sounds
        public static MediaPlayer ItemDrop { get; private set; } = new MediaPlayer();
        public static MediaPlayer Serect_Item_Drop { get; private set; } = new MediaPlayer();
        // ชิดซ้าย sounds
        public static MediaPlayer Shit_Sray { get; private set; } = new MediaPlayer();
        public static MediaPlayer RodMalaJa { get; private set; } = new MediaPlayer();
        public static MediaPlayer BangAndCrom { get; private set; } = new MediaPlayer();
        // ปวดขี้ sounds
        public static MediaPlayer PodKee { get; private set; } = new MediaPlayer();
        public static MediaPlayer WhereIsHongNam { get; private set; } = new MediaPlayer();
        public static MediaPlayer KaeMapenKon { get; private set; } = new MediaPlayer();
        // เพื่อนมันมาจากไหน sounds
        public static MediaPlayer WhoDafuqAreYou { get; private set; } = new MediaPlayer();
        public static MediaPlayer PaiDuyGunPaiDaiGai { get; private set; } = new MediaPlayer();
        public static MediaPlayer YoungMaiTongRiem { get; private set; } = new MediaPlayer();
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

            YoungMaiTongRiem.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "456_Edit.mp3")));//เสียงตอนนับเวลา

            ItemDrop.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "ItemDrop_Edit.mp3")));//เสียงไอเท็มหล่น
            Serect_Item_Drop.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Secret_Item_Drop_Edit.mp3")));//เสียงลับไอเท็มหล่น โอกาส 1/100

            Shit_Sray.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Shit_Sray_Edit.mp3")));//เสียงกดใช้ไอเท็มชิดซ้าย
            RodMalaJa.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "RodMalaJa_Edit.mp3")));//เสียงตอนรถโผล่มา
            BangAndCrom.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "BangAndCrom_Edit.mp3")));//เสียงตอนโดนชน

            PodKee.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "PodKee.mp3")));//เสียงกดใช้ไอเท็มปวดขี้
            WhereIsHongNam.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "WhereIsHongNam.mp3")));//เสียงตอนห้องน้ำโผล่มา
            KaeMapenKon.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "KaeMapenKon_Edit.mp3")));//เสียงตอนเข้าห้องน้ำ

            WhoDafuqAreYou.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "WhoDafuqAreYou_Edit.mp3")));//เสียงกดใช้ไอเท็มเพื่อนขอวิ่งไปด้วย
            PaiDuyGunPaiDaiGai.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "PaiDuyGunPaiDaiGai_Edit.mp3")));//เสียงตอนเพื่อนกอดคอเราแล้ว
        }
    }
}
