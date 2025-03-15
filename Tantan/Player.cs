using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
{
    internal abstract class Player
    {
        #region Reference
        protected Item item;
        protected Form1 form;
        #endregion

        #region Core
        public bool isFirstKey = false;
        protected float scoreValue = 1;
        public float finalScore = 0;
        #endregion

        #region object ref
        protected Player opponent;
        public Item debuff;
        protected Label debuffVisualize;
        public PictureBox inventory;
        #endregion

        #region Debuff var
        protected bool isDebuff1 = false;

        protected bool isDebuff2 = false;
        protected bool isDebuff2End = false;
        protected int debuff2Counter = 0;
        protected bool keyPressed = false;

        public bool isDebuff3 = false;
        #endregion

        #region Initial
        public abstract void SetOpponent(Player opp);
        #endregion

        #region update
        public abstract void Update();
        #endregion

        #region Input Func
        public abstract void MakeScore(KeyEventArgs e);

        public abstract void CollectItem(KeyEventArgs e);

        public abstract void UseItem(KeyEventArgs e);
        #endregion

        #region Debuff Func
        public void DebuffCheck()
        {
            if (debuff != null)
            {
                if (debuff.type == Item.DebuffType.Shit)
                {
                    isDebuff1 = true;
                }
                else if (debuff.type == Item.DebuffType.Car)
                {
                    isDebuff2 = true;
                }
                else if (debuff.type == Item.DebuffType.Friend)
                {
                    isDebuff3 = true;
                }
            }

        }

        public void DebuffHandle()
        {
            if(isDebuff1)
            {
                Debuff1();
            }
            if(isDebuff2)
            {
                Debuff2();
            }
            if(isDebuff3)
            {
                Debuff3();
            }
        }

        async void Debuff1()
        {
            Debuff1 debuff = new Debuff1();

            scoreValue = debuff.scoreValue;
            opponent.scoreValue = debuff.oppScoreValue;
            debuffVisualize.ForeColor = Color.Red;

            await Task.Delay(500);

            scoreValue = 1;
            opponent.scoreValue = 1;
            debuffVisualize.ForeColor = Color.Black;

            isDebuff1 = false;
        }
        
        async void Debuff2()
        {
            Debuff2 debuff = new Debuff2();

            scoreValue = debuff.scoreValue;
            debuffVisualize.ForeColor = Color.Blue;

            await Task.Delay(5000);

            isDebuff2 = false;
            isDebuff2End = true;
            Debuff2Check();

            debuffVisualize.ForeColor = Color.Black;
        }

        protected async void Debuff2Check()
        {
            if(isDebuff2End)
            {
                if (debuff2Counter < 30)
                {
                    scoreValue = 0;
                    await Task.Delay(2000);
                }
                else
                {
                    scoreValue = 1;
                    await Task.Delay(2000);
                }
                debuff2Counter = 0;
                scoreValue = 1;
            }
        }

        async void Debuff3()
        {
            debuffVisualize.ForeColor = Color.Yellow;
            await Task.Delay(10000);
            debuffVisualize.ForeColor = Color.Black;
            isDebuff3 = false;
        }

        public void resetKeyPress()
        {
            keyPressed = false;
        }
        #endregion
    }
}
