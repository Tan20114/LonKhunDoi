using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
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

        Form _form;

        public PictureBox spriteRenderer;
        protected PictureBox itemObject = new PictureBox();

        public Image sprite;
        public Color color;

        protected Point spawnPoint = new Point(200,0);
        int endPoint = 100;

        public DebuffType type = DebuffType.None;

        int speed = 0;
        int acceleration = 2;

        int itemCount = 0;
        public int ItemCount 
        {
            get => itemCount;
            set => itemCount = value;
        }
        public bool isCollectable = false;

        public Item()
        {

        }

        public Item(Form form)
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
            speed = 0;
            SetObject();
            itemObject.Visible = true;

            spriteRenderer = itemObject;

            itemObject.BringToFront();

            _form.Controls.Add(itemObject);

            itemCount++;
        }

        public void DestroyItem()
        {
            itemObject.Visible = false;
            isCollectable = false;
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
            itemObject.Size = new System.Drawing.Size(100, 100);
            itemObject.Location = spawnPoint;
            itemObject.SizeMode = PictureBoxSizeMode.Zoom;
            itemObject.BackColor = Color.White;
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

        public virtual void DebuffEffect()
        {

        }
    }
}
