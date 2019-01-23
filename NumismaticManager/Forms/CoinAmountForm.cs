using NumismaticManager.Logics;
using System;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class CoinAmountForm : Form
    {
        private int coinId;
        private string name;
        private int amount;

        public CoinAmountForm(int coinId, string name, int amount)
        {
            InitializeComponent();

            this.coinId = coinId;
            this.name = name;
            this.amount = amount;
        }

        private void CoinAmountForm_Load(object sender, EventArgs e)
        {
            LabelCoinName.Text = name;
            TextBoxCoinAmount.Text = amount.ToString();

            ButtonSave.Select();
        }

        private void CoinAmountForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Add || e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Oemplus)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CoinAmountForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                ButtonDecrement_Click(sender, null);
            }
            else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                ButtonIncrement_Click(sender, null);
            }
        }

        private void DataGridViewCoins_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Add)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
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
            Database.ChangeAmount(coinId, amount);

            DialogResult = DialogResult.OK;
        }
    }
}
