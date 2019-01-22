﻿using NumismaticManager.Logics;
using NumismaticManager.Models;
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
            System.Diagnostics.Process.Start($"https://supermonety.pl/pl/searchquery/{TextBoxName.Text}");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            TextBoxDiameter.Text = TextBoxDiameter.Text.Replace(",", ".");
            TextBoxWeight.Text = TextBoxWeight.Text.Replace(",", ".");

            string validation = ValidateForm();

            if (validation == "OK")
            {
                Coin coin = new Coin
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

                    DialogResult = DialogResult.OK;
                }
                catch (Exception)
                {
                    Main.ShowError("Wystąpił błąd podczas próby dodania nowego numizmatu.");
                }
            }
            else
            {
                Main.ShowInformation(validation);
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
