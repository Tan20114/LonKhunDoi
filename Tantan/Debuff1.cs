using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
{
    internal class Debuff1 : Item
    {
        public float scoreValue = 0f;
        public float oppScoreValue = 0.2f;
        public Debuff1()
        {
            type = DebuffType.Shit;
            sprite = null;
            color = Color.Red;
        }
    }
}
