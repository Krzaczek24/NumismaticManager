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
            List<Thread> threads = new List<Thread>();

            //Przygotowanie listy dla wszystkich znalezionych monet
            ConcurrentBag<Coin> foundCoins = new ConcurrentBag<Coin>();

            //Pobranie treści strony zawierającej spis roczników
            HtmlAgilityPack.HtmlDocument catalogWebsite = new HtmlWeb().Load(Properties.Settings.Default.NBPSite);

            //Wybranie elementów [div] z atrybutem [class] o wartości [aslices] (tabela z rocznikami)
            HtmlNodeCollection yearsTable = catalogWebsite.DocumentNode.SelectNodes("//div[@class='aslices']//a");

            //Sprawdzenie czy znaleziono katalog z rocznikami
            if (yearsTable == null) throw new NodeNotFoundException();

            //Utworzenie dla każdego rocznika nowego wątku i dodanie go do listy wątków
            foreach (HtmlNode yearValue in yearsTable)
            {
                threads.Add(new Thread(() => DownloadCoinsFromYear(yearValue.InnerHtml, foundCoins)));
            }

            //Start wszystkich wątków
            threads.ForEach(thread => thread.Start());

            //Oczekiwanie na zakończenie pracy wszystkich wątków
            Main.SetStatus($"Pobrano 0 z {yearsTable.Count} roczników (0%)");

            while (threads.Exists(thread => thread.IsAlive))
            {
                int extinctThreads = threads.FindAll(thread => !thread.IsAlive).Count;

                Main.SetStatus($"Pobrano {extinctThreads} z {threads.Count} roczników ({extinctThreads * 100 / threads.Count}%)");
            }

            //Zwrócenie listy pobranych monet
            return new List<Coin>(foundCoins.ToArray());
        }

        private static void DownloadCoinsFromYear(string year, ConcurrentBag<Coin> foundCoins)
        {
            //Pobranie strony z monetami z podanego roku
            int lastSlashPosition = Properties.Settings.Default.NBPSite.LastIndexOf('/');
            HtmlAgilityPack.HtmlDocument coinsWebsite = new HtmlWeb().Load($"{Properties.Settings.Default.NBPSite.Remove(lastSlashPosition)}/{year}.html");

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
                foundCoins.Add(foundCoin.Normalised);
            }
        }
    }
}
