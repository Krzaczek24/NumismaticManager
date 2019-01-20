using NumismaticXP.Logics;
using System;
using System.Windows.Forms;

namespace NumismaticXP.Forms
{
    public partial class SummaryForm : Form
    {
        int allCoins;
        double allCoinsPercentage;

        int ownedCoins;
        int ownedCoinsValue;
        decimal ownedCoinsWeight;
        double ownedCoinsPercentage;

        int uniqueCoins;
        int uniqueCoinsValue;
        decimal uniqueCoinsWeight;
        double uniqueCoinsPercentage;

        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            allCoins = Database.GetCoinsCount(Properties.Settings.Default.CoinFilter);

            ownedCoins = Database.GetUserTotalCoins(Properties.Settings.Default.CoinFilter);
            ownedCoinsValue = Database.GetUserTotalValue(Properties.Settings.Default.CoinFilter);
            ownedCoinsWeight = Database.GetUserTotalWeight(Properties.Settings.Default.CoinFilter);
            ownedCoinsPercentage = ownedCoins * 100.0 / allCoins;

            uniqueCoins = Database.GetUserUniqueCoins(Properties.Settings.Default.CoinFilter);
            uniqueCoinsValue = Database.GetUserUniqueValue(Properties.Settings.Default.CoinFilter);
            uniqueCoinsWeight = Database.GetUserUniqueWeight(Properties.Settings.Default.CoinFilter);
            uniqueCoinsPercentage = uniqueCoins * 100.0 / ownedCoins;

            allCoinsPercentage = uniqueCoins * 100.0 / allCoins;

            LabelProgressBar.Text = $"Posiadasz {uniqueCoins} egzemplarzy z {allCoins} ({allCoinsPercentage:0.00}%)";

            ProgressBar.Value = (int)allCoinsPercentage;

            ShowDetails(RadioButtonOwned);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            
            if (radioButton.Checked) ShowDetails(radioButton);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ShowDetails(RadioButton radioButton)
        {
                 if (radioButton == RadioButtonOwned) ShowDetailsOwned();
            else if (radioButton == RadioButtonUnique) ShowDetailsUnique();
            else if (radioButton == RadioButtonRedundant) ShowDetailsRedundant();
        }

        private void ShowDetailsOwned()
        {
            LabelRightCount.Text = $"{ownedCoins} sztuk";
            LabelRightValue.Text = $"{ownedCoinsValue:c0}";
            LabelRightWeight.Text = $"{ownedCoinsWeight:n2} g";
            LabelRightPercent.Text = $"100.00 %";
        }

        private void ShowDetailsUnique()
        {
            LabelRightCount.Text = $"{uniqueCoins} sztuk";
            LabelRightValue.Text = $"{uniqueCoinsValue:c0}";
            LabelRightWeight.Text = $"{uniqueCoinsWeight:n2} g";
            LabelRightPercent.Text = $"{uniqueCoinsPercentage:f2} %";
        }

        private void ShowDetailsRedundant()
        {
            LabelRightCount.Text = $"{ownedCoins - uniqueCoins} sztuk";
            LabelRightValue.Text = $"{ownedCoinsValue - uniqueCoinsValue:c0}";
            LabelRightWeight.Text = $"{ownedCoinsWeight - uniqueCoinsWeight:n2} g";
            LabelRightPercent.Text = $"{100 - uniqueCoinsPercentage:f2} %";
        }
    }
}
