using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
{
    internal class Player2 : Player
    {
        public override void MakeScore(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.J && isFirstKey)
            {
                isFirstKey = true;
            }
            if (e.KeyCode == Keys.L && isFirstKey)
            {
                Form1.score--;
                isFirstKey = false;
            }
        }
    }
}
