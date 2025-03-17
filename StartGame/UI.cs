using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
{
    internal class UI
    {
        Form1 _form;
        Player1 p1;
        Player2 p2;

        public UI(Form1 form, Player1 p1,Player2 p2)
        {
            _form = form;
            this.p1 = p1;
            this.p2 = p2;
        }

        public void Update()
        {
            ScoreShow();
            KeyVisualize();
        }

        void ScoreShow()
        {
            _form.ScoreTxt.Text = Math.Abs(Math.Round(Form1.score,2)).ToString();
            if (Form1.score > 0)
            {
                _form.ScoreTxt.ForeColor = Color.Purple;
            }
            else if (Form1.score < 0)
            {
                _form.ScoreTxt.ForeColor = Color.Yellow;
            }
            else
            {
                _form.ScoreTxt.ForeColor = Color.Black;
            }
        }

        void KeyVisualize()
        {
            if (p1.isDebuff3)
            {
                _form.LVisual1.BackgroundImage = Image.FromFile((p1.isFirstKey ? Assets.keyPress[5] : Assets.key[5]));
                _form.RVisual1.BackgroundImage = Image.FromFile((p1.isFirstKey ? Assets.key[6] : Assets.keyPress[6]));
            }
            else if(p1.isDebuff2)
            {
                _form.LVisual1.BackgroundImage = Image.FromFile((p1.keyPressed ? Assets.keyPress[0] : Assets.key[0]));
                _form.RVisual1.BackgroundImage = null;
            }
            else
            {
                _form.LVisual1.BackgroundImage = Image.FromFile((p1.isFirstKey ? Assets.keyPress[0] : Assets.key[0]));
                _form.RVisual1.BackgroundImage = Image.FromFile((p1.isFirstKey ? Assets.key[1] : Assets.keyPress[1]));
            }

            if (p2.isDebuff3)
            {
                _form.LVisual2.BackgroundImage = Image.FromFile((p2.isFirstKey ? Assets.keyPress[7] : Assets.key[7]));
                _form.RVisual2.BackgroundImage = Image.FromFile((p2.isFirstKey ? Assets.key[4] : Assets.keyPress[4]));
            }
            else if (p2.isDebuff2)
            {
                _form.LVisual2.BackgroundImage = Image.FromFile((p2.keyPressed ? Assets.keyPress[2] : Assets.key[2]));
                _form.RVisual2.BackgroundImage = null;
            }
            else                                                  
            {                                                     
                _form.LVisual2.BackgroundImage = Image.FromFile((p2.isFirstKey ? Assets.keyPress[2] : Assets.key[2]));
                _form.RVisual2.BackgroundImage = Image.FromFile((p2.isFirstKey ? Assets.key[3] : Assets.keyPress[3]));
            }
        }
    }
}
