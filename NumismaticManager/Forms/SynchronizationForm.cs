using NumismaticManager.Logics;
using NumismaticManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NumismaticManager.Forms
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
                    Main.ShowError($"Wystąpił błąd podczas nawiązywania połączenia ze stroną:\n{Properties.Settings.Default.NBPSite}.");
                    Main.SetCursor(Cursors.Default);
                    return;
                }
                catch (HtmlAgilityPack.NodeNotFoundException)
                {
                    Main.ShowError("Pomimo pomyślnego nawiązania połączenia, nie odnaleziono katalogu z rocznikami monet.");
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
                    Main.Connector.BeginTransaction();

                    nbpCoins.ForEach(coin => Database.Insert(coin));

                    Main.Connector.CommitTransaction();
                }
                catch
                {
                    Main.Connector.RollbackTransaction();
                    Main.ShowError($"Wystąpił błąd podczas zapisywania monet do bazy.\n\nWszelkie zmiany zostały wycofane. Jeżeli nadal chcesz przeprowadzić synchronizację, skorzystaj z ręcznej synchronizacji.");
                    Main.SetCursor(Cursors.Default);
                    return;
                }                
            }

            Main.SetStatus($"Pomyślnie zsynchronizowano.");
            Main.SetCursor(Cursors.Default);
            Main.ShowInformation($"Pomyślnie zsynchronizowano bazę monet.\nZnaleziono {websiteCoinsCount} monet\nDodano {newCoinsCount} nowych monet");

            DialogResult = DialogResult.OK;
        }

        private void ButtonAdvancedSynchronization_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonWipeUserCollection_Click(object sender, EventArgs e)
        {
            if (Main.ShowWarning($"Czy na pewno chcesz usunąć całą swoją kolekcję?\n(pozycji: {Database.GetUserUniqueCoins()} | monet: {Database.GetUserTotalCoins()} | wartość: {Database.GetUserTotalValue()} zł)") == DialogResult.Yes)
            {
                Database.WipeUserCollection();

                DialogResult = DialogResult.Retry;
            }
        }

        private void ButtonWipeDatabase_Click(object sender, EventArgs e)
        {
            if (Main.ShowWarning("Czy na pewno chcesz usunąć wszystkie dane z bazy?") == DialogResult.Yes)
            {
                Database.WipeDatabase();

                DialogResult = DialogResult.Retry;
            }
        }
    }
}
