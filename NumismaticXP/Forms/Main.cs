﻿using NumismaticXP.Logics;
using NumismaticXP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

//TODO: Dodać export do pliku *.PDF (pdfsharp)
//TODO: Dodać moduł wyświetlania błędów
//TODO: Dodać moduł wyświetlania zmian
//TODO: Dodać moduł edycji użytkowników
//TODO: Dodać moduł zmiany hasła
//TODO: Podzielić ustawienia na zakładki
//TODO: Przejść na EntityFramework
//TODO: Zaawansowana synchronizacja

namespace NumismaticXP.Forms
{
    public partial class Main : Form
    {
        #region "Class fields"
        private static SQLiteConnector _connector;
        private static Thread statusRefresher;
        private static string _databaseFile = "database.db";

        private bool justLoggedIn = true;
        private bool columnsChanged = false;
        #endregion

        #region "Static methods"
        internal static SQLiteConnector Connector
        {
            get
            {
                //Check if Connector is not null and do not require connection string rebuilding.
                if (_connector == null)
                {
                    _connector = new SQLiteConnector(ConnectionString);
                }

                //Return ready Connector.
                return _connector;
            }
        }

        //Construct and return connection string.
        internal static string ConnectionString
        {
            get
            {
                string execLocation = Assembly.GetExecutingAssembly().Location;
                string databaseFilePath = $"{Path.GetDirectoryName(execLocation)}\\{_databaseFile}";

                return $"Data Source={databaseFilePath}";
            }
        }

        //Hash entered string using SHA256
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
        #endregion

        #region "Form events"
        public Main()
        {
            InitializeComponent();

            MinimumSize = Size;
            if (Properties.Settings.Default.MainWidth > 0
            && Properties.Settings.Default.MainHeight > 0)
            {
                Size = new Size(Properties.Settings.Default.MainWidth, Properties.Settings.Default.MainHeight);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Prepare controls
            MenuStrip.Enabled = false;
            ToolStrip.Enabled = false;
            LabelStatus.Text = null;
            LabelUser.Text = "Nie zalogowano";
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataGridViewColumnSettings();

            Properties.Settings.Default.MainWidth = Size.Width;
            Properties.Settings.Default.MainHeight = Size.Height;
            Properties.Settings.Default.Save();

            if (statusRefresher != null)
            {
                statusRefresher.Abort();
            }
        }
        #endregion

        #region "MenuBar buttons"
        #region "General category"
        private void ButtonNBP_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nbp.pl/home.aspx?f=/banknoty_i_monety/monety_okolicznosciowe/katalog.html");
        }

