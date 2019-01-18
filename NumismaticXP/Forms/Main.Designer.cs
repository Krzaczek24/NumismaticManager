namespace NumismaticXP.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.ButtonGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonNBP = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonSynchronize = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonAdminTools = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonClearDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonRemoveUser = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelCoins = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.ButtonShowCoins = new System.Windows.Forms.ToolStripDropDownButton();
            this.ButtonShowAllCoins = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonShowOwnedCoins = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonShowRedundantCoins = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonShowMissingCoins = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonIncrement = new System.Windows.Forms.ToolStripButton();
            this.ButtonDecrement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LabelSearch = new System.Windows.Forms.ToolStripLabel();
            this.TextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonClearSearch = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.DataGridViewCoins = new System.Windows.Forms.DataGridView();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCoins)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonGeneral,
            this.ButtonAdminTools});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(609, 25);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip";
            // 
            // ButtonGeneral
            // 
            this.ButtonGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNBP,
            this.ButtonSynchronize,
            this.ButtonExport,
            this.toolStripSeparator4,
            this.ButtonSettings,
            this.ButtonAbout,
            this.toolStripSeparator3,
            this.ButtonFinish});
            this.ButtonGeneral.Name = "ButtonGeneral";
            this.ButtonGeneral.Size = new System.Drawing.Size(63, 21);
            this.ButtonGeneral.Text = "&Ogólne";
            // 
            // ButtonNBP
            // 
            this.ButtonNBP.Image = global::NumismaticXP.Properties.Resources.Web_Browser;
            this.ButtonNBP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonNBP.Name = "ButtonNBP";
            this.ButtonNBP.Size = new System.Drawing.Size(168, 38);
            this.ButtonNBP.Text = "Strona NBP";
            this.ButtonNBP.Click += new System.EventHandler(this.ButtonNBP_Click);
            // 
            // ButtonSynchronize
            // 
            this.ButtonSynchronize.Image = global::NumismaticXP.Properties.Resources.Transfer_Document;
            this.ButtonSynchronize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonSynchronize.Name = "ButtonSynchronize";
            this.ButtonSynchronize.Size = new System.Drawing.Size(168, 38);
            this.ButtonSynchronize.Text = "&Synchronizuj";
            this.ButtonSynchronize.Click += new System.EventHandler(this.ButtonSync_Click);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Image = global::NumismaticXP.Properties.Resources.Import_Document;
            this.ButtonExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(168, 38);
            this.ButtonExport.Text = "&Eksportuj";
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Image = global::NumismaticXP.Properties.Resources.Gear_Alt;
            this.ButtonSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Size = new System.Drawing.Size(168, 38);
            this.ButtonSettings.Text = "&Ustawienia";
            this.ButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // ButtonAbout
            // 
            this.ButtonAbout.Image = global::NumismaticXP.Properties.Resources.Get_Info_Blue_Button;
            this.ButtonAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonAbout.Name = "ButtonAbout";
            this.ButtonAbout.Size = new System.Drawing.Size(168, 38);
            this.ButtonAbout.Text = "&O programie";
            this.ButtonAbout.Click += new System.EventHandler(this.ButtonAbout_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // ButtonFinish
            // 
            this.ButtonFinish.Image = global::NumismaticXP.Properties.Resources.Mr_Bomb;
            this.ButtonFinish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonFinish.Name = "ButtonFinish";
            this.ButtonFinish.Size = new System.Drawing.Size(168, 38);
            this.ButtonFinish.Text = "&Zakończ";
            this.ButtonFinish.Click += new System.EventHandler(this.ButtonFinish_Click);
            // 
            // ButtonAdminTools
            // 
            this.ButtonAdminTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonClearDatabase});
            this.ButtonAdminTools.Name = "ButtonAdminTools";
            this.ButtonAdminTools.Size = new System.Drawing.Size(168, 21);
            this.ButtonAdminTools.Text = "&Narzędzia administratora";
            // 
            // ButtonClearDatabase
            // 
            this.ButtonClearDatabase.Image = global::NumismaticXP.Properties.Resources.Mr_Bomb;
            this.ButtonClearDatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonClearDatabase.Name = "ButtonClearDatabase";
            this.ButtonClearDatabase.Size = new System.Drawing.Size(172, 38);
            this.ButtonClearDatabase.Text = "&Wyczyść bazę";
            this.ButtonClearDatabase.Click += new System.EventHandler(this.ButtonClearDatabase_Click);
            // 
            // ButtonAddUser
            // 
            this.ButtonAddUser.Name = "ButtonAddUser";
            this.ButtonAddUser.Size = new System.Drawing.Size(32, 19);
            // 
            // ButtonEditUser
            // 
            this.ButtonEditUser.Name = "ButtonEditUser";
            this.ButtonEditUser.Size = new System.Drawing.Size(32, 19);
            // 
            // ButtonRemoveUser
            // 
            this.ButtonRemoveUser.Name = "ButtonRemoveUser";
            this.ButtonRemoveUser.Size = new System.Drawing.Size(32, 19);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatus,
            this.LabelCoins});
            this.StatusStrip.Location = new System.Drawing.Point(0, 455);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(609, 41);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(502, 36);
            this.LabelStatus.Spring = true;
            this.LabelStatus.Text = "Status";
            // 
            // LabelCoins
            // 
            this.LabelCoins.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LabelCoins.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LabelCoins.Image = global::NumismaticXP.Properties.Resources.Grey_Ball;
            this.LabelCoins.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.LabelCoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LabelCoins.Name = "LabelCoins";
            this.LabelCoins.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelCoins.Size = new System.Drawing.Size(92, 36);
            this.LabelCoins.Text = "Monety";
            // 
            // ToolStrip
            // 
            this.ToolStrip.CanOverflow = false;
            this.ToolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonShowCoins,
            this.toolStripSeparator1,
            this.ButtonIncrement,
            this.ButtonDecrement,
            this.toolStripSeparator2,
            this.LabelSearch,
            this.TextBoxSearch,
            this.ButtonClearSearch});
            this.ToolStrip.Location = new System.Drawing.Point(0, 25);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.ToolStrip.Size = new System.Drawing.Size(609, 39);
            this.ToolStrip.TabIndex = 2;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // ButtonShowCoins
            // 
            this.ButtonShowCoins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonShowAllCoins,
            this.ButtonShowOwnedCoins,
            this.ButtonShowRedundantCoins,
            this.ButtonShowMissingCoins});
            this.ButtonShowCoins.Image = global::NumismaticXP.Properties.Resources.Menu_Item;
            this.ButtonShowCoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonShowCoins.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonShowCoins.Name = "ButtonShowCoins";
            this.ButtonShowCoins.Size = new System.Drawing.Size(134, 36);
            this.ButtonShowCoins.Text = "Pokaż monety";
            // 
            // ButtonShowAllCoins
            // 
            this.ButtonShowAllCoins.Image = global::NumismaticXP.Properties.Resources.Blue_Ball;
            this.ButtonShowAllCoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonShowAllCoins.Name = "ButtonShowAllCoins";
            this.ButtonShowAllCoins.Size = new System.Drawing.Size(173, 38);
            this.ButtonShowAllCoins.Text = "Wszystkie";
            this.ButtonShowAllCoins.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // ButtonShowOwnedCoins
            // 
            this.ButtonShowOwnedCoins.Image = global::NumismaticXP.Properties.Resources.Green_Ball;
            this.ButtonShowOwnedCoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonShowOwnedCoins.Name = "ButtonShowOwnedCoins";
            this.ButtonShowOwnedCoins.Size = new System.Drawing.Size(173, 38);
            this.ButtonShowOwnedCoins.Text = "Posiadane";
            this.ButtonShowOwnedCoins.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // ButtonShowRedundantCoins
            // 
            this.ButtonShowRedundantCoins.Image = global::NumismaticXP.Properties.Resources.Yellow_Ball;
            this.ButtonShowRedundantCoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonShowRedundantCoins.Name = "ButtonShowRedundantCoins";
            this.ButtonShowRedundantCoins.Size = new System.Drawing.Size(173, 38);
            this.ButtonShowRedundantCoins.Text = "Nadmiarowe";
            this.ButtonShowRedundantCoins.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // ButtonShowMissingCoins
            // 
            this.ButtonShowMissingCoins.Image = global::NumismaticXP.Properties.Resources.Red_Ball;
            this.ButtonShowMissingCoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonShowMissingCoins.Name = "ButtonShowMissingCoins";
            this.ButtonShowMissingCoins.Size = new System.Drawing.Size(173, 38);
            this.ButtonShowMissingCoins.Text = "Nieposiadane";
            this.ButtonShowMissingCoins.Click += new System.EventHandler(this.ButtonShow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // ButtonIncrement
            // 
            this.ButtonIncrement.Image = global::NumismaticXP.Properties.Resources.Add;
            this.ButtonIncrement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonIncrement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonIncrement.Name = "ButtonIncrement";
            this.ButtonIncrement.Size = new System.Drawing.Size(88, 36);
            this.ButtonIncrement.Text = "Zwiększ";
            this.ButtonIncrement.Click += new System.EventHandler(this.ButtonIncrement_Click);
            // 
            // ButtonDecrement
            // 
            this.ButtonDecrement.Image = global::NumismaticXP.Properties.Resources.Remove;
            this.ButtonDecrement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonDecrement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDecrement.Name = "ButtonDecrement";
            this.ButtonDecrement.Size = new System.Drawing.Size(94, 36);
            this.ButtonDecrement.Text = "Zmniejsz";
            this.ButtonDecrement.Click += new System.EventHandler(this.ButtonDecrement_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // LabelSearch
            // 
            this.LabelSearch.Image = global::NumismaticXP.Properties.Resources.Spotlight_Blue_Button;
            this.LabelSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LabelSearch.Margin = new System.Windows.Forms.Padding(2, 1, 3, 2);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(32, 36);
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TextBoxSearch.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(176, 36);
            this.TextBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // ButtonClearSearch
            // 
            this.ButtonClearSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonClearSearch.Image = global::NumismaticXP.Properties.Resources.Trash_Empty;
            this.ButtonClearSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonClearSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClearSearch.Name = "ButtonClearSearch";
            this.ButtonClearSearch.Size = new System.Drawing.Size(36, 36);
            this.ButtonClearSearch.Text = "Wyczyść szukaną frazę";
            this.ButtonClearSearch.Click += new System.EventHandler(this.ButtonClearSearch_Click);
            // 
            // DataGridViewCoins
            // 
            this.DataGridViewCoins.AllowUserToAddRows = false;
            this.DataGridViewCoins.AllowUserToDeleteRows = false;
            this.DataGridViewCoins.AllowUserToOrderColumns = true;
            this.DataGridViewCoins.AllowUserToResizeRows = false;
            this.DataGridViewCoins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewCoins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewCoins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCoins.Location = new System.Drawing.Point(13, 67);
            this.DataGridViewCoins.MultiSelect = false;
            this.DataGridViewCoins.Name = "DataGridViewCoins";
            this.DataGridViewCoins.ReadOnly = true;
            this.DataGridViewCoins.RowHeadersVisible = false;
            this.DataGridViewCoins.RowHeadersWidth = 24;
            this.DataGridViewCoins.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewCoins.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewCoins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewCoins.Size = new System.Drawing.Size(584, 385);
            this.DataGridViewCoins.TabIndex = 3;
            this.DataGridViewCoins.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCoins_CellClick);
            this.DataGridViewCoins.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCoins_CellDoubleClick);
            this.DataGridViewCoins.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridViewCoins_ColumnDisplayIndexChanged);
            this.DataGridViewCoins.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.DataGridViewCoins_ColumnWidthChanged);
            this.DataGridViewCoins.Sorted += new System.EventHandler(this.DataGridViewCoins_Sorted);
            this.DataGridViewCoins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewCoins_KeyDown);
            this.DataGridViewCoins.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridViewCoins_KeyUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 496);
            this.Controls.Add(this.DataGridViewCoins);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numismatic v0.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCoins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ButtonGeneral;
        private System.Windows.Forms.ToolStripMenuItem ButtonFinish;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton ButtonIncrement;
        private System.Windows.Forms.ToolStripStatusLabel LabelCoins;
        private System.Windows.Forms.ToolStripButton ButtonDecrement;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton ButtonShowCoins;
        private System.Windows.Forms.ToolStripMenuItem ButtonShowAllCoins;
        private System.Windows.Forms.ToolStripMenuItem ButtonShowOwnedCoins;
        private System.Windows.Forms.ToolStripMenuItem ButtonShowRedundantCoins;
        private System.Windows.Forms.ToolStripMenuItem ButtonShowMissingCoins;
        private System.Windows.Forms.ToolStripMenuItem ButtonAdminTools;
        private System.Windows.Forms.DataGridView DataGridViewCoins;
        private System.Windows.Forms.ToolStripMenuItem ButtonAddUser;
        private System.Windows.Forms.ToolStripMenuItem ButtonClearDatabase;
        private System.Windows.Forms.ToolStripTextBox TextBoxSearch;
        private System.Windows.Forms.ToolStripLabel LabelSearch;
        private System.Windows.Forms.ToolStripMenuItem ButtonSynchronize;
        private System.Windows.Forms.ToolStripMenuItem ButtonSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ButtonAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ButtonClearSearch;
        private System.Windows.Forms.ToolStripMenuItem ButtonExport;
        private System.Windows.Forms.ToolStripMenuItem ButtonNBP;
        private System.Windows.Forms.ToolStripMenuItem ButtonEditUser;
        private System.Windows.Forms.ToolStripMenuItem ButtonRemoveUser;
    }
}