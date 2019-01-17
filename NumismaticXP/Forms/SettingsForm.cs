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
            List<int> userFilter = Database.GetUserCoinFilter();

            // TODO: Przenieść ustawienie filtra wyświetlanych monet do ustawień aplikacji

            foreach (int coinValue in coinValues)
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
