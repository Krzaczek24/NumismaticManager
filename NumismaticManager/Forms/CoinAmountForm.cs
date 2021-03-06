﻿using NumismaticManager.Logics;
using NumismaticManager.Models.Changes;
using System;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class CoinAmountForm : Form
    {
        private int coinId;
        private string name;
        private readonly int previousAmount;
        private int amount;

        public CoinAmountForm(int coinId, string name, int amount)
        {
            InitializeComponent();

            this.coinId = coinId;
            this.name = name;
            this.amount = amount;

            previousAmount = amount;
        }

        private void CoinAmountForm_Load(object sender, EventArgs e)
        {
            LabelCoinName.Text = name;
            TextBoxCoinAmount.Text = amount.ToString();

            ButtonSave.Select();
        }

        private void CoinAmountForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                ButtonDecrement_Click(sender, EventArgs.Empty);
            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
                ButtonIncrement_Click(sender, EventArgs.Empty);
            }
        }

        private void ButtonDecrement_Click(object sender, EventArgs e)
        {
            if (amount > 0)
            {
                TextBoxCoinAmount.Text = (--amount).ToString();
            }
        }

        private void ButtonIncrement_Click(object sender, EventArgs e)
        {
            TextBoxCoinAmount.Text = (++amount).ToString();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (previousAmount != amount)
            {
                Database.ChangeAmount(coinId, amount);
                Program.AddNewChange(new ChangedCoinAmount(coinId, previousAmount, amount));
                DialogResult = DialogResult.OK;
            }
        }
    }
}
