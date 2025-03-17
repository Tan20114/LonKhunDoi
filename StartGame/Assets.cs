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

        #region Key
        #region Key Normal
        public static string[] key;
        #endregion
        #region Key Press
        public static string[] keyPress;
        #endregion
        #endregion

        #region ItemSection
        public static string[] qMark;
        public static Image shitIcon;
        public static Image carIcon;
        public static Image car;
        public static Image friendIcon;
        #endregion

        #region Sprite Sheet
        public static string[] SpriteSheetPath { get; private set; }
        public static string[] SpriteSheetPath2 { get; private set; }
        public static string[] pooSheet;
        public static string[] pooSheet2;
        public static string[] crashSheet;
        public static string[] crashSheet2;
        public static string[] bHug1;
        public static string[] bHug2;
        public static string[] hug1;
        public static string[] hug2;
        #endregion
        #region Item sound
        // ItemDrop sounds
        public static MediaPlayer ItemDrop { get; private set; } = new MediaPlayer();
        public static MediaPlayer Serect_Item_Drop { get; private set; } = new MediaPlayer();
        #endregion
        #region Left Sound
        // ชิดซ้าย sounds
        public static MediaPlayer Shit_Sray { get; private set; } = new MediaPlayer();
        public static MediaPlayer RodMalaJa { get; private set; } = new MediaPlayer();
        public static MediaPlayer BangAndCrom { get; private set; } = new MediaPlayer();
        #endregion
        #region Shit Sound
        // ปวดขี้ sounds
        public static MediaPlayer PodKee { get; private set; } = new MediaPlayer();
        public static MediaPlayer WhereIsHongNam { get; private set; } = new MediaPlayer();
        public static MediaPlayer KaeMapenKon { get; private set; } = new MediaPlayer();
        #endregion
        #region Friend Sound
        // เพื่อนมันมาจากไหน sounds
        public static MediaPlayer WhoDafuqAreYou { get; private set; } = new MediaPlayer();
        public static MediaPlayer PaiDuyGunPaiDaiGai { get; private set; } = new MediaPlayer();
        #endregion
        #region Misc. Sound
        public static MediaPlayer YoungMaiTongRiem { get; private set; } = new MediaPlayer();
        public static MediaPlayer bgm = new MediaPlayer();
        #endregion
        static Assets()
        {
            DefaultImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","UI", "Bottom_template.png"));
            HoverImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","UI", "Bottom_template_press.png"));
            ClockImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","UI", "Clock.png"));

            key = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Keyboard_Steady"));
            keyPress = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Keyboard_Press"));

            #region BG
            Assets.ImagePaths = new string[]
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" ,"BG", "backgroundfrontcmu.png") ,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" ,"BG","backgroundlandmarkone.png") ,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" ,"BG", "backgroundspirit.png") ,
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"assets" ,"BG", "backgroundtemple.png")
            };
            #endregion

            #region Item
            qMark = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Item", "qMark"));
            shitIcon = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Item", "item_poop.png"));
            carIcon = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Item", "item_left.png"));
            car = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Item", "car.png"));
            friendIcon = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Item", "item_run.png"));
            #endregion

            #region SpriteSheet
            SpriteSheetPath = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "IdleSprite"));
            SpriteSheetPath2 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "IdleSprite2"));
            pooSheet = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Poo"));
            pooSheet2 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Poo2"));
            crashSheet = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "crash"));
            crashSheet2 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "crash2"));
            bHug1 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "bHug1"));
            bHug2 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "bHug2"));
            hug1 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "hug1"));
            hug2 = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "hug2"));

            #endregion
            #region Audio
            bgm.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Audio", "BGM.mp3")));

            YoungMaiTongRiem.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "456_Edit.mp3")));//เสียงตอนนับเวลา

            ItemDrop.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "ItemDrop_Edit.mp3")));//เสียงไอเท็มหล่น
            Serect_Item_Drop.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "Audio", "Serect_Item_Drop_Edit.mp3")));//เสียงลับไอเท็มหล่น โอกาส 1/100

            Shit_Sray.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "Shit_Sray_Edit.mp3")));//เสียงกดใช้ไอเท็มชิดซ้าย
            RodMalaJa.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "RodMalaJa_Edit.mp3")));//เสียงตอนรถโผล่มา
            BangAndCrom.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "BangAndCrom_Edit.mp3")));//เสียงตอนโดนชน

            PodKee.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "PodKee.mp3")));//เสียงกดใช้ไอเท็มปวดขี้
            WhereIsHongNam.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "WhereIsHongNam.mp3")));//เสียงตอนห้องน้ำโผล่มา
            KaeMapenKon.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "KaeMapenKon_Edit.mp3")));//เสียงตอนเข้าห้องน้ำ

            WhoDafuqAreYou.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "WhoDafuqAreYou_Edit.mp3")));//เสียงกดใช้ไอเท็มเพื่อนขอวิ่งไปด้วย
            PaiDuyGunPaiDaiGai.Open(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets","Audio", "PaiDuyGunPaiDaiGai_Edit.mp3")));//เสียงตอนเพื่อนกอดคอเราแล้ว
            #endregion
        }
    }
}
