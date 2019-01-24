using NumismaticManager.Forms;
using SQLite;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace NumismaticManager.Logics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        #region "Class variables"
        public static SQLiteConnector _connector;
        public static Thread statusRefresher;
        #endregion

        #region "Static methods"
        internal static SQLiteConnector Connector
        {
            get
            {
                if (_connector == null)
                {
                    try
                    {
                        _connector = new SQLiteConnector(DatabaseFilePath);

                        if (!File.Exists(DatabaseFilePath)) Database.Create();
                    }
                    catch (InvalidOperationException)
                    {
                        ShowError($"Podczas próby utworzenia pliku z bazą danych wystąpił błąd!\n\nPróba utworzenia pliku pod adresem:\n{DatabaseFilePath}");
                        Environment.Exit(0);
                    }
                }

                return _connector;
            }
        }

        internal static string DatabaseFilePath
        {
            get => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{Properties.Settings.Default.DatabaseFile}";
        }

        internal static void CreateDatabaseBackup()
        {
            if (Properties.Settings.Default.Backup && File.Exists(DatabaseFilePath))
            {
                //TODO: sprawdzenie czy warto robic kopie
                int lastSlashPosition = DatabaseFilePath.LastIndexOf("\\");
                string destinationPath = $"{DatabaseFilePath.Remove(lastSlashPosition)}\\backup\\{DateTime.Now.ToString().Replace(":", ".")}";

                if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);

                File.Copy(DatabaseFilePath, $"{destinationPath}\\{Properties.Settings.Default.DatabaseFile}");
            }
        }

        internal static string HashSHA256(string input)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(input);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string output = string.Empty;
            foreach (byte x in hash) output += string.Format("{0:x2}", x);
            return output;
        }

        internal static void SetStatus(string info)
        {
            Main main = (Main)Application.OpenForms["Main"];
            StatusStrip statusStrip = (StatusStrip)main.Controls["StatusStrip"];
            ToolStripStatusLabel statusLabel = (ToolStripStatusLabel)statusStrip.Items["LabelStatus"];
            statusLabel.Text = info;
            statusStrip.Refresh();

            if (statusRefresher != null) if (statusRefresher.IsAlive) statusRefresher.Abort();
            statusRefresher = new Thread(() =>
            {
                Thread.Sleep(5000);
                ClearStatus();
            });
            statusRefresher.Start();
        }

        internal static void ClearStatus()
        {
            Main main = (Main)Application.OpenForms["Main"];
            StatusStrip statusStrip = (StatusStrip)main.Controls["StatusStrip"];
            ToolStripStatusLabel statusLabel = (ToolStripStatusLabel)statusStrip.Items["LabelStatus"];
            statusLabel.Text = null;
        }

        internal static void SetSummary(string info)
        {
            Main main = (Main)Application.OpenForms["Main"];
            StatusStrip statusStrip = (StatusStrip)main.Controls["StatusStrip"];
            ToolStripStatusLabel summaryLabel = (ToolStripStatusLabel)statusStrip.Items["LabelSummary"];
            summaryLabel.Text = info;
        }

        internal static void SetCursor(Cursor cursor)
        {
            ((Main)Application.OpenForms["Main"]).Cursor = cursor;
        }

        internal static void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static DialogResult ShowWarning(string message)
        {
            return MessageBox.Show(message, "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        internal static void ShowInformation(string message)
        {
            MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static void OpenBrowser(string webAddress)
        {
            try
            {
                System.Diagnostics.Process.Start(webAddress);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    ShowError($"Podczas próby uruchomienia przeglądarki wystąpił błąd.\nProszę ustawić domyślną przeglądarkę.");
                }
                else
                {
                    ShowError($"Podczas próby uruchomienia przeglądarki wystąpił błąd.\n{ex.Message}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Podczas próby uruchomienia przeglądarki wystąpił błąd.\n{ex.Message}");
            }
        }
        #endregion
    }
}
