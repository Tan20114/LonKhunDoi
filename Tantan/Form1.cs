using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
{
    public partial class Form1 : Form
    {
        Item item;
        UI ui;
        Player1 p1;
        Player2 p2; 

        public static float score = 0;

        public Form1()
        {
            InitializeComponent();
            item = new Item(this);
            p1 = new Player1(item,this);
            p2 = new Player2(item,this);
            p1.SetOpponent(p2);
            p2.SetOpponent(p1);
            ui = new UI(this, p1, p2);
        }
        private void Start(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(HandleInput);
            SpawnItemInterval(5000);
        }

        private void Update(object sender, EventArgs e)
        {
            label1.Text = score.ToString();

            item.Update();
            ui.Update();

            p1.Update();
            p2.Update();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            p1.MakeScore(e);
            p1.CollectItem(e);
            p1.UseItem(e);
            p2.MakeScore(e);
            p2.CollectItem(e);
            p2.UseItem(e);
        }

        async void SpawnItemInterval(int interval)
        {
            await Task.Delay(interval);
            if(item.ItemCount < 1)
            {
                item.SpawnItem();
            }
            SpawnItemInterval(interval);
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            p1.resetKeyPress();
            p2.resetKeyPress();
        }
    }
}
