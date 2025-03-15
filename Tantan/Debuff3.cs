using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Tantan.Item;

namespace Tantan
{
    internal class Debuff3 : Item
    {
        public Debuff3()
        {
            type = DebuffType.Friend;
            sprite = null;
            color = Color.Yellow;
        }
    }
}
