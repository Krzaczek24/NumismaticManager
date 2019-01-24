﻿using NumismaticManager.Logics;
using PDF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//TODO: Zaawansowana synchronizacja

namespace NumismaticManager.Forms
{
    public partial class Main : Form
    {
        #region "Class variables"
        private bool justLoggedIn = true;
        private bool columnsChanged = false;
        private bool handleEnter = true;
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
            LabelStatus.Text = null;

            Program.CreateDatabaseBackup();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            ButtonShow_Click(ButtonShowCoins.DropDownItems[Properties.Settings.Default.LastSelectedMode] ?? ButtonShowAllCoins, null);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataGridViewColumnSettings();

            Properties.Settings.Default.MainWidth = Size.Width;
            Properties.Settings.Default.MainHeight = Size.Height;
            Properties.Settings.Default.Save();

            if (Program.statusRefresher != null)
            {
                Program.statusRefresher.Abort();
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E && !TextBoxSearch.Focused)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E && !TextBoxSearch.Focused)
            {
                using (ErrorsForm errorsForm = new ErrorsForm())
                {
                    errorsForm.ShowDialog();
                }
            }
        }
        #endregion

        #region "MenuBar buttons"
        private void ButtonNBP_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser(Properties.Settings.Default.NBPSite);
        }

        private void ButtonSupermonety_Click(object sender, EventArgs e)
        {
            Program.OpenBrowser("https://supermonety.pl/");
        }

        private void ButtonSync_Click(object sender, EventArgs e)
        {
            using (SynchronizationForm synchronizationForm = new SynchronizationForm())
            {
                DialogResult dialogResult;

                do
                {
                    dialogResult = synchronizationForm.ShowDialog();

                    RefreshDataGridView();
                }
                while (dialogResult == DialogResult.Retry);
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Filter = "Excel Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|PDF Files (*.pdf)|*.pdf";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(saveFileDialog.FileName);

                    if (extension == ".csv" || extension == ".txt")
                    {
                        try
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
                                            line.Add(cell.Value.ToString());
                                        }
                                    }

                                    streamWriter.WriteLine(string.Join("\t", line.ToArray()));
                                }
                            }

                            System.Diagnostics.Process.Start(saveFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            Database.AddError(ex.Message, "Main.cs", "ButtonExport_Click(object sender, EventArgs e)");
                            Program.ShowError("Wystąpił błąd podczas próby wygenerowania pliku CSV/TXT.");
                        }
                    }
                    else if (extension == ".pdf")
                    {
                        List<string> headers = new List<string>();

                        List<Dictionary<string, object>> coins = new List<Dictionary<string, object>>();
                        
                        foreach (DataGridViewColumn column in DataGridViewCoins.Columns)
                        {
                            if (column.Visible)
                            {
                                headers.Add(column.HeaderText);
                            }
                        }

                        foreach (DataGridViewRow record in DataGridViewCoins.Rows)
                        {
                            coins.Add(new Dictionary<string, object>
                            {
                                { "Name", record.Cells["Name"].Value },
                                { "Value", record.Cells["Value"].Value },
                                { "Edition", record.Cells["Edition"].Value },
                                { "Emission", record.Cells["Emission"].Value },
                                { "Amount", record.Cells["Amount"].Value }
                            });
                        }

                        try
                        {
                            PDFCreator.GenerateDoc(saveFileDialog.FileName, headers, coins);
                            System.Diagnostics.Process.Start(saveFileDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            Database.AddError(ex.Message, "Main.cs", "ButtonExport_Click(object sender, EventArgs e)");
                            Program.ShowError("Wystąpił błąd podczas próby wygenerowania pliku PDF.");
                        }
                    }
                    else throw new ArgumentOutOfRangeException(Path.GetExtension(saveFileDialog.FileName));
                }
            }
        }

        private void ButtonAddCoin_Click(object sender, EventArgs e)
        {
            using (NewCoinForm newCoinForm = new NewCoinForm())
            {
                if (newCoinForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDataGridView();
                }
            }
        }

        private void ButtonSummary_Click(object sender, EventArgs e)
        {
            using (SummaryForm summaryForm = new SummaryForm())
            {
                summaryForm.ShowDialog();
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

        private void ButtonShowDetails_Click(object sender, EventArgs e)
        {
            if (DataGridViewCoins.SelectedRows.Count > 0)
            {
                int coinId = Convert.ToInt32(DataGridViewCoins.SelectedRows[0].Cells["Id"].Value);

                using (CoinDetailsForm coinDetailsForm = new CoinDetailsForm(coinId))
                {
                    coinDetailsForm.ShowDialog();
                }
            }
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyDataGridViewFilter();
        }

        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewCoins.Focus();
            }
        }

        private void ButtonClearSearch_Click(object sender, EventArgs e)
        {
            TextBoxSearch.Text = null;
        }
        #endregion

        #region "DataGridView events"
        private void DataGridViewCoins_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCoins.SelectionChanged += DataGridViewCoins_SelectionChanged;
        }

        private void DataGridViewCoins_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                DataGridViewCoins.SelectionChanged -= DataGridViewCoins_SelectionChanged;
            }
        }

        private void DataGridViewCoins_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int coinId = Convert.ToInt32(DataGridViewCoins.Rows[e.RowIndex].Cells["Id"].Value);
                string name = DataGridViewCoins.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                int amount = Convert.ToInt32(DataGridViewCoins.Rows[e.RowIndex].Cells["Amount"].Value);

                using (CoinAmountForm coinAmountForm = new CoinAmountForm(coinId, name, amount))
                {
                    if (coinAmountForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDataGridView();
                    }
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
            if (e.KeyCode == Keys.Subtract 
            || e.KeyCode == Keys.OemMinus
            || e.KeyCode == Keys.Add
            || e.KeyCode == Keys.Oemplus
            || e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void DataGridViewCoins_KeyUp(object sender, KeyEventArgs e)
        {
            if (DataGridViewCoins.SelectedRows.Count > 0)
            {
                if ((e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus) && Convert.ToInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) > 0)
                {
                    Database.ChangeAmount(Convert.ToInt32(DataGridViewCoins.CurrentRow.Cells["Id"].Value), false);

                    DataGridViewCoins.CurrentRow.Cells["Amount"].Value = Convert.ToInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) - 1;
                }
                else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
                {
                    Database.ChangeAmount(Convert.ToInt32(DataGridViewCoins.CurrentRow.Cells["Id"].Value), true);

                    DataGridViewCoins.CurrentRow.Cells["Amount"].Value = Convert.ToInt32(DataGridViewCoins.CurrentRow.Cells["Amount"].Value) + 1;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (handleEnter)
                    {
                        DataGridViewCoins_CellDoubleClick(sender, new DataGridViewCellEventArgs(0, DataGridViewCoins.CurrentRow.Index));
                    }

                    handleEnter = !handleEnter;
                }
            }
        }

        private void DataGridViewCoins_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewCoins.CurrentRow != null)
            {
                Properties.Settings.Default.LastSelectedCoin = Convert.ToInt32(DataGridViewCoins.CurrentRow.Cells["Id"].Value);
                int i = Properties.Settings.Default.LastSelectedCoin;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        #region "Methods"
        private void RefreshDataGridView(ToolStripMenuItem button = null)
        {
            if (!justLoggedIn) SaveDataGridViewColumnSettings();
            else justLoggedIn = false;

            DataGridViewCoins.ColumnDisplayIndexChanged -= DataGridViewCoins_ColumnDisplayIndexChanged;
            DataGridViewCoins.ColumnWidthChanged -= DataGridViewCoins_ColumnWidthChanged;
            DataGridViewCoins.SelectionChanged -= DataGridViewCoins_SelectionChanged;

            GetDataSourceForDataGridView(button);
            FormatColumnsInDataGridView();
            SortDataGridViewRows();
            ApplyDataGridViewColumnsSettings();
            ApplyDataGridViewFilter();

            DataGridViewCoins.ColumnDisplayIndexChanged += DataGridViewCoins_ColumnDisplayIndexChanged;
            DataGridViewCoins.ColumnWidthChanged += DataGridViewCoins_ColumnWidthChanged;
            DataGridViewCoins.SelectionChanged += DataGridViewCoins_SelectionChanged;
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

                DataGridViewCoins.Sort(column, (ListSortDirection)Enum.Parse(typeof(ListSortDirection), Properties.Settings.Default.SortDirection));
            }

            SelectLastSelectedCoinInDataGridView();
        }

        private void SelectLastSelectedCoinInDataGridView()
        {
            if (Properties.Settings.Default.LastSelectedCoin > 0)
            {
                foreach (DataGridViewRow row in DataGridViewCoins.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Id"].Value) == Properties.Settings.Default.LastSelectedCoin)
                    {
                        row.Cells["Name"].Selected = true;
                        break;
                    }
                }
            }
            else if (DataGridViewCoins.Rows.Count > 0)
            {
                DataGridViewCoins.Rows[0].Cells["Name"].Selected = true;
            }
        }

        private void GetDataSourceForDataGridView(ToolStripMenuItem button = null)
        {
                 if (button == ButtonShowAllCoins) DataGridViewCoins.DataSource = Database.DownloadCoins(Database.CollectionType.All, Properties.Settings.Default.CoinFilter);
            else if (button == ButtonShowOwnedCoins) DataGridViewCoins.DataSource = Database.DownloadCoins(Database.CollectionType.Owned, Properties.Settings.Default.CoinFilter);
            else if (button == ButtonShowRedundantCoins) DataGridViewCoins.DataSource = Database.DownloadCoins(Database.CollectionType.Redundant, Properties.Settings.Default.CoinFilter);
            else if (button == ButtonShowMissingCoins) DataGridViewCoins.DataSource = Database.DownloadCoins(Database.CollectionType.Missing, Properties.Settings.Default.CoinFilter);
            else if (button == null) RefreshDataGridView((ToolStripMenuItem)ButtonShowCoins.DropDownItems[Properties.Settings.Default.LastSelectedMode]);
        }

        private void FormatColumnsInDataGridView()
        {
            DataGridViewCoins.Columns["Id"].Visible = false;
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
        #endregion
    }
}