        private void ButtonSync_Click(object sender, EventArgs e)
        {
            using (SynchronizationForm synchronizationForm = new SynchronizationForm())
            {
                if (synchronizationForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDataGridView();
                }
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Filter = "Excel Files (*.csv)|*.csv|Text Files (*.txt)|*.txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.OpenFile()))
                    {
                        List<string> line = new List<string>();

                        foreach (DataGridViewColumn column in DataGridViewCoins.Columns)
                        {
                            if (column.Visible)
                            {
                                line.Add(column.HeaderText);
                            }
                        }

                        streamWriter.WriteLine(string.Join("\t", line.ToArray()));

                        foreach (DataGridViewRow record in DataGridViewCoins.Rows)
                        {
                            line = new List<string>();

                            foreach (DataGridViewCell cell in record.Cells)
                            {
                                if (cell.Visible)
                                {
                                    if (cell.Value is DateTime)
                                    {
                                        line.Add(DateTime.Parse(cell.Value.ToString()).Year.ToString());
                                    }
                                    else
                                    {
                                        line.Add(cell.Value.ToString());
                                    }
                                }
                            }

                            streamWriter.WriteLine(string.Join("\t", line.ToArray()));
                        }
                    }
                }
            }
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDataGridView();
                }
            }
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        private void ButtonFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region "Admin category"
        private void ButtonClearDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wszystkie kolekcje użytkowników wraz z bazą monet?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Database.FullClear();
                RefreshDataGridView();
            }  
        }
        #endregion
        #endregion

        #region "ToolsBar buttons"
        private void ButtonShow_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem button = (ToolStripMenuItem)sender;

            RefreshDataGridView(button);

            LabelCoins.Image = button.Image;
            LabelCoins.Text = button.Text;

            Properties.Settings.Default.LastSelectedMode = button.Name;
            Properties.Settings.Default.Save();
        }

        private void ButtonIncrement_Click(object sender, EventArgs e)
        {
            string query;
            Dictionary<string, object> parameters;

            if (Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) == 0)
            {
                query = "INSERT INTO Collection (Id_coin, Amount) VALUES (@coin, @amount);";
                parameters = new Dictionary<string, object>()
                {
                    { "coin", Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["CoinID"].Value) },
                    { "amount", 1 }
                };

                try
                {
                    Connector.ExecuteNonQuery(query, parameters);
                }
                catch (Exception ex) when (ex.Message.Contains("UNIQUE"))
                {
                    query = "UPDATE Collection SET Amount = @amount WHERE Id_coin = @coin AND Id_user = @user;";
                    Connector.ExecuteNonQuery(query, parameters);
                }
            }
            else
            {
                query = "UPDATE Collection SET Amount = Amount + 1 WHERE Id_coin = @coin;";
                parameters = new Dictionary<string, object>()
                {
                    { "coin", Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["CoinID"].Value) }
                };
                Connector.ExecuteNonQuery(query, parameters);
            }

            DataGridViewCoins.CurrentRow.Cells["Amount"].Value = Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) + 1;
        }

        private void ButtonDecrement_Click(object sender, EventArgs e)
        {
            if (Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) > 0)
            {
                string query = "UPDATE Collection SET Amount = Amount - 1 WHERE Id_coin = @coin;";
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "coin", Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["CoinID"].Value) }
                };

                Connector.ExecuteNonQuery(query, parameters);

                DataGridViewCoins.CurrentRow.Cells["Amount"].Value = Convert.ToUInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) - 1;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyDataGridViewFilter();
        }

        private void ButtonClearSearch_Click(object sender, EventArgs e)
        {
            TextBoxSearch.Text = null;
        }
        #endregion

        #region "DataGridView events"
        private void DataGridViewCoins_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Properties.Settings.Default.LastSelectedCoin = Convert.ToUInt32(DataGridViewCoins.Rows[e.RowIndex].Cells["CoinID"].Value);
                Properties.Settings.Default.Save();
            }
        }

        private void DataGridViewCoins_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                uint coinId = Convert.ToUInt32(DataGridViewCoins.Rows[e.RowIndex].Cells["CoinID"].Value);

                using (CoinDetailsForm coinDetailsForm = new CoinDetailsForm(coinId))
                {
                    coinDetailsForm.ShowDialog();
                }
            }
        }

        private void DataGridViewCoins_Sorted(object sender, EventArgs e)
        {
            Properties.Settings.Default.SortByColumn = DataGridViewCoins.SortedColumn.Name;
            Properties.Settings.Default.SortDirection = DataGridViewCoins.SortOrder.ToString();
            Properties.Settings.Default.Save();
            SelectLastSelectedCoinInDataGridView();
            DataGridViewCoins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DataGridViewCoins_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            columnsChanged = true;
        }

        private void DataGridViewCoins_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            columnsChanged = true;
        }

        private void DataGridViewCoins_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Add || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Add)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void DataGridViewCoins_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                ButtonDecrement_Click(null, null);
            }
            else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                ButtonIncrement_Click(null, null);
            }
        }
        #endregion

        #region "Methods"
        private void RefreshDataGridView(ToolStripMenuItem button = null)
        {
            if (!justLoggedIn) SaveDataGridViewColumnSettings();

            DataGridViewCoins.ColumnDisplayIndexChanged -= DataGridViewCoins_ColumnDisplayIndexChanged;
            DataGridViewCoins.ColumnWidthChanged -= DataGridViewCoins_ColumnWidthChanged;

            GetDataSourceForDataGridView(button);
            FormatColumnsInDataGridView();
            SortDataGridViewRows();
            ApplyDataGridViewColumnsSettings();
            ApplyDataGridViewFilter();

            DataGridViewCoins.ColumnDisplayIndexChanged += DataGridViewCoins_ColumnDisplayIndexChanged;
            DataGridViewCoins.ColumnWidthChanged += DataGridViewCoins_ColumnWidthChanged;
        }

        private void SaveDataGridViewColumnSettings()
        {
            if (columnsChanged)
            {
                List<string> columnsSettings = new List<string>();

                foreach (DataGridViewColumn column in DataGridViewCoins.Columns)
                {
                    columnsSettings.Add($"{column.Name}:{column.DisplayIndex}:{column.Width}");
                }

                Properties.Settings.Default.ColumnsSettings = string.Join(";", columnsSettings.ToArray());
                Properties.Settings.Default.Save();

                columnsChanged = false;
            }
        }

        private void ApplyDataGridViewColumnsSettings()
        {
            int lol = Properties.Settings.Default.ColumnsSettings.Length;

            if (Properties.Settings.Default.ColumnsSettings.Length > 0)
            {
                foreach (string column in Properties.Settings.Default.ColumnsSettings.Split(';'))
                {
                    string[] columnInfo = column.Split(':');

                    DataGridViewCoins.Columns[columnInfo[0]].DisplayIndex = int.Parse(columnInfo[1]);
                    DataGridViewCoins.Columns[columnInfo[0]].Width = int.Parse(columnInfo[2]);
                }
            }
        }

        private void SortDataGridViewRows()
        {
            if (Properties.Settings.Default.SortByColumn.Length > 0)
            {
                DataGridViewColumn column = DataGridViewCoins.Columns[Properties.Settings.Default.SortByColumn];

                //Enum.TryParse(Properties.Settings.Default.SortDirection, out ListSortDirection sortDirection);

                DataGridViewCoins.Sort(column, (ListSortDirection)Enum.Parse(typeof(ListSortDirection), Properties.Settings.Default.SortDirection));
            }

            SelectLastSelectedCoinInDataGridView();
        }

        private void SelectLastSelectedCoinInDataGridView()
        {
            //TODO: remake
            if (Properties.Settings.Default.LastSelectedCoin > 0)
            {
                foreach (DataGridViewRow row in DataGridViewCoins.Rows)
                {
                    if (Convert.ToUInt32(row.Cells["CoinID"].Value) == Properties.Settings.Default.LastSelectedCoin)
                    {
                        row.Cells["Name"].Selected = true;
                        break;
                    }
                }
            }
            else
            {
                DataGridViewCoins.Rows[0].Cells["Name"].Selected = true;
            }
        }

        private void GetDataSourceForDataGridView(ToolStripMenuItem button = null)
        {
                 if (button == ButtonShowAllCoins) DataGridViewCoins.DataSource = Database.UserCollection.AllCoins;
            else if (button == ButtonShowOwnedCoins) DataGridViewCoins.DataSource = Database.UserCollection.OwnedCoins;
            else if (button == ButtonShowRedundantCoins) DataGridViewCoins.DataSource = Database.UserCollection.RedundantCoins;
            else if (button == ButtonShowMissingCoins) DataGridViewCoins.DataSource = Database.UserCollection.MissingCoins;
            else if (button == null) RefreshDataGridView((ToolStripMenuItem)ButtonShowCoins.DropDownItems[Properties.Settings.Default.LastSelectedMode]);
        }

        private void FormatColumnsInDataGridView()
        {
            DataGridViewCoins.Columns["CoinID"].Visible = false;
            DataGridViewCoins.Columns["Name"].HeaderText = "Nazwa";
            DataGridViewCoins.Columns["Value"].HeaderText = "Nominał";
            DataGridViewCoins.Columns["Edition"].HeaderText = "Nakład";
            DataGridViewCoins.Columns["Emission"].HeaderText = "Data";
            DataGridViewCoins.Columns["Amount"].HeaderText = "Ilość";

            DataGridViewCoins.Columns["Value"].DefaultCellStyle.Format = "c0";
            DataGridViewCoins.Columns["Edition"].DefaultCellStyle.Format = "n0";

            DataGridViewCoins.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCoins.Columns["Edition"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewCoins.Columns["Emission"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCoins.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewCoins.Columns["Value"].MinimumWidth = 72;
            DataGridViewCoins.Columns["Edition"].MinimumWidth = 68;
            DataGridViewCoins.Columns["Emission"].MinimumWidth = 64;
            DataGridViewCoins.Columns["Amount"].MinimumWidth = 54;

            DataGridViewCoins.Columns["Name"].FillWeight = 96;
            DataGridViewCoins.Columns["Value"].FillWeight = 1;
            DataGridViewCoins.Columns["Edition"].FillWeight = 1;
            DataGridViewCoins.Columns["Emission"].FillWeight = 1;
            DataGridViewCoins.Columns["Amount"].FillWeight = 1;
        }

        private void ApplyDataGridViewFilter()
        {
            ((DataTable)DataGridViewCoins.DataSource).DefaultView.RowFilter = $"Name LIKE '%{TextBoxSearch.Text}%' OR CONVERT(Emission, 'System.String') LIKE '%{TextBoxSearch.Text}%'";
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://216.58.207.238"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}