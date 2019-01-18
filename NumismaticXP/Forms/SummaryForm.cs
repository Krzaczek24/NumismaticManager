using NumismaticXP.Logics;
using System;
using System.Windows.Forms;

namespace NumismaticXP.Forms
{
    public partial class SummaryForm : Form
    {
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            int ownedCoins = Database.GetUserUniqueCoins();
            int allCoins = Database.GetCoinsCount();

            double percent = ownedCoins * 100.0 / allCoins;

            LabelProgressBar.Text = $"Posiadasz {ownedCoins} monet z {allCoins} ({percent:0.00}%)";

            ProgressBar.Value = (int)percent;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
