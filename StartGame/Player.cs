using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartGame
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
        public PictureBox inventory;
        public Animation ani;
        public PictureBox aniPlaceHolder;
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

            if (opponent is Player1)
            {
                ani.StopAnimation();
                ani = new Animation(Assets.pooSheet2, aniPlaceHolder, 100);
                ani.StartAnimation();
            }
            else
            {
                ani.StopAnimation();
                ani = new Animation(Assets.pooSheet, aniPlaceHolder, 100);
                ani.StartAnimation();
            }

            Assets.PodKee.Stop();
            Assets.PodKee.Play();
            await Task.Delay(2000);
            Assets.WhereIsHongNam.Stop();
            Assets.WhereIsHongNam.Play();

            await Task.Delay(2000);

            await MoveControl(aniPlaceHolder,(opponent is Player1)? aniPlaceHolder.Location.X + 1000 : aniPlaceHolder.Location.X - 1000, 100);

            scoreValue = debuff.scoreValue;
            opponent.scoreValue = debuff.oppScoreValue;


            Assets.KaeMapenKon.Stop();
            Assets.KaeMapenKon.Play();
            await Task.Delay(1500);

            scoreValue = 1;
            opponent.scoreValue = 1;

            if (opponent is Player1)
            {
                ani.StopAnimation();
                ani = new Animation(Assets.SpriteSheetPath2, aniPlaceHolder, 100);
                ani.StartAnimation();
            }
            else
            {
                ani.StopAnimation();
                ani = new Animation(Assets.SpriteSheetPath, aniPlaceHolder, 100);
                ani.StartAnimation();
            }

            await MoveControl(aniPlaceHolder, (opponent is Player1) ? aniPlaceHolder.Location.X - 1000 : aniPlaceHolder.Location.X + 1000, 100);

            isDebuff1 = false;
        }
        
        async void Debuff2()
        {
            Debuff2 debuff = new Debuff2();

            Assets.Shit_Sray.Stop();
            Assets.Shit_Sray.Play();
            await Task.Delay(3000);
            Assets.RodMalaJa.Stop();
            Assets.RodMalaJa.Play();
            scoreValue = debuff.scoreValue;

            await Task.Delay(5000);

            isDebuff2 = false;
            isDebuff2End = true;
            Debuff2Check();
        }

        protected async void Debuff2Check()
        {
            if(isDebuff2End)
            {
                Control carObj = (opponent is Player1) ? form.Car2 : form.Car1;
                if(carObj != null)
                {
                    carObj.Visible = true;
                }

                if (debuff2Counter < 30)
                {
                    await MoveControl(carObj,carObj.Location.Y+2000,'Y',100);
                    carObj.Visible = false;
                    carObj.Location = new Point(carObj.Location.X, carObj.Location.Y - 2000);
                    scoreValue = 0;
                    await Task.Delay(2000);
                    if (opponent is Player1)
                    {
                        ani.StopAnimation();
                        ani = new Animation(Assets.SpriteSheetPath2, aniPlaceHolder, 100);
                        ani.StartAnimation();
                    }
                    else
                    {
                        ani.StopAnimation();
                        ani = new Animation(Assets.SpriteSheetPath, aniPlaceHolder, 100);
                        ani.StartAnimation();
                    }
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
            Control seniorObj = (opponent is Player1)? form.Senior2 : form.Senior1;
            if(seniorObj != null)
            {
                seniorObj.Visible = true;
            }

            await MoveControl(seniorObj, aniPlaceHolder.Location.X, 100);

            seniorObj.Visible = false;

            if (opponent is Player1)
            {
                ani.StopAnimation();
                ani = new Animation(Assets.hug2, aniPlaceHolder, 100);
                ani.StartAnimation();
            }
            else
            {
                ani.StopAnimation();
                ani = new Animation(Assets.hug1, aniPlaceHolder, 100);
                ani.StartAnimation();
            }

            await Task.Delay(10000);

            seniorObj.Visible = true;

            if (opponent is Player1)
            {
                ani.StopAnimation();
                ani = new Animation(Assets.SpriteSheetPath2, aniPlaceHolder, 100);
                ani.StartAnimation();
            }
            else
            {
                ani.StopAnimation();
                ani = new Animation(Assets.SpriteSheetPath, aniPlaceHolder, 100);
                ani.StartAnimation();
            }

            await MoveControl(seniorObj, (opponent is Player1)? seniorObj.Location.X + 1000 : seniorObj.Location.X -1000 , 100);
            seniorObj.Visible = false;

            isDebuff3 = false;
        }

        public void resetKeyPress()
        {
            keyPressed = false;
        }

        private async Task MoveControl(Control control, int targetX, int duration = 500)
        {
            int steps = 20;
            int delay = duration / steps;
            int startX = control.Location.X;
            int deltaX = (targetX - startX) / steps;

            for (int i = 0; i < steps; i++)
            {
                control.Location = new Point(control.Location.X + deltaX, control.Location.Y);
                await Task.Delay(delay);
            }
        }

        private async Task MoveControl(Control control, int targetY, char y, int duration = 500)
        {
            char x = y;
            int steps = 20;
            int delay = duration / steps;
            int startY = control.Location.Y;
            int deltaY = (targetY - startY) / steps;

            for (int i = 0; i < steps; i++)
            {
                control.Location = new Point(control.Location.X , control.Location.Y+ deltaY);
                await Task.Delay(delay);

                if(control.Bounds.IntersectsWith(aniPlaceHolder.Bounds) && aniPlaceHolder.Visible == true)
                {
                    Assets.BangAndCrom.Stop();
                    Assets.BangAndCrom.Play();
                    ani.StopAnimation();
                    ani = new Animation((opponent is Player1) ? Assets.crashSheet2 : Assets.crashSheet, aniPlaceHolder, 100);
                    ani.StartAnimation();
                }
            }
        }

        #endregion
    }
}
