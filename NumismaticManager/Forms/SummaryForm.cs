using NumismaticManager.Logics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class SummaryForm : Form
    {
        Dictionary<string, object> summary;

        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            summary = Database.GetUserCoinsSummary();

            double uniqueCoins = Convert.ToDouble(summary["uniqueCoins"]);
            int allCoins = Convert.ToInt32(summary["allCoins"]);
            double allCoinsPercentage = uniqueCoins * 100.0 / (allCoins == 0 ? 1 : allCoins);

            LabelProgressBar.Text = $"Posiadasz {uniqueCoins} egzemplarzy z {allCoins} ({allCoinsPercentage:0.00}%)";

            ProgressBar.Value = (int)allCoinsPercentage;

            ShowDetails(RadioButtonOwned);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            
            if (radioButton.Checked) ShowDetails(radioButton);
        }

        private void ShowDetails(RadioButton radioButton)
        {
                 if (radioButton == RadioButtonOwned) ShowDetailsOwned();
            else if (radioButton == RadioButtonUnique) ShowDetailsUnique();
            else if (radioButton == RadioButtonRedundant) ShowDetailsRedundant();
        }

        private void ShowDetailsOwned()
        {
            int ownedCoins = Convert.ToInt32(summary["ownedCoins"]);
            int ownedCoinsValue = Convert.ToInt32(summary["ownedCoinsValue"]);
            decimal ownedCoinsWeight = Convert.ToDecimal(summary["ownedCoinsWeight"]);

            LabelRightCount.Text = $"{ownedCoins} sztuk";
            LabelRightValue.Text = $"{ownedCoinsValue:c0}";
            LabelRightWeight.Text = $"{ownedCoinsWeight:n2} g";
            LabelRightPercent.Text = $"{100:f2} %";
        }

        private void ShowDetailsUnique()
        {
            int ownedCoins = Convert.ToInt32(summary["ownedCoins"]);
            int uniqueCoins = Convert.ToInt32(summary["uniqueCoins"]);
            int uniqueCoinsValue = Convert.ToInt32(summary["uniqueCoinsValue"]);
            decimal uniqueCoinsWeight = Convert.ToDecimal(summary["uniqueCoinsWeight"]);
            double uniqueCoinsPercentage = uniqueCoins * 100.0 / (ownedCoins == 0 ? 1 : ownedCoins);

            LabelRightCount.Text = $"{uniqueCoins} sztuk";
            LabelRightValue.Text = $"{uniqueCoinsValue:c0}";
            LabelRightWeight.Text = $"{uniqueCoinsWeight:n2} g";
            LabelRightPercent.Text = $"{uniqueCoinsPercentage:f2} %";
        }

        private void ShowDetailsRedundant()
        {
            int ownedCoins = Convert.ToInt32(summary["ownedCoins"]);
            int redundantCoins = Convert.ToInt32(summary["redundantCoins"]);
            int redundantCoinsValue = Convert.ToInt32(summary["redundantCoinsValue"]);
            decimal redundantCoinsWeight = Convert.ToDecimal(summary["redundantCoinsWeight"]);
            double redundantCoinsPercentage = redundantCoins * 100.0 / (ownedCoins == 0 ? 1 : ownedCoins);

            LabelRightCount.Text = $"{redundantCoins} sztuk";
            LabelRightValue.Text = $"{redundantCoinsValue:c0}";
            LabelRightWeight.Text = $"{redundantCoinsWeight:n2} g";
            LabelRightPercent.Text = $"{redundantCoinsPercentage:f2} %";
        }
    }
}
