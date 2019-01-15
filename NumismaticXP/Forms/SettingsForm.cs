using Numismatic.Logics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Numismatic.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            List<uint> coinValues = Database.GetCoinValues();
            List<uint> userFilter = Main.LoggedUser.ShowCoins;

            foreach (uint coinValue in coinValues)
            {
                CheckBoxesCoins.Items.Add(coinValue, userFilter.Contains(coinValue));
            }
        }

        private void ButtonSaveSettings_Click(object sender, EventArgs e)
        {
            List<uint> coinValues = new List<uint>();

            foreach (uint coinValue in CheckBoxesCoins.CheckedItems)
            {
                coinValues.Add(coinValue);
            }

            Database.SaveCoinsFilter(coinValues);

            DialogResult = DialogResult.OK;
        }
    }
}
