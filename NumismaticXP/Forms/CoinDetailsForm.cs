using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Numismatic.Forms
{
    public partial class CoinDetailsForm : Form
    {
        private uint coinId;

        public CoinDetailsForm(uint coinId)
        {
            InitializeComponent();

            this.coinId = coinId;
        }

        private void CoinDetailsForm_Load(object sender, System.EventArgs e)
        {
            string query = "SELECT Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp FROM Coin Where Id = @id;";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "id", coinId }
            };

            using (MySqlDataReader reader = Main.Servant.ExecuteReader(query, parameters))
            {
                reader.Read();

                TextBoxCoinName.Text = reader.GetString("Name");
                TextBoxCoinValue.Text = $"{reader.GetUInt32("Value"):c0}";
                TextBoxCoinDiameter.Text = $"{reader.GetDecimal("Diameter")} mm";
                TextBoxCoinFineness.Text = reader.GetString("Fineness");
                TextBoxCoinWeight.Text = $"{reader.GetDecimal("Weight")} g";
                TextBoxCoinEdition.Text = $"{reader.GetUInt32("Edition"):n0}";
                TextBoxCoinEmission.Text = $"{reader.GetDateTime("Emission"):d}";
                TextBoxCoinStamp.Text = reader.GetString("Stamp");
            }
        }
    }
}
