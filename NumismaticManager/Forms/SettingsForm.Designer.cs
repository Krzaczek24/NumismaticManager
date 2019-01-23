namespace NumismaticManager.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CheckBoxesCoins = new System.Windows.Forms.CheckedListBox();
            this.ButtonSaveSettings = new System.Windows.Forms.Button();
            this.GroupBoxWebsitePath = new System.Windows.Forms.GroupBox();
            this.TextBoxWebsitePath = new System.Windows.Forms.TextBox();
            this.CheckBoxBackup = new System.Windows.Forms.CheckBox();
            this.GroupBoxBackup = new System.Windows.Forms.GroupBox();
            this.GroupBoxCoins = new System.Windows.Forms.GroupBox();
            this.GroupBoxRedundant = new System.Windows.Forms.GroupBox();
            this.LabelRedundant = new System.Windows.Forms.Label();
            this.NumericUpDownRedundant = new System.Windows.Forms.NumericUpDown();
            this.GroupBoxWebsitePath.SuspendLayout();
            this.GroupBoxBackup.SuspendLayout();
            this.GroupBoxCoins.SuspendLayout();
            this.GroupBoxRedundant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRedundant)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckBoxesCoins
            // 
            this.CheckBoxesCoins.CheckOnClick = true;
            this.CheckBoxesCoins.FormattingEnabled = true;
            this.CheckBoxesCoins.Location = new System.Drawing.Point(6, 19);
            this.CheckBoxesCoins.Name = "CheckBoxesCoins";
            this.CheckBoxesCoins.Size = new System.Drawing.Size(109, 229);
            this.CheckBoxesCoins.TabIndex = 1;
            // 
            // ButtonSaveSettings
            // 
            this.ButtonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSaveSettings.Location = new System.Drawing.Point(404, 295);
            this.ButtonSaveSettings.Name = "ButtonSaveSettings";
            this.ButtonSaveSettings.Size = new System.Drawing.Size(74, 23);
            this.ButtonSaveSettings.TabIndex = 3;
            this.ButtonSaveSettings.Text = "Zapisz";
            this.ButtonSaveSettings.UseVisualStyleBackColor = true;
            this.ButtonSaveSettings.Click += new System.EventHandler(this.ButtonSaveSettings_Click);
            // 
            // GroupBoxWebsitePath
            // 
            this.GroupBoxWebsitePath.Controls.Add(this.TextBoxWebsitePath);
            this.GroupBoxWebsitePath.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxWebsitePath.Name = "GroupBoxWebsitePath";
            this.GroupBoxWebsitePath.Size = new System.Drawing.Size(466, 45);
            this.GroupBoxWebsitePath.TabIndex = 5;
            this.GroupBoxWebsitePath.TabStop = false;
            this.GroupBoxWebsitePath.Text = "Adres katalogu NBP";
            // 
            // TextBoxWebsitePath
            // 
            this.TextBoxWebsitePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxWebsitePath.Location = new System.Drawing.Point(6, 19);
            this.TextBoxWebsitePath.Name = "TextBoxWebsitePath";
            this.TextBoxWebsitePath.Size = new System.Drawing.Size(454, 20);
            this.TextBoxWebsitePath.TabIndex = 0;
            this.TextBoxWebsitePath.Text = "https://www.nbp.pl/";
            // 
            // CheckBoxBackup
            // 
            this.CheckBoxBackup.AutoSize = true;
            this.CheckBoxBackup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxBackup.Checked = true;
            this.CheckBoxBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxBackup.Location = new System.Drawing.Point(6, 19);
            this.CheckBoxBackup.Name = "CheckBoxBackup";
            this.CheckBoxBackup.Size = new System.Drawing.Size(224, 17);
            this.CheckBoxBackup.TabIndex = 6;
            this.CheckBoxBackup.Text = "Wykonuj kopię przy każdym uruchomieniu";
            this.CheckBoxBackup.UseVisualStyleBackColor = true;
            // 
            // GroupBoxBackup
            // 
            this.GroupBoxBackup.Controls.Add(this.CheckBoxBackup);
            this.GroupBoxBackup.Location = new System.Drawing.Point(139, 120);
            this.GroupBoxBackup.Name = "GroupBoxBackup";
            this.GroupBoxBackup.Size = new System.Drawing.Size(236, 40);
            this.GroupBoxBackup.TabIndex = 7;
            this.GroupBoxBackup.TabStop = false;
            this.GroupBoxBackup.Text = "Kopia zapasowa";
            // 
            // GroupBoxCoins
            // 
            this.GroupBoxCoins.Controls.Add(this.CheckBoxesCoins);
            this.GroupBoxCoins.Location = new System.Drawing.Point(12, 63);
            this.GroupBoxCoins.Name = "GroupBoxCoins";
            this.GroupBoxCoins.Size = new System.Drawing.Size(121, 255);
            this.GroupBoxCoins.TabIndex = 8;
            this.GroupBoxCoins.TabStop = false;
            this.GroupBoxCoins.Text = "Wyświetlaj nominały";
            // 
            // GroupBoxRedundant
            // 
            this.GroupBoxRedundant.Controls.Add(this.NumericUpDownRedundant);
            this.GroupBoxRedundant.Controls.Add(this.LabelRedundant);
            this.GroupBoxRedundant.Location = new System.Drawing.Point(139, 63);
            this.GroupBoxRedundant.Name = "GroupBoxRedundant";
            this.GroupBoxRedundant.Size = new System.Drawing.Size(271, 51);
            this.GroupBoxRedundant.TabIndex = 9;
            this.GroupBoxRedundant.TabStop = false;
            this.GroupBoxRedundant.Text = "Nadmiarowe numizmaty";
            // 
            // LabelRedundant
            // 
            this.LabelRedundant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRedundant.Location = new System.Drawing.Point(6, 19);
            this.LabelRedundant.Name = "LabelRedundant";
            this.LabelRedundant.Size = new System.Drawing.Size(205, 26);
            this.LabelRedundant.TabIndex = 1;
            this.LabelRedundant.Text = "Liczba po przekroczeniu której numizmaty będą uznawane za nadmiarowe";
            this.LabelRedundant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumericUpDownRedundant
            // 
            this.NumericUpDownRedundant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDownRedundant.Location = new System.Drawing.Point(217, 24);
            this.NumericUpDownRedundant.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumericUpDownRedundant.Name = "NumericUpDownRedundant";
            this.NumericUpDownRedundant.Size = new System.Drawing.Size(48, 20);
            this.NumericUpDownRedundant.TabIndex = 10;
            this.NumericUpDownRedundant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 327);
            this.Controls.Add(this.GroupBoxRedundant);
            this.Controls.Add(this.GroupBoxCoins);
            this.Controls.Add(this.GroupBoxBackup);
            this.Controls.Add(this.GroupBoxWebsitePath);
            this.Controls.Add(this.ButtonSaveSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ustawienia";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.GroupBoxWebsitePath.ResumeLayout(false);
            this.GroupBoxWebsitePath.PerformLayout();
            this.GroupBoxBackup.ResumeLayout(false);
            this.GroupBoxBackup.PerformLayout();
            this.GroupBoxCoins.ResumeLayout(false);
            this.GroupBoxRedundant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownRedundant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckBoxesCoins;
        private System.Windows.Forms.Button ButtonSaveSettings;
        private System.Windows.Forms.GroupBox GroupBoxWebsitePath;
        private System.Windows.Forms.TextBox TextBoxWebsitePath;
        private System.Windows.Forms.CheckBox CheckBoxBackup;
        private System.Windows.Forms.GroupBox GroupBoxBackup;
        private System.Windows.Forms.GroupBox GroupBoxCoins;
        private System.Windows.Forms.GroupBox GroupBoxRedundant;
        private System.Windows.Forms.NumericUpDown NumericUpDownRedundant;
        private System.Windows.Forms.Label LabelRedundant;
    }
}