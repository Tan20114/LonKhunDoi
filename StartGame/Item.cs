using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
{
    internal class Item
    {
        public enum DebuffType
        {
            None,
            Shit,
            Car,
            Friend
        }

        Form1 _form;

        public PictureBox spriteRenderer;
        protected PictureBox itemObject = new PictureBox();

        public Image sprite;
        public Color color;

        protected Point spawnPoint = new Point(800,0);
        int endPoint = 300;

        public DebuffType type = DebuffType.None;

        int speed = 0;
        int acceleration = 2;

        int itemCount = 0;
        public int ItemCount 
        {
            get => itemCount;
            set => itemCount = value;
        }
        public bool isFirstSpawn = true;

        private Animation ani;

        public Item()
        {

        }

        public Item(Form1 form)
        {
            _form = form;
            itemObject.Visible = false;
        }

        public void Update()
        {
            LocationUpdate();
        }

        public void SpawnItem()
        {
            Random randomValue = new Random();
            int randomVal = randomValue.Next(1,101);
            if(randomVal < 80)
            {
                Assets.ItemDrop.Stop();
                Assets.ItemDrop.Play();
            }
            else
            {
                Assets.Serect_Item_Drop.Stop();
                Assets.Serect_Item_Drop.Play();
            }

            speed = 0;
            SetObject();
            itemObject.Visible = true;

            spriteRenderer = itemObject;

            itemObject.BringToFront();
            itemObject.BringToFront();
            itemObject.BringToFront();
            itemObject.BringToFront();

            _form.Controls.Add(itemObject);

            itemCount++;
        }

        public void DestroyItem()
        {
            itemObject.Visible = false;
        }

        void Accelerate()
        {
            speed += acceleration;
        }

        void LocationUpdate()
        {
            if (itemObject != null && itemObject.Location.Y < endPoint)
            {
                Accelerate();
                itemObject.Location = new Point(itemObject.Location.X, itemObject.Location.Y+speed);
            }
        }

        void SetObject()
        {
            itemObject.Size = new System.Drawing.Size(303, 311);
            itemObject.Location = spawnPoint;
            if(isFirstSpawn)
            {
                isFirstSpawn = false;
                ani = new Animation(Assets.qMark, itemObject, 100);
            }
            itemObject.SizeMode = PictureBoxSizeMode.Zoom;
            itemObject.BackColor = Color.Transparent;
        }

        public Item RandomItem()
        {
            Random random = new Random();
            int randomTypeValue = random.Next(1, 4);
            switch (randomTypeValue)
            {
                case 1:
                    {
                        return new Debuff1();
                    }
                case 2:
                    {
                        return new Debuff2();
                    }
                case 3:
                    {
                        return new Debuff3();
                    }
            }
            return null;
        }
    }
}
