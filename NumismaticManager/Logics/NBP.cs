using HtmlAgilityPack;
using NumismaticManager.Forms;
using NumismaticManager.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace NumismaticManager.Logics
{
    static class NBP
    {
        public static List<Coin> DownloadAllCoins()
        {
            //Przygotowanie wątków
            Main.ShowInformation("STEP-0001");
            List<Thread> threads = new List<Thread>();

            //Przygotowanie listy dla wszystkich znalezionych monet
            Main.ShowInformation("STEP-0002");
            ConcurrentBag<Coin> foundCoins = new ConcurrentBag<Coin>();

            //Pobranie treści strony zawierającej spis roczników
            Main.ShowInformation("STEP-0003");
            HtmlAgilityPack.HtmlDocument catalogWebsite = new HtmlWeb().Load(Properties.Settings.Default.NBPSite);

            //Wybranie elementów [div] z atrybutem [class] o wartości [aslices] (tabela z rocznikami)
            Main.ShowInformation("STEP-0004");
            HtmlNodeCollection yearsTable = catalogWebsite.DocumentNode.SelectNodes("//div[@class='aslices']//a");

            //Sprawdzenie czy znaleziono katalog z rocznikami
            if (yearsTable == null) throw new NodeNotFoundException();

            Main.ShowInformation("STEP-B");
            //Utworzenie dla każdego rocznika nowego wątku i dodanie go do listy wątków
            foreach (HtmlNode yearValue in yearsTable)
            {
                threads.Add(new Thread(() => DownloadCoinsFromYear(yearValue.InnerHtml, foundCoins)));
            }

            //Start wszystkich wątków
            Main.ShowInformation("STEP-A");
            threads.ForEach(thread => thread.Start());

            //Oczekiwanie na zakończenie pracy wszystkich wątków
            Main.ShowInformation("STEP-0");
            Main.SetStatus($"Pobrano 0 z {yearsTable.Count} roczników (0%)");
            Main.ShowInformation("STEP-1");
            while (threads.Exists(thread => thread.IsAlive))
            {
                Main.ShowInformation("STEP-2");
                int extinctThreads = threads.FindAll(thread => !thread.IsAlive).Count;
                Main.ShowInformation("STEP-3");
                Main.SetStatus($"Pobrano {extinctThreads} z {threads.Count} roczników ({extinctThreads * 100 / threads.Count}%)");
                Main.ShowInformation("STEP-4");
            }

            //Zwrócenie listy pobranych monet
            return new List<Coin>(foundCoins.ToArray());
        }

        private static void DownloadCoinsFromYear(string year, ConcurrentBag<Coin> foundCoins)
        {
            //Pobranie strony z monetami z podanego roku
            Main.ShowInformation("STEP-X1-" + year);
            int lastSlashPosition = Properties.Settings.Default.NBPSite.LastIndexOf('/');
            HtmlAgilityPack.HtmlDocument coinsWebsite = new HtmlWeb().Load($"{Properties.Settings.Default.NBPSite.Remove(lastSlashPosition)}/{year}.html");

            //Wybranie wszystkich elementów [table] z atrybutem [class] o wartości [moneta] (występują w poprzednich latach)
            Main.ShowInformation("STEP-X2-" + year);
            HtmlNodeCollection coinTables = coinsWebsite.DocumentNode.SelectNodes("//table[@class='moneta']");

            //Jeżeli strona nie pasuje do schematu ze starszych lat (2011 i w dół) to zmień sposób wyszukiwania
            if (coinTables == null)
            {
                //Wybranie wszystkich elementów [table] z atrybutem [class] o wartości [monety]
                //Nadrzędne tabele to grupy monet - podrzędne to poszczególne monety
                Main.ShowInformation("STEP-X3-" + year);
                coinTables = coinsWebsite.DocumentNode.SelectNodes("//table[@class='monety']//table");
            }

            //Przejście po wszystkich elementach odpowiadających indywidualnym monetom
            Main.ShowInformation("STEP-X4-" + year);
            foreach (HtmlNode coinTable in coinTables)
            {
                //TODO: TUTAJ SZUKAĆ BŁĘDU  - KTÓRAŚ MONETA WINNA
                //przygotowanie słownika dla danych o znalezionej monecie
                NBPCoin foundCoin = new NBPCoin();

                //Wybranie wszystkich elementów [tr] z wybranej tabeli
                Main.ShowInformation("STEP-X5-" + year);
                HtmlNodeCollection rows = coinTable.SelectNodes(".//tr[not(@class)]");

                //Wybranie pierwszej linii [tr] z dwoma elementami [td] (nazwa | nominał)
                Main.ShowInformation("STEP-X6-" + year);
                HtmlNodeCollection coinMainDetailsCells = rows[0].SelectNodes(".//td");

                //Wybranie ostatnich linii [tr] od końca z typami parametrów i ich wartościami
                Main.ShowInformation("STEP-X7-" + year);
                int rowsCount = rows.Count - (rows[rows.Count - 1].SelectSingleNode(".//td").InnerText.Contains("Uwagi") ? 1 : 0);
                Main.ShowInformation("STEP-X8-" + year);
                HtmlNodeCollection keys = rows[rowsCount - 2].SelectNodes(".//td");
                Main.ShowInformation("STEP-X9-" + year);
                HtmlNodeCollection values = rows[rowsCount - 1].SelectNodes(".//td");

                //Utworzenie słownika do parsowania
                Main.ShowInformation("STEP-X10-" + year);
                Dictionary<string, string> preparsedCoin = new Dictionary<string, string>();

                //Przygotowanie pozostałych parametrów do parsowania
                Main.ShowInformation("STEP-X11-" + year);
                for (int i = 0; i < keys.Count; i++) preparsedCoin.Add(keys[i].InnerText.Trim(' '), values[i].InnerText.Trim(' '));

                //Wpisanie danych ze strony do obiektu monety
                Main.ShowInformation("STEP-X12-" + year);
                foundCoin.Name = coinMainDetailsCells[0].InnerText;
                foundCoin.Value = coinMainDetailsCells[1].InnerText;
                if (preparsedCoin.ContainsKey("Wymiary"))       foundCoin.Diameter = preparsedCoin["Wymiary"];
                else if (preparsedCoin.ContainsKey("Rozmiar"))  foundCoin.Diameter = preparsedCoin["Rozmiar"];
                else                                            foundCoin.Diameter = preparsedCoin["Średnica"];
                if (preparsedCoin.ContainsKey("Stop"))  foundCoin.Fineness = preparsedCoin["Stop"];
                else                                    foundCoin.Fineness = preparsedCoin["Próba"];
                foundCoin.Weight = preparsedCoin["Masa"];
                foundCoin.Edition = preparsedCoin["Nakład"];
                foundCoin.Emission = preparsedCoin["Data emisji"];
                foundCoin.Stamp = preparsedCoin["Stempel"];

                //Dodanie przeparsowanej monety do kolekcji pobieranych monet
                Main.ShowInformation("STEP-X13-" + year);
                foundCoins.Add(foundCoin.Normalised);
            }
            Main.ShowInformation("STEP-X14-" + year);
        }

        static List<Coin> DownloadCoinsFromYear(string year)
        {
            //Przygotowanie listy dla wszystkich znalezionych monet
            List<Coin> foundCoins = new List<Coin>();

            //Pobranie strony z monetami z podanego roku
            HtmlAgilityPack.HtmlDocument coinsWebsite = new HtmlWeb().Load($"https://www.nbp.pl/home.aspx?f=/banknoty_i_monety/monety_okolicznosciowe/{year}.html");

            //Wybranie wszystkich elementów [table] z atrybutem [class] o wartości [moneta] (występują w poprzednich latach)
            HtmlNodeCollection coinTables = coinsWebsite.DocumentNode.SelectNodes("//table[@class='moneta']");

            //Jeżeli strona nie pasuje do schematu ze starszych lat (2011 i w dół) to zmień sposób wyszukiwania
            if (coinTables == null)
            {
                //Wybranie wszystkich elementów [table] z atrybutem [class] o wartości [monety]
                //Nadrzędne tabele to grupy monet - podrzędne to poszczególne monety
                coinTables = coinsWebsite.DocumentNode.SelectNodes("//table[@class='monety']//table");
            }

            //Przejście po wszystkich elementach odpowiadających indywidualnym monetom
            foreach (HtmlNode coinTable in coinTables)
            {
                //przygotowanie słownika dla danych o znalezionej monecie
                NBPCoin foundCoin = new NBPCoin();

                //Wybranie wszystkich elementów [tr] z wybranej tabeli
                HtmlNodeCollection rows = coinTable.SelectNodes(".//tr[not(@class)]");

                //Wybranie pierwszej linii [tr] z dwoma elementami [td] (nazwa | nominał)
                HtmlNodeCollection coinMainDetailsCells = rows[0].SelectNodes(".//td");

                //Wybranie ostatnich linii [tr] od końca z typami parametrów i ich wartościami
                int rowsCount = rows.Count - (rows[rows.Count - 1].SelectSingleNode(".//td").InnerText.Contains("Uwagi") ? 1 : 0);
                HtmlNodeCollection keys = rows[rowsCount - 2].SelectNodes(".//td");
                HtmlNodeCollection values = rows[rowsCount - 1].SelectNodes(".//td");

                //Utworzenie słownika do parsowania
                Dictionary<string, string> preparsedCoin = new Dictionary<string, string>();

                //Przygotowanie pozostałych parametrów do parsowania
                for (int i = 0; i < keys.Count; i++) preparsedCoin.Add(keys[i].InnerText.Trim(' '), values[i].InnerText.Trim(' '));

                //Wpisanie danych ze strony do obiektu monety
                foundCoin.Name = coinMainDetailsCells[0].InnerText;
                foundCoin.Value = coinMainDetailsCells[1].InnerText;
                if (preparsedCoin.ContainsKey("Wymiary")) foundCoin.Diameter = preparsedCoin["Wymiary"];
                else if (preparsedCoin.ContainsKey("Rozmiar")) foundCoin.Diameter = preparsedCoin["Rozmiar"];
                else foundCoin.Diameter = preparsedCoin["Średnica"];
                if (preparsedCoin.ContainsKey("Stop")) foundCoin.Fineness = preparsedCoin["Stop"];
                else foundCoin.Fineness = preparsedCoin["Próba"];
                foundCoin.Weight = preparsedCoin["Masa"];
                foundCoin.Edition = preparsedCoin["Nakład"];
                foundCoin.Emission = preparsedCoin["Data emisji"];
                foundCoin.Stamp = preparsedCoin["Stempel"];

                //Dodanie przeparsowanej monety do kolekcji pobieranych monet
                foundCoins.Add(foundCoin.Normalised);
            }

            return foundCoins;
        }
    }
}
