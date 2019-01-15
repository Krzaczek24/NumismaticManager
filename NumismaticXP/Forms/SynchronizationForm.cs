using Numismatic.Logics;
using Numismatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Numismatic.Forms
{
    public partial class SynchronizationForm : Form
    {
        public SynchronizationForm()
        {
            InitializeComponent();
        }

        private void SyncSelectionForm_Load(object sender, EventArgs e)
        {
            //ButtonWipeUserCollection.Enabled = Main.LoggedUser.IsAdmin;
        }

        private void ButtonFastSynchronization_Click(object sender, EventArgs e)
        {
            Main.SetCursor(Cursors.WaitCursor);

            List<Coin> nbpCoins = null, databaseCoins = null;

            using (BusyForm busyForm = new BusyForm("Pobieranie danych, to może zająć kilka sekund ..."))
            {
                try
                {
                    nbpCoins = NBP.DownloadAllCoins();
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("Wystąpił błąd podczas nawiązywania połączenia ze stroną:\n'https://www.nbp.pl'.", "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (HtmlAgilityPack.NodeNotFoundException)
                {
                    MessageBox.Show("Pomimo pomyślnego nawiązania połączenia, nie odnaleziono katalogu z rocznikami monet.", "Błąd strony", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                databaseCoins = Database.DownloadAllCoins();
            }

            using (BusyForm busyForm = new BusyForm($"Zapisywanie danych, to może zająć nawet minutę ..."))
            {
                nbpCoins.RemoveAll(coin => databaseCoins.Contains(coin));
                nbpCoins = nbpCoins.Distinct().ToList();

                try
                {
                    Main.SetStatus($"Zapisano 0 z {nbpCoins.Count} monet (0%)");
                    Main.Servant.BeginTransaction();
                    for (int i = 0; i < nbpCoins.Count; i++)
                    {
                        Database.Insert(nbpCoins[i]);
                        Main.SetStatus($"Zapisano {i + 1} z {nbpCoins.Count} monet ({(i + 1) * 100 / nbpCoins.Count}%)");
                    }
                    Main.Servant.CommitTransaction();
                }
                catch
                {
                    Main.Servant.RollbackTransaction();
                    MessageBox.Show($"Wystąpił błąd podczas zapisywania monet do bazy.\n\nWszelkie zmiany zostały wycofane. Jeżeli nadal chcesz przeprowadzić synchronizację, skorzystaj z ręcznej synchronizacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }

            Main.SetStatus($"Pomyślnie zsynchronizowano.");
            Main.SetCursor(Cursors.Default);

            DialogResult = DialogResult.OK;
        }

        private void ButtonAdvancedSynchronization_Click(object sender, EventArgs e)
        {
            ////Przygotowanie listy dla wszystkich znalezionych monet
            //List<Dictionary<string, string>> foundCoins = new List<Dictionary<string, string>>();

            //HtmlAgilityPack.HtmlWeb htmlWeb = new HtmlAgilityPack.HtmlWeb();

            ////Pobranie listy roczników
            //HtmlAgilityPack.HtmlDocument catalogWebsite = htmlWeb.Load("https://www.nbp.pl/home.aspx?f=/banknoty_i_monety/monety_okolicznosciowe/katalog.html");

            ////Wybranie elementów [div] z atrybutem [class] o wartości [aslices] (tabela z rocznikami)
            //HtmlAgilityPack.HtmlNodeCollection yearsTable = catalogWebsite.DocumentNode.SelectNodes("//div[@class='aslices']//a");

            //foreach (HtmlAgilityPack.HtmlNode yearValue in yearsTable)
            //{
            //    //Pobranie strony z monetami z roku 2018
            //    HtmlAgilityPack.HtmlDocument coinsWebsite = htmlWeb.Load($"https://www.nbp.pl/home.aspx?f=/banknoty_i_monety/monety_okolicznosciowe/{yearValue.InnerText}.html");

            //    //Wybranie wszystkich elementów [table] z atrybutem [class] o wartości [moneta] (występują w poprzednich latach)
            //    HtmlAgilityPack.HtmlNodeCollection coinTables = coinsWebsite.DocumentNode.SelectNodes("//table[@class='moneta']");

            //    //Jeżeli strona nie pasuje do schematu ze starszych lat (2011 i w dół) to zmień sposób wyszukiwania
            //    if (coinTables == null)
            //    {
            //        //Wybranie wszystkich elementów [table] z atrybutem [class] o wartości [monety]
            //        //Nadrzędne tabele to grupy monet - podrzędne to poszczególne monety
            //        coinTables = coinsWebsite.DocumentNode.SelectNodes("//table[@class='monety']//table");
            //    }

            //    //Przejście po wszystkich elementach odpowiadających indywidualnym monetom
            //    foreach (HtmlAgilityPack.HtmlNode coinTable in coinTables)
            //    {
            //        //przygotowanie słownika dla danych o znalezionej monecie
            //        Dictionary<string, string> foundCoin = new Dictionary<string, string>();

            //        //Wybranie wszystkich elementów [tr] z wybranej tabeli
            //        //HtmlAgilityPack.HtmlNodeCollection rows = coinTable.SelectNodes(".//tr[not(@class)]");
            //        HtmlAgilityPack.HtmlNodeCollection rows = coinTable.SelectNodes(".//tr[not(@class)]");
            //        //Linie [tr]:
            //        //nazwa i nominał,
            //        //zdjęcia,
            //        //opcjonalne dodatkowe zdjęcia,
            //        //nazwy parametrów,
            //        //wartości parametrów,
            //        //opcjonalne dodatkowe zdjęcia,
            //        //dodatki.

            //        //Wybranie pierwszej linii [tr] z dwoma elementami [td] (nazwa | nominał)
            //        HtmlAgilityPack.HtmlNodeCollection coinMainDetailsCells = rows[0].SelectNodes(".//td");
            //        foundCoin.Add("Nazwa", coinMainDetailsCells[0].InnerText);
            //        foundCoin.Add("Nominał", coinMainDetailsCells[1].InnerText);

            //        //Wybranie ostatnich linii [tr] od końca z typami parametrów i ich wartościami
            //        int rowsCount = rows.Count - (rows[rows.Count - 1].SelectSingleNode(".//td").InnerText.Contains("Uwagi") ? 1 : 0);
            //        HtmlAgilityPack.HtmlNodeCollection keys = rows[rowsCount - 2].SelectNodes(".//td");
            //        HtmlAgilityPack.HtmlNodeCollection values = rows[rowsCount - 1].SelectNodes(".//td");

            //        for (int i = 0; i < keys.Count; i++)
            //        {
            //            foundCoin.Add($"{keys[i].InnerText.Trim(' ')}", values[i].InnerText.Trim(' '));
            //        }

            //        foundCoins.Add(foundCoin);
            //    }
            //}

            //string query = "INSERT INTO Coin(Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp) " +
            //                "VALUES(@name, @value, @diameter, @fineness, @weight, @edition, @emission, @stamp);";

            //Servant.BeginTransaction();

            ////Parsowanie otrzymanych danych by były zgodne z bazą danych
            //foundCoins.ForEach(delegate (Dictionary<string, string> coin)
            //{
            //    if (coin.ContainsKey("Wymiary"))
            //    {
            //        coin.Add("Średnica", coin["Wymiary"].Replace("(kwadrat)", ""));
            //    }
            //    else if (coin.ContainsKey("Rozmiar"))
            //    {
            //        coin.Add("Średnica", coin["Rozmiar"].Replace("(kwadrat)", ""));
            //    }

            //    if (coin.ContainsKey("Stop"))
            //    {
            //        coin.Add("Próba", coin["Stop"]);
            //    }

            //    Dictionary<string, object> parameters = new Dictionary<string, object>();

            //    parameters.Add("name", coin["Nazwa"].Trim(' ').Replace("&nbsp;", "").Replace("&nbsp", ""));
            //    parameters.Add("value", UInt32.Parse(substringNumeric(coin["Nominał"])));
            //    parameters.Add("diameter", Decimal.Parse(substringNumeric(coin["Średnica"])));
            //    parameters.Add("fineness", coin["Próba"].Replace(" ", "").Replace("&nbsp;", ""));
            //    parameters.Add("weight", Decimal.Parse(substringNumeric(coin["Masa"])));
            //    parameters.Add("edition", UInt32.Parse(substringNumeric(coin["Nakład"])));
            //    parameters.Add("emission", DateTime.Parse(coin["Data emisji"]));
            //    parameters.Add("stamp", coin["Stempel"].Trim(' '));

            //    try
            //    {
            //        Servant.ExecuteNonQuery(query, parameters);
            //    }
            //    catch (MySqlException ex)
            //    {
            //        if (!ex.Message.Contains("UNIQUE"))
            //        {
            //            throw ex;
            //        }
            //    }
            //});

            //Servant.CommitTransaction();

            //DialogResult = DialogResult.OK;
        }

        private void ButtonWipeUserCollection_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Czy na pewno chcesz usunąć całą swoją kolekcję?\n(pozycji: {Main.LoggedUser.UniqueCoins} | monet: {Main.LoggedUser.TotalCoins} | wartość: {Main.LoggedUser.TotalValue} zł)", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;

                try
                {
                    Main.Servant.BeginTransaction();
                    Main.Servant.ExecuteNonQuery($"UPDATE Collection SET Amount = 0 WHERE Id_user = {Main.LoggedUser.Id};");
                    Main.Servant.CommitTransaction();
                    MessageBox.Show("Pomyślnie usunięto kolekcję.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    Main.Servant.RollbackTransaction();
                    MessageBox.Show("Wystąpił błąd podczas usuwania kolekcji!\nOperacja została wycofana.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
