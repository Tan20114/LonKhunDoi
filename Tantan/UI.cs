using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
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
            KeyVisualize();
        }

        void KeyVisualize()
        {
            if(p1.isDebuff3)
            {
                _form.A_VIsualize.Text = "Q";
                _form.D_Visualize.Text = "T";
            }
            else
            {
                _form.A_VIsualize.Text = "A";
                _form.D_Visualize.Text = "D";
            }

            if (p2.isDebuff3)
            {
                _form.J_Visualize.Text = "Y";
                _form.L_Visualize.Text = "P";
            }
            else
            {
                _form.J_Visualize.Text = "J";
                _form.L_Visualize.Text = "L";
            }

            if (p1.isFirstKey)
            {
                _form.D_Visualize.ForeColor = Color.Red;
                _form.A_VIsualize.ForeColor = Color.Black;
            }
            else
            {
                _form.A_VIsualize.ForeColor = Color.Red;
                _form.D_Visualize.ForeColor = Color.Black;
            }

            if (p2.isFirstKey)
            {
                _form.L_Visualize.ForeColor = Color.Red;
                _form.J_Visualize.ForeColor = Color.Black;
            }
            else
            {
                _form.J_Visualize.ForeColor = Color.Red;
                _form.L_Visualize.ForeColor = Color.Black;
            }
        }
    }
}
