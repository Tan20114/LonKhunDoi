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
        public Player2(Item itemRef, Form1 formRef)
        {
            item = itemRef;
            form = formRef;
            inventory = form.P2Inventory;
            debuffVisualize = form.label3;
        }

        public override void SetOpponent(Player opp)
        {
            opponent = opp;
        }

        public override void Update()
        {
            form.Counter2.Text = debuff2Counter.ToString();
        }

        public override void MakeScore(KeyEventArgs e)
        {
            if (isDebuff3)
            {
                if (e.KeyCode == Keys.Y && !isFirstKey)
                {
                    isFirstKey = true;
                }
                if (e.KeyCode == Keys.P && isFirstKey)
                {
                    Form1.score -= scoreValue;
                    finalScore += scoreValue;
                    isFirstKey = false;
                }
            }
            else if(isDebuff2)
            {
                if (e.KeyCode == Keys.J && !keyPressed)
                {
                    Form1.score -= scoreValue;
                    finalScore += scoreValue;
                    debuff2Counter++;
                    keyPressed = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.J && !isFirstKey)
                {
                    isFirstKey = true;
                }
                if (e.KeyCode == Keys.L && isFirstKey)
                {
                    Form1.score -= scoreValue;
                    finalScore += scoreValue;
                    isFirstKey = false;
                }
            }
        }

        Item get;

        public override void CollectItem(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && item.ItemCount > 0)
            {
                item.DestroyItem();
                item.ItemCount--;
                item.spriteRenderer = inventory;
                get = item.RandomItem();
                inventory.BackColor = get.color;
            }
        }

        public override void UseItem(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I && get != null)
            {
                opponent.debuff = get;
                opponent.DebuffCheck();
                opponent.DebuffHandle();
            }
            else
            {
                opponent.debuff = null;
            }
        }
    }
}
