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
        Form _form;

        protected PictureBox spriteRenderer;
        protected Point spawnPoint = new Point(0,0);
        int endPoint = 100;

        int speed = 0;
        int acceleration = 2;

        int itemCount = 0;
        public int ItemCount 
        {
            get => itemCount;
            set => itemCount = value;
        }

        public Item(Form form)
        {
            _form = form;
        }

        public void Update()
        {
            LocationUpdate();
        }

        public void SpawnItem()
        {
            speed = 0;
            PictureBox item = new PictureBox();
            item.Size = new System.Drawing.Size(100,100);
            item.Location = spawnPoint;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.BackColor = Color.White;

            spriteRenderer = item;
            spriteRenderer.BringToFront();
            _form.Controls.Add(spriteRenderer);
            itemCount++;
        }

        void Accelerate()
        {
            speed += acceleration;
        }

        void LocationUpdate()
        {
            if (spriteRenderer != null && spriteRenderer.Location.Y < endPoint)
            {
                Accelerate();
                spriteRenderer.Location = new Point(spriteRenderer.Location.X, spriteRenderer.Location.Y+speed);
            }
        }
    }
}
