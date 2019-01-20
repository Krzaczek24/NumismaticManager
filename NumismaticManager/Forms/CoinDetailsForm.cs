using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NumismaticManager.Forms
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

            using (SQLiteDataReader reader = Main.Connector.ExecuteReader(query, parameters))
            {
                reader.Read();

                TextBoxCoinName.Text = reader.GetString(0);
                TextBoxCoinValue.Text = $"{reader.GetInt32(1):c0}";
                TextBoxCoinDiameter.Text = $"{reader.GetDecimal(2)} mm";
                TextBoxCoinFineness.Text = reader.GetString(3);
                TextBoxCoinWeight.Text = $"{reader.GetDecimal(4)} g";
                TextBoxCoinEdition.Text = $"{reader.GetInt32(5):n0}";
                TextBoxCoinEmission.Text = $"{reader.GetDateTime(6):d}";
                TextBoxCoinStamp.Text = reader.GetString(7);
            }
        }
    }
}
