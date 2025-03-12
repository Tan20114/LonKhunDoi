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
        float score = 0;

        public KeyEventArgs key;

        bool p1FirstKey = false;
        bool p2FirstKey = false;

        bool p1Debuff = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void Start(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(HandleInput);
        }

        private void Update(object sender, EventArgs e)
        {
            label1.Text = score.ToString();
        }

        private void HandleInput(object sender, KeyEventArgs e)
        {
            if(!p1Debuff)
            {
                if (e.KeyCode == Keys.A && !p1FirstKey)
                {
                    p1FirstKey = true;
                    label2.Text = "A";
                }
                if (e.KeyCode == Keys.D && p1FirstKey)
                {
                    label2.Text = "D";
                    score++;
                    p1FirstKey = false;
                }
            }
            
            if(!p1Debuff)
            {
                if (e.KeyCode == Keys.J && !p2FirstKey)
                {
                    p2FirstKey = true;
                    label3.Text = "J";
                }
                if (e.KeyCode == Keys.L && p2FirstKey)
                {
                    label3.Text = "L";
                    score--;
                    p2FirstKey = false;
                }
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
    }
}
