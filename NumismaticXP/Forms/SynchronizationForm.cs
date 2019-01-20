using NumismaticXP.Logics;
using NumismaticXP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NumismaticXP.Forms
{
    public partial class SynchronizationForm : Form
    {
        public SynchronizationForm()
        {
            InitializeComponent();
        }

        private void ButtonFastSynchronization_Click(object sender, EventArgs e)
        {
            Main.SetCursor(Cursors.WaitCursor);

            List<Coin> nbpCoins = null;
            List<Coin> databaseCoins = null;

            int websiteCoinsCount = 0;
            int newCoinsCount = 0;

            using (BusyForm busyForm = new BusyForm("Pobieranie danych, to może zająć kilka sekund ..."))
            {
                try
                {
                    websiteCoinsCount = (nbpCoins = NBP.DownloadAllCoins()).Count;
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show($"Wystąpił błąd podczas nawiązywania połączenia ze stroną:\n{Properties.Settings.Default.NBPSite}.", "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Main.SetCursor(Cursors.Default);
                    return;
                }
                catch (HtmlAgilityPack.NodeNotFoundException)
                {
                    MessageBox.Show("Pomimo pomyślnego nawiązania połączenia, nie odnaleziono katalogu z rocznikami monet.", "Błąd strony", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Main.SetCursor(Cursors.Default);
                    return;
                }

                databaseCoins = Database.DownloadAllCoins();
            }

            using (BusyForm busyForm = new BusyForm($"Zapisywanie danych, to może zająć nawet minutę ..."))
            {
                nbpCoins.RemoveAll(coin => databaseCoins.Contains(coin));
                newCoinsCount = (nbpCoins = nbpCoins.Distinct().ToList()).Count;

                try
                {
                    //Main.SetStatus($"Zapisano 0 z {nbpCoins.Count} monet (0%)");
                    Main.Connector.BeginTransaction();
                    for (int i = 0; i < nbpCoins.Count; i++)
                    {
                        Database.Insert(nbpCoins[i]);
                        //Main.SetStatus($"Zapisano {i + 1} z {nbpCoins.Count} monet ({(i + 1) * 100 / nbpCoins.Count}%)");
                    }
                    Main.Connector.CommitTransaction();
                }
                catch
                {
                    Main.Connector.RollbackTransaction();
                    MessageBox.Show($"Wystąpił błąd podczas zapisywania monet do bazy.\n\nWszelkie zmiany zostały wycofane. Jeżeli nadal chcesz przeprowadzić synchronizację, skorzystaj z ręcznej synchronizacji.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Main.SetCursor(Cursors.Default);
                    return;
                }                
            }

            Main.SetStatus($"Pomyślnie zsynchronizowano.");
            Main.SetCursor(Cursors.Default);

            MessageBox.Show($"Pomyślnie zsynchronizowano bazę monet.\nZnaleziono {websiteCoinsCount} monet\nDodano {newCoinsCount} nowych monet","Informacja",MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            //Connector.BeginTransaction();

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
            //        Connector.ExecuteNonQuery(query, parameters);
            //    }
            //    catch (MySqlException ex)
            //    {
            //        if (!ex.Message.Contains("UNIQUE"))
            //        {
            //            throw ex;
            //        }
            //    }
            //});

            //Connector.CommitTransaction();

            //DialogResult = DialogResult.OK;
        }

        private void ButtonWipeUserCollection_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Czy na pewno chcesz usunąć całą swoją kolekcję?\n(pozycji: {Database.GetUserUniqueCoins()} | monet: {Database.GetUserTotalCoins()} | wartość: {Database.GetUserTotalValue()} zł)", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Database.WipeUserCollection();
            }
        }

        private void ButtonWipeDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wszystkie dane z bazy?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Database.WipeDatabase();
            }
        }
    }
}
