using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
{
    internal abstract class Player
    {
        public bool isFirstKey = false;

        protected bool isDebuff1 = false;
        protected bool isDebuff2 = false;
        protected bool isDebuff3 = false;

        public PictureBox inventory;

        public Player()
        {

        }

        public abstract void MakeScore(KeyEventArgs e);
    }
}
