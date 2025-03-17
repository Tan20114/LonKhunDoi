using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartGame
{
    internal class Debuff2 : Item
    {
        public float scoreValue = 0.5f;
        public Debuff2()
        {
            type = DebuffType.Car;
            sprite = Assets.carIcon;
            color = Color.Blue;
        }
    }
}
