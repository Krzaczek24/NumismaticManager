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
            this.GroupBoxWebsitePath.SuspendLayout();
            this.GroupBoxBackup.SuspendLayout();
            this.GroupBoxCoins.SuspendLayout();
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
            this.ButtonSaveSettings.Location = new System.Drawing.Point(404, 292);
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
            this.GroupBoxWebsitePath.Size = new System.Drawing.Size(468, 45);
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
            this.TextBoxWebsitePath.Size = new System.Drawing.Size(456, 20);
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
            this.GroupBoxBackup.Location = new System.Drawing.Point(139, 63);
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 327);
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
    }
}