﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tantan
{
    internal class Player1 : Player
    {
        public Player1(Item itemRef, Form1 formRef)
        {
            item = itemRef;
            form = formRef;
            inventory = form.P1Inventory;
            debuffVisualize = form.label2;
        }

        public override void SetOpponent(Player opp)
        {
            opponent = opp;
        }

        public override void Update()
        {
            form.Counter.Text = debuff2Counter.ToString();
        }

        public override void MakeScore(KeyEventArgs e)
        {
            if (isDebuff3)
            {
                if (e.KeyCode == Keys.Q && !isFirstKey)
                {
                    isFirstKey = true;
                }
                if (e.KeyCode == Keys.T && isFirstKey)
                {
                    Form1.score += scoreValue;
                    finalScore += scoreValue;
                    isFirstKey = false;
                }
            }
            else if (isDebuff2)
            {
                if (e.KeyCode == Keys.A && !keyPressed)
                {
                    Form1.score += scoreValue;
                    finalScore += scoreValue;
                    debuff2Counter++;
                    keyPressed = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.A && !isFirstKey)
                {
                    isFirstKey = true;
                }
                if (e.KeyCode == Keys.D && isFirstKey)
                {
                    Form1.score += scoreValue;
                    finalScore += scoreValue;
                    isFirstKey = false;
                }
            }
        }

        Item get;

        public override void CollectItem(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.S && item.ItemCount > 0)
            {
                item.DestroyItem();
                item.ItemCount--;
                get = item.RandomItem();
                item.spriteRenderer = inventory;
                inventory.BackColor = get.color;
            }
        }

        public override void UseItem(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E && get != null)
            {
                opponent.debuff = get;
                opponent.DebuffCheck();
                opponent.DebuffHandle();
                opponent.debuff = null;
            }
            else
            {
                opponent.debuff = null;
            }
        }
    }
}
