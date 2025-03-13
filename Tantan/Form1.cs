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
        Player1 p1 = new Player1();

        public static float score = 0;

        bool p1FirstKey = false;
        bool p2FirstKey = false;

        bool p1Debuff = false;

        public Form1()
        {
            InitializeComponent();
            item = new Item(this);
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

            UIUpdate();
            item.Update();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            p1.MakeScore(e);
            if(!p1Debuff)
            {
                
            }
            else
            {
                if (e.KeyCode == Keys.J && !p2FirstKey)
                {
                    p2FirstKey = true;
                    label3.Text = "J";
                }
                if (e.KeyCode == Keys.L && p2FirstKey)
                {
                    label3.Text = "L";
                    score -= 0.1f;
                    p2FirstKey = false;
                }
            }
           
            if(e.KeyCode == Keys.R)
            {
                p1Debuff = true;
                DebuffCountdown();
            }
        }

        async void DebuffCountdown()
        {
            await Task.Delay(500);
            p1Debuff = false;
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

        void UIUpdate()
        {
            if (p1FirstKey)
            {
                D_Visualize.ForeColor = Color.Red;
                A_VIsualize.ForeColor = Color.Black;
            }
            else
            {
                A_VIsualize.ForeColor = Color.Red;
                D_Visualize.ForeColor = Color.Black;
            }

            if (p2FirstKey)
            {
                L_Visualize.ForeColor = Color.Red;
                J_Visualize.ForeColor = Color.Black;
            }
            else
            {
                J_Visualize.ForeColor = Color.Red;
                L_Visualize.ForeColor = Color.Black;
            }
        }
    }
}
