using NumismaticManager.Logics;
using NumismaticManager.Models.Changes;
using NumismaticManager.Models.Coins;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class NewCoinForm : Form
    {
        public NewCoinForm()
        {
            InitializeComponent();
        }

        private void NewCoinForm_Load(object sender, EventArgs e)
        {
            TextBoxValue.AutoCompleteCustomSource.AddRange(Database.GetCoinValues().ConvertAll(coin => coin.ToString()).ToArray());
            TextBoxFineness.AutoCompleteCustomSource.AddRange(Database.GetFinenesses().ToArray());
            TextBoxStamp.AutoCompleteCustomSource.AddRange(Database.GetStamps().ToArray());
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxName.Text.Trim().Length == 0)
            {
                Program.ShowInformation("Wprowadź przynajmniej część nazwy poszukiwanego numizmatu.");
            }
            else
            {
                Program.OpenBrowser($"https://supermonety.pl/pl/searchquery/{TextBoxName.Text}");
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            TextBoxDiameter.Text = TextBoxDiameter.Text.Replace(",", ".");
            TextBoxWeight.Text = TextBoxWeight.Text.Replace(",", ".");

            string validation = ValidateForm();

            if (validation == "OK")
            {
                DatabaseCoin coin = new DatabaseCoin
                {
                    Name = TextBoxName.Text,
                    Value = int.Parse(TextBoxValue.Text),
                    Diameter = decimal.Parse(TextBoxDiameter.Text, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US")),
                    Fineness = TextBoxFineness.Text,
                    Weight = decimal.Parse(TextBoxWeight.Text, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US")),
                    Edition = int.Parse(TextBoxEdition.Text),
                    Emission = DateTimePickerEmission.Value,
                    Stamp = TextBoxStamp.Text
                };

                try
                {
                    Database.Insert(coin);
                    Program.AddNewChange(new AddedNewCoin(Database.GetNewestCoinId()));

                    DialogResult = DialogResult.OK;
                }
                catch (Exception)
                {
                    Program.ShowError("Wystąpił błąd podczas próby dodania nowego numizmatu.");
                }
            }
            else
            {
                Program.ShowInformation(validation);
            }
        }

        private string ValidateForm()
        {
            string output = "";

            if (TextBoxName.Text.Length == 0)
            {
                output += "Podaj nazwę numizmatu.";
            }

            if (TextBoxValue.Text.Length == 0)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podaj nominał.";
            }
            else if (!int.TryParse(TextBoxValue.Text, out int value))
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Nominał musi być liczbą naturalną.";
            }

            if(TextBoxDiameter.Text.Length == 0)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podaj średnicę.";
            }
            else if (!decimal.TryParse(TextBoxDiameter.Text, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out decimal diameter))
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Średnica musi być liczbą rzeczywistą.";
            }

            if (TextBoxFineness.Text.Length == 0)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podaj próbę metalu.";
            }

            if (TextBoxWeight.Text.Length == 0)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podaj wagę monety.";
            }
            else if (!decimal.TryParse(TextBoxWeight.Text, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out decimal weight))
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Waga musi być liczbą rzeczywistą.";
            }

            if (TextBoxEdition.Text.Length == 0)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podaj nakład.";
            }
            else if (!int.TryParse(TextBoxEdition.Text, out int edition))
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Nakład musi być liczbą naturalną.";
            }

            if (DateTimePickerEmission.Value > DateTime.Now)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podano datę z przyszłości.";
            }

            if (TextBoxStamp.Text.Length == 0)
            {
                if (output.Length > 0) GoToNewLine(ref output);
                output += "Podaj rodzaj stempla.";
            }

            if (output.Length == 0) output = "OK";

            return output;
        }

        private void GoToNewLine(ref string input)
        {
            input += "\n";
        }
    }
}
