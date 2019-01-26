using NumismaticManager.Forms;
using NumismaticManager.Models.Changes;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        private static SQLiteConnector connector;
        private static Thread statusRefresher;
        private static Stack<IUndoable> changes = new Stack<IUndoable>();
        #endregion

        #region "Static methods"
        internal static SQLiteConnector Connector
        {
            get
            {
                if (connector == null)
                {
                    try
                    {
                        connector = new SQLiteConnector(DatabaseFilePath);

                        if (!File.Exists(DatabaseFilePath))
                        {
                            Database.Create();
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        ShowError($"Podczas próby utworzenia pliku z bazą danych wystąpił błąd!\n\nPróba utworzenia pliku pod adresem:\n{DatabaseFilePath}\nzakończona niepowodzeniem.\nAplikacja zostanie zamknięta.");
                        Environment.Exit(0);
                    }
                }

                return connector;
            }
        }

        internal static void AddNewChange(IUndoable change)
        {
            if (changes.Count == 0 || change is AddedNewCoin || changes.Peek() is AddedNewCoin || ((ChangeBase)change).CoinId != ((ChangeBase)changes.Peek()).CoinId)
            {
                changes.Push(change);
            }
            else //here I know that there is at least one change AND previous one is not an AddedNewCoin AND new one is an ChangedCoinAmount change AND they have got the same CoinId
            {
                ChangedCoinAmount changedCoinAmount = (ChangedCoinAmount)change;
                ChangedCoinAmount previousChangedCoinAmount = (ChangedCoinAmount)changes.Peek();

                if (changedCoinAmount.TargetAmount == previousChangedCoinAmount.PreviousAmount)
                {
                    changes.Pop();
                }
                else
                {
                    previousChangedCoinAmount.TargetAmount = changedCoinAmount.TargetAmount;
                }
            }
        }

        internal static bool UndoLastChange()
        {
            if (changes.Count > 0)
            {
                changes.Pop().Undo();
                return true;
            }
            else
            {
                ShowInformation("Brak zmian do cofnięcia.");
                return false;
            }
        }

        internal static string ProgramDirectoryPath
        {
            get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        internal static string DatabaseFilePath
        {
            get => $"{ProgramDirectoryPath}\\{Properties.Settings.Default.DatabaseFile}";
        }

        internal static void CreateDatabaseBackup()
        {
            if (Properties.Settings.Default.Backup && File.Exists(DatabaseFilePath))
            {
                int lastSlashPosition = DatabaseFilePath.LastIndexOf("\\");
                string backupFolderPath = $"{ProgramDirectoryPath}\\backup";
                string destinationPath = $"{backupFolderPath}\\{DateTime.Now.ToString().Replace(":", ".")}";

                string newestBackupFile = FindNewestBackup(backupFolderPath);

                if (newestBackupFile.Length > 0 && !CheckIfSameFiles(DatabaseFilePath, newestBackupFile))
                {
                    if (!Directory.Exists(destinationPath))
                    {
                        Directory.CreateDirectory(destinationPath);
                    }

                    File.Copy(DatabaseFilePath, $"{destinationPath}\\{Properties.Settings.Default.DatabaseFile}");
                }
            }
        }

        internal static string FindNewestBackup(string backupFolderPath)
        {
            IEnumerable<string> backupFiles = Directory.EnumerateFiles(backupFolderPath, Properties.Settings.Default.DatabaseFile, SearchOption.AllDirectories);

            string newestBackupPath = "";
            DateTime newestBackup = DateTime.MinValue;

            foreach (string filePath in backupFiles)
            {
                DateTime temp;
                if ((temp = File.GetCreationTime(filePath)) > newestBackup)
                {
                    newestBackup = temp;
                    newestBackupPath = filePath;
                }
            }

            return newestBackupPath;
        }

        internal static bool CheckIfSameFiles(string firstFilePath, string secondFilePath)
        {
            const int BYTEST_TO_READ = sizeof(int);

            FileInfo firstFile = new FileInfo(firstFilePath);
            FileInfo secondFile = new FileInfo(secondFilePath);

            if (firstFile.Length != secondFile.Length)
            {
                return false;
            }

            using (FileStream firstFileStream = firstFile.OpenRead())
            {
                using (FileStream secondFileStream = secondFile.OpenRead())
                {
                    byte[] firstFileBytes = new byte[BYTEST_TO_READ];
                    byte[] secondFileBytes = new byte[BYTEST_TO_READ];

                    int i = 0;
                    while (i++ < (int)Math.Ceiling((double)firstFile.Length / BYTEST_TO_READ))
                    {
                        firstFileStream.Read(firstFileBytes, 0, BYTEST_TO_READ);
                        secondFileStream.Read(secondFileBytes, 0, BYTEST_TO_READ);

                        if (BitConverter.ToInt32(firstFileBytes, 0) != BitConverter.ToInt32(secondFileBytes, 0))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
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

        internal static void TurnOffRefresher()
        {
            if (statusRefresher != null)
            {
                statusRefresher.Abort();
            }
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
