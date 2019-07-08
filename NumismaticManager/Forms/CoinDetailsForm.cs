using NumismaticManager.Logics;
using NumismaticManager.Models.Coins;
using System;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class CoinDetailsForm : Form
    {
        private int coinId;

        public CoinDetailsForm(int coinId)
        {
            InitializeComponent();

            this.coinId = coinId;
        }

        private void CoinDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseCoin coin = Database.GetCoin(coinId);

                TextBoxCoinName.Text = coin.Name;
                TextBoxCoinValue.Text = $"{coin.Value:c0}";
                TextBoxCoinDiameter.Text = $"{coin.Diameter} mm";
                TextBoxCoinFineness.Text = coin.Fineness;
                TextBoxCoinWeight.Text = $"{coin.Weight} g";
                TextBoxCoinEdition.Text = $"{coin.Edition:n0}";
                TextBoxCoinEmission.Text = $"{coin.Emission:d}";
                TextBoxCoinStamp.Text = coin.Stamp;
            }
            catch (Exception ex)
            {
                Database.AddError(ex.Message, "CoinDetailsForm.cs", "CoinDetailsForm_Load(object sender, EventArgs e)");
                Program.ShowError("Wystąpił błąd podczas pobierania szczegółów o numizmacie.");
                DialogResult = DialogResult.Abort;                
            }
        }
    }
}
