using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
{
    internal class Debuff1 : Item
    {
        public float scoreValue = 0f;
        public float oppScoreValue = 0.2f;
        public Debuff1()
        {
            type = DebuffType.Shit;
            sprite = Assets.shitIcon;
            color = Color.Red;
        }
    }
}
