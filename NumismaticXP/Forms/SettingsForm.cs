using NumismaticXP.Logics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NumismaticXP.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            List<int> coinValues = Database.GetCoinValues();
            List<int> userFilter = new List<int>();

            if (Properties.Settings.Default.CoinFilter.Length > 0)
            {
                foreach (string value in Properties.Settings.Default.CoinFilter.Split(','))
                {
                    userFilter.Add(int.Parse(value));
                }
            }

            foreach (int coinValue in coinValues)
            {
                CheckBoxesCoins.Items.Add(coinValue, userFilter.Contains(coinValue));

                if (userFilter.Contains(coinValue))
                {
                    ListBoxShown.Items.Add(coinValue);
                }
                else
                {
                    ListBoxHidden.Items.Add(coinValue);
                }
            }

            TextBoxWebsitePath.Text = Properties.Settings.Default.NBPSite;
        }

        private void ButtonSaveSettings_Click(object sender, EventArgs e)
        {
            List<int> coinValues = new List<int>();

            foreach (int coinValue in CheckBoxesCoins.CheckedItems)
            {
                coinValues.Add(coinValue);
            }

            Properties.Settings.Default.CoinFilter = string.Join(",", coinValues);

            //foreach (int coinValue in ListBoxShown.Items)
            //{
            //    coinValues.Add(coinValue);
            //}

            //Properties.Settings.Default.CoinFilter = string.Join(",", coinValues);

            Properties.Settings.Default.NBPSite = TextBoxWebsitePath.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